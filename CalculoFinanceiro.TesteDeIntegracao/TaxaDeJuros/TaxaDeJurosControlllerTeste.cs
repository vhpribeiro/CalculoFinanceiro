using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using CalculoFinanceiro.Infra.HttpRequest;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using TaxaDeJuros.API;
using Xunit;

namespace CalculoFinanceiro.TesteDeIntegracao.TaxaDeJuros
{
    public class TaxaDeJurosControlllerTeste
    {
        private readonly HttpClient _cliente;

        public TaxaDeJurosControlllerTeste()
        {
            var servidor = new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<Startup>());
            _cliente = servidor.CreateClient();
        }

        [Fact]
        public async Task Deve_conseguir_obter_o_valor_da_taxa_de_juros()
        {
            var requisicao = HttpRequestBuilder.CriarRequisicao(HttpMethod.Get)
                .ComUrl("http://localhost:8000/taxadejuros/taxajuros").Criar();

            var resposta = await _cliente.SendAsync(requisicao);

            resposta.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, resposta.StatusCode);
        }
    }
}