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

        public TaxaDeJurosControlllerTeste(SetupParaTesteDeIntegracao<Startup> setupParaTesteDeIntegracao)
        { 
            _cliente = setupParaTesteDeIntegracao.WebApplicationFactory.CreateClient();
        }

        [Fact]
        public void Deve_conseguir_obter_o_valor_da_taxa_de_juros()
        {
            const double resultadoEsperado = 0.01;
            var requisicao = HttpRequestBuilder.CriarRequisicao(HttpMethod.Get)
                .ComUrl("http://localhost:8000/taxadejuros/taxajuros").Criar();

            var resposta = _cliente.SendAsync(requisicao);

            var resultadoObtido = new HttpResponseGetter(resposta).ObterRespostaComo<double>();
            Assert.Equal(HttpStatusCode.OK, resposta.Result.StatusCode);
            Assert.Equal(resultadoEsperado, resultadoObtido);
        }
    }
}