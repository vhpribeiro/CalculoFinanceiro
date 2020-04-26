using System.IO;
using CalculoFinanceiro.Infra.HttpRequest;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net;
using System.Net.Http;
using Microsoft.Extensions.PlatformAbstractions;
using TaxaDeJuros.API;
using Xunit;

namespace CalculoFinanceiro.TesteDeIntegracao.TaxaDeJuros
{
    public class TaxaDeJurosControlllerTeste
    {
        private readonly HttpClient _cliente;

        public TaxaDeJurosControlllerTeste()
        {
            var testProjectPath = PlatformServices.Default.Application.ApplicationBasePath;
            var relativePathToHostProject = @"..\..\..\..\..\..\Product.CommandService";
            var caminho = Path.Combine(testProjectPath, relativePathToHostProject);

            var servidor = new TestServer(new WebHostBuilder()
                .UseContentRoot(caminho)
                .UseEnvironment("Development")
                .UseStartup<Startup>());
            _cliente = servidor.CreateClient();
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