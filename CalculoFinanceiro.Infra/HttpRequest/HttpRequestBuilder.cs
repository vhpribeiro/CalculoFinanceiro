using System;
using System.Net.Http;

namespace CalculoFinanceiro.Infra.HttpRequest
{
    public class HttpRequestBuilder
    {
        private static HttpRequestMessage _requisicao;
        private static readonly HttpClient HttpClient = new HttpClient { Timeout = TimeSpan.FromMinutes(20) };

        public static HttpRequestBuilder CriarRequisicao(HttpMethod metodo)
        {
            _requisicao = new HttpRequestMessage(metodo, "");
            return new HttpRequestBuilder();
        }

        public HttpRequestBuilder ComUrl(string url)
        {
            _requisicao.RequestUri = new Uri(url);
            return this;
        }

        public HttpRequestBuilder ComUserAgent(string userAgent)
        {
            _requisicao.Headers.UserAgent.ParseAdd(userAgent);
            return this;
        }

        public HttpRequestMessage Criar()
        {
            return _requisicao;
        }

        public HttpResponseGetter Enviar()
        {
            var respostaDaRequisicao = HttpClient.SendAsync(_requisicao);
            return new HttpResponseGetter(respostaDaRequisicao);
        }
    }
}