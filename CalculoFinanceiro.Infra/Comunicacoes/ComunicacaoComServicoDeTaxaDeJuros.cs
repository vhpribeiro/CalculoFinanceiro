using CalculoFinanceiro.Aplicacao.Comunicacoes;
using CalculoFinanceiro.Infra.HttpRequest;
using System.Net.Http;

namespace CalculoFinanceiro.Infra.Comunicacoes
{
    public class ComunicacaoComServicoDeTaxaDeJuros : IComunicacaoComServicoDeTaxaDeJuros
    {
        private static string UrlBase => "http://localhost:9000/juros";
        public double ObterTaxaDeJuros()
        {
            var url = UrlBase + "/taxajuros";
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