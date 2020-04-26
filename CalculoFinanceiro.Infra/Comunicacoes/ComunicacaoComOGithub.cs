using CalculoFinanceiro.Aplicacao.Comunicacoes;
using CalculoFinanceiro.Aplicacao.Dtos;
using CalculoFinanceiro.Infra.HttpRequest;
using System.Net.Http;
using Microsoft.Extensions.Configuration;

namespace CalculoFinanceiro.Infra.Comunicacoes
{
    public class ComunicacaoComOGithub : IComunicacaoComServicoDeRepositorios
    {
        private readonly IConfiguration _configuracao;

        public ComunicacaoComOGithub(IConfiguration configuracao)
        {
            _configuracao = configuracao;
        }

        public string ObterUrlDoRepositorio(string nomeDoUsuario, string nomeDoRepositorio)
        {
            var urlBase = _configuracao.GetSection("UrlDosServicoDeRepositorios:Github").Value;
            var url = urlBase + nomeDoUsuario + "/" + nomeDoRepositorio;
            var respostaDaRequisicao = HttpRequestBuilder.CriarRequisicao(HttpMethod.Get).ComUrl(url)
                .ComUserAgent(nomeDoUsuario).Enviar();

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