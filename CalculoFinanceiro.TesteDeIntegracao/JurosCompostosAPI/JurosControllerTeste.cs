using JurosCompostos.API;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace CalculoFinanceiro.TesteDeIntegracao.JurosCompostosAPI
{
    public class JurosControllerTeste : IClassFixture<SetupParaTesteDeIntegracao<Startup>>
    {
        private readonly HttpClient _cliente;
        private readonly string _urlBaseDoEndpoint;

        public JurosControllerTeste(SetupParaTesteDeIntegracao<Startup> setupParaTesteDeIntegracao)
        {
            _cliente = setupParaTesteDeIntegracao.WebApplicationFactory.CreateClient();
            _urlBaseDoEndpoint = "http://localhost:9000/juros/";
        }

        [Fact]
        public async Task Deve_conseguir_obter_link_do_repositorio()
        {
            const string resultadoEsperado = "https://github.com/vhpribeiro/CalculoFinanceiro";
            var url = _urlBaseDoEndpoint + "showmethecode";
            
            var resposta = await _cliente.GetAsync(url);

            var resultadoObtido = await resposta.Content.ReadAsStringAsync();
            Assert.Equal(HttpStatusCode.OK, resposta.StatusCode);
            Assert.Equal(resultadoEsperado, resultadoObtido);
        }

        [Theory]
        [InlineData(100, 5, 105.1)]
        [InlineData(108, 9, 118.11)]
        [InlineData(300, 2, 306.02)]
        public async Task Deve_calcular_o_valor_do_juros(decimal valorInicial, int meses, decimal resultadoEsperado)
        {
            var url = _urlBaseDoEndpoint + $"calculajuros?valorInicial={valorInicial}&meses={meses}";

            var resposta = await _cliente.GetAsync(url);

            var resultadoObtidoEmString = await resposta.Content.ReadAsStringAsync();
            var resultadoObtido = JsonConvert.DeserializeObject<decimal>(resultadoObtidoEmString);
            Assert.Equal(HttpStatusCode.OK, resposta.StatusCode);
            Assert.Equal(resultadoEsperado, resultadoObtido);
        }
    }
}