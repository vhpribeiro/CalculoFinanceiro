using CalculoFinanceiro.Aplicacao.Comunicacoes;
using CalculoFinanceiro.Infra.HttpRequest;
using System.Net.Http;
using Microsoft.Extensions.Configuration;

namespace CalculoFinanceiro.Infra.Comunicacoes
{
    public class ComunicacaoComServicoDeTaxaDeJuros : IComunicacaoComServicoDeTaxaDeJuros
    {
        private readonly IConfiguration _configuracao;

        public ComunicacaoComServicoDeTaxaDeJuros(IConfiguration configuracao)
        {
            _configuracao = configuracao;
        }
        public double ObterTaxaDeJuros()
        {
            var urlBase = _configuracao.GetSection("TaxaJurosAPI:UrlDoEndpoint").Value;
            var url = urlBase + "/taxajuros";
            var respostaDaRequisicao = HttpRequestBuilder.CriarRequisicao(HttpMethod.Get).ComUrl(url).Enviar();

            double taxaDeJuros;
            try
            {
                taxaDeJuros = respostaDaRequisicao.ObterRespostaComo<double>();
            }
            catch
            {
                throw new HttpRequestException("Não foi possível a taxa de juros.");
            }

            return taxaDeJuros;
        }
    }
}