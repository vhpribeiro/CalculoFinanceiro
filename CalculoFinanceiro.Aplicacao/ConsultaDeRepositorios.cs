using CalculoFinanceiro.Aplicacao.Comunicacoes;

namespace CalculoFinanceiro.Aplicacao
{
    public class ConsultaDeRepositorios : IConsultaDeRepositorios
    {
        private readonly IComunicacaoComServicoDeRepositorios _comunicacaoComGithub;
        private static string NomeDoUsuario => "vhpribeiro";
        private static string NomeDoRepositorio => "Cervejaria";

        public ConsultaDeRepositorios(IComunicacaoComServicoDeRepositorios comunicacaoComGithub)
        {
            _comunicacaoComGithub = comunicacaoComGithub;
        }

        public string ObterLinkDoRepositorio() =>
            _comunicacaoComGithub.ObterUrlDoRepositorio(NomeDoUsuario, NomeDoRepositorio);
    }
}