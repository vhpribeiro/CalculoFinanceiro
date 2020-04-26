using CalculoFinanceiro.Aplicacao.Comunicacoes;

namespace CalculoFinanceiro.Aplicacao
{
    public class ConsultaDeRepositorios : IConsultaDeRepositorios
    {
        private readonly IComunicacaoComServicoDeRepositorios _comunicacaoComServicoDeRepositorios;
        private static string NomeDoUsuario => "vhpribeiro";
        private static string NomeDoRepositorio => "CalculoFinanceiro";

        public ConsultaDeRepositorios(IComunicacaoComServicoDeRepositorios comunicacaoComServicoDeRepositorios)
        {
            _comunicacaoComServicoDeRepositorios = comunicacaoComServicoDeRepositorios;
        }

        public string ObterLinkDoRepositorio() =>
            _comunicacaoComServicoDeRepositorios.ObterUrlDoRepositorio(NomeDoUsuario, NomeDoRepositorio);
    }
}