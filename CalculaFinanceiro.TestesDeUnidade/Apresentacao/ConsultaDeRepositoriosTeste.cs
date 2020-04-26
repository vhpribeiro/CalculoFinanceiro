using CalculoFinanceiro.Aplicacao;
using CalculoFinanceiro.Aplicacao.Comunicacoes;
using Moq;
using Xunit;

namespace CalculaFinanceiro.TestesDeUnidade.Apresentacao
{
    public class ConsultaDeRepositoriosTeste
    {
        private readonly string _nomeDoUsuario;
        private readonly string _nomeDoRepositorio;
        private readonly string _linkEsperado;
        private readonly Mock<IComunicacaoComServicoDeRepositorios> _comunicacaoComOServicoDeRepositorios;
        private readonly ConsultaDeRepositorios _consultaDeRepositorios;

        public ConsultaDeRepositoriosTeste()
        {
            _nomeDoUsuario = "vhpribeiro";
            _nomeDoRepositorio = "CalculoFinanceiro";
            _linkEsperado = "https://github.com/vhpribeiro/CalculoFinanceiro";
            _comunicacaoComOServicoDeRepositorios = new Mock<IComunicacaoComServicoDeRepositorios>();
            _consultaDeRepositorios = new ConsultaDeRepositorios(_comunicacaoComOServicoDeRepositorios.Object);
            _comunicacaoComOServicoDeRepositorios.Setup(c => c.ObterUrlDoRepositorio(_nomeDoUsuario, _nomeDoRepositorio))
                .Returns(_linkEsperado);
        }

        [Fact]
        public void Deve_se_comunicar_com_o_servico_de_repositorios()
        {
            _consultaDeRepositorios.ObterLinkDoRepositorio();

            _comunicacaoComOServicoDeRepositorios.Verify(c => c.ObterUrlDoRepositorio(_nomeDoUsuario, _nomeDoRepositorio));
        }

        [Fact]
        public void Deve_obter_o_link_do_repositorio()
        {
            var linkObtido = _consultaDeRepositorios.ObterLinkDoRepositorio();

            Assert.Equal(_linkEsperado, linkObtido);
        }
    }
}