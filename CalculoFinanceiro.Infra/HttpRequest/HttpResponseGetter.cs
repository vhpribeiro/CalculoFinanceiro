using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace CalculoFinanceiro.Infra.HttpRequest
{
    public class HttpResponseGetter
    {
        private readonly Task<HttpResponseMessage> _respostaDaRequisicao;
        public HttpResponseGetter(Task<HttpResponseMessage> respostaDaRequisicao)
        {
            _respostaDaRequisicao = respostaDaRequisicao;
        }

        public T ObterRespostaComo<T>()
        {
            var resultado = default(T);
            _respostaDaRequisicao.ContinueWith(resposta =>
            {
                var configuracoesDoJson = new JsonSerializerSettings
                {
                    DateFormatString = "dd/MM/yyyy HH:mm",
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };
                var json = resposta.Result.Content.ReadAsStringAsync();
                json.Wait();
                resultado = JsonConvert.DeserializeObject<T>(json.Result, configuracoesDoJson);
            }).Wait();

            if (!_respostaDaRequisicao.Result.IsSuccessStatusCode)
            {
                throw new HttpRequestException();
            }
            return resultado;
        }
    }
}
