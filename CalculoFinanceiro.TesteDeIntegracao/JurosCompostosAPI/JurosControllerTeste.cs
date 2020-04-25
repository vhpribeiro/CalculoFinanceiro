using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using CalculaFinanceiro.API;
using CalculoFinanceiro.Infra.HttpRequest;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Xunit;

namespace CalculoFinanceiro.TesteDeIntegracao.JurosCompostosAPI
{
    public class JurosControllerTeste
    {
        private readonly HttpClient _cliente;

        public JurosControllerTeste()
        {
            var servidor = new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<Startup>());
            _cliente = servidor.CreateClient();
        }

        [Fact]
        public async Task Deve_conseguir_obter_link_do_repositorio()
        {
            const string url = "http://localhost:9000/juros/showmethecode";
            var requisicao = HttpRequestBuilder.CriarRequisicao(HttpMethod.Get)
                .ComUrl(url).Criar();

            var resposta = await _cliente.SendAsync(requisicao);

            resposta.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, resposta.StatusCode);
        }

        [Theory]
        [InlineData(100, 5)]
        [InlineData(125, 8)]
        [InlineData(148, 7)]
        public async Task Deve_calcular_o_valor_do_juros(decimal valorInicial, int meses)
        {
            var url = $"http://localhost:9000/juros/calculajuros?valorInicial={valorInicial}&meses={meses}";
            var requisicao = HttpRequestBuilder.CriarRequisicao(HttpMethod.Get)
                .ComUrl(url).Criar();

            var resposta = await _cliente.SendAsync(requisicao);

            resposta.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, resposta.StatusCode);
        }
    }
}