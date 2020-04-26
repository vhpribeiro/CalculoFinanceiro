﻿using CalculaFinanceiro.API;
using CalculoFinanceiro.Infra.HttpRequest;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
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
            const string resultadoEsperado = "https://github.com/vhpribeiro/Cervejaria";
            const string url = "http://localhost:9000/juros/showmethecode";
            
            var resposta = await _cliente.GetAsync(url);

            var resultadoObtido = await resposta.Content.ReadAsStringAsync();
            Assert.Equal(HttpStatusCode.OK, resposta.StatusCode);
            Assert.Equal(resultadoEsperado, resultadoObtido);
        }

        [Theory]
        [InlineData(100, 5, 105.1)]
        [InlineData(125, 8, 135.35)]
        [InlineData(148, 7, 158.67)]
        public void Deve_calcular_o_valor_do_juros(decimal valorInicial, int meses, decimal resultadoEsperado)
        {
            var url = $"http://localhost:9000/juros/calculajuros?valorInicial={valorInicial}&meses={meses}";
            var requisicao = HttpRequestBuilder.CriarRequisicao(HttpMethod.Get)
                .ComUrl(url).Criar();

            var resposta = _cliente.SendAsync(requisicao);

            var resultadoObtido = new HttpResponseGetter(resposta).ObterRespostaComo<decimal>();
            Assert.Equal(HttpStatusCode.OK, resposta.Result.StatusCode);
            Assert.Equal(resultadoEsperado, resultadoObtido);
        }
    }
}