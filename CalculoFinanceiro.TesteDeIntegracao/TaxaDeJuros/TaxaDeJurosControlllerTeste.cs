using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TaxaDeJuros.API;
using Xunit;

namespace CalculoFinanceiro.TesteDeIntegracao.TaxaDeJuros
{
    public class TaxaDeJurosControlllerTeste : IClassFixture<SetupParaTesteDeIntegracao<Startup>>
    {
        private readonly HttpClient _cliente;
        private readonly string _urlBaseDoEndpoint;

        public TaxaDeJurosControlllerTeste(SetupParaTesteDeIntegracao<Startup> setupParaTesteDeIntegracao)
        { 
            _cliente = setupParaTesteDeIntegracao.WebApplicationFactory.CreateClient();
            _urlBaseDoEndpoint = "http://localhost:8000/taxadejuros/";
        }

        [Fact]
        public async Task Deve_conseguir_obter_o_valor_da_taxa_de_juros()
        {
            var url = _urlBaseDoEndpoint + "taxajuros";
            const double resultadoEsperado = 0.01;

            var resposta = await _cliente.GetAsync(url);

            var resultadoObtidoEmString = await resposta.Content.ReadAsStringAsync();
            var resultadoObtido = JsonConvert.DeserializeObject<double>(resultadoObtidoEmString);
            Assert.Equal(HttpStatusCode.OK, resposta.StatusCode);
            Assert.Equal(resultadoEsperado, resultadoObtido);
        }
    }
}