using CalculoFinanceiro.Infra.HttpRequest;
using System.Net;
using System.Net.Http;
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
        public void Deve_conseguir_obter_o_valor_da_taxa_de_juros()
        {
            var url = _urlBaseDoEndpoint + "taxajuros";
            const double resultadoEsperado = 0.01;
            var requisicao = HttpRequestBuilder.CriarRequisicao(HttpMethod.Get)
                .ComUrl(url).Criar();

            var resposta = _cliente.SendAsync(requisicao);

            var resultadoObtido = new ObtencaoDeRespostaHttp(resposta).ObterRespostaComo<double>();
            Assert.Equal(HttpStatusCode.OK, resposta.Result.StatusCode);
            Assert.Equal(resultadoEsperado, resultadoObtido);
        }
    }
}