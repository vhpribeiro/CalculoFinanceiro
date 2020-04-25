using CalculoFinanceiro.Aplicacao;
using CalculoFinanceiro.Aplicacao.Dtos;
using CalculoFinanceiro.Infra.HttpRequest;
using System.Net.Http;
using CalculoFinanceiro.Aplicacao.Comunicacoes;

namespace CalculoFinanceiro.Infra.Comunicacoes
{
    public class ComunicacaoComGithub : IComunicacaoComServicoDeRepositorios
    {
        private static string UrlBase => "https://api.github.com/repos/";
        public string ObterUrlDoRepositorio(string nomeDoUsuario, string nomeDoRepositorio)
        {
            var url = UrlBase + nomeDoUsuario + "/" + nomeDoRepositorio;
            var respostaDaRequisicao = HttpRequestBuilder.CriarRequisicao(HttpMethod.Get).ComUrl(url).ComUserAgent(nomeDoUsuario).Enviar();

            RepositorioDto repositorioDto;
            try
            {
                repositorioDto = respostaDaRequisicao.ObterRespostaComo<RepositorioDto>();
            }
            catch
            {
                throw new HttpRequestException("Não foi possível obter o link do repositório.");
            }

            return repositorioDto.Html_url;
        }
    }
}