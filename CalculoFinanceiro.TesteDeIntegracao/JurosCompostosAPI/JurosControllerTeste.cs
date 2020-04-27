using CalculaFinanceiro.API;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using CalculoFinanceiro.Infra.HttpRequest;
using Xunit;

namespace CalculoFinanceiro.TesteDeIntegracao.JurosCompostosAPI
{
    public class JurosControllerTeste : IClassFixture<SetupParaTesteDeIntegracao<Startup>>
    {
        private readonly HttpClient _cliente;

        public JurosControllerTeste(SetupParaTesteDeIntegracao<Startup> setupParaTesteDeIntegracao)
        {
            _cliente = setupParaTesteDeIntegracao.WebApplicationFactory.CreateClient();
        }

        [Fact]
        public async Task Deve_conseguir_obter_link_do_repositorio()
        {
            const string resultadoEsperado = "https://github.com/vhpribeiro/CalculoFinanceiro";
            const string url = "http://localhost:9000/juros/showmethecode";
            
            var resposta = await _cliente.GetAsync(url);

            var resultadoObtido = await resposta.Content.ReadAsStringAsync();
            Assert.Equal(HttpStatusCode.OK, resposta.StatusCode);
            Assert.Equal(resultadoEsperado, resultadoObtido);
        }

        [Theory]
        [InlineData(100, 5, 105.1)]
        public void Deve_calcular_o_valor_do_juros(decimal valorInicial, int meses, double resultadoEsperado)
        {
            var url = $"http://localhost:9000/juros/calculajuros?valorInicial={valorInicial}&meses={meses}";
            var requisicao = HttpRequestBuilder.CriarRequisicao(HttpMethod.Get)
                .ComUrl(url).Criar();

            var resposta = _cliente.SendAsync(requisicao);

            var resultadoObtido = new HttpResponseGetter(resposta).ObterRespostaComo<double>();
            Assert.Equal(HttpStatusCode.OK, resposta.Result.StatusCode);
            Assert.Equal(resultadoEsperado, resultadoObtido);
        }
    }
}