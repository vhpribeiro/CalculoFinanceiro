using CalculoFinanceiro.Aplicacao;
using CalculoFinanceiro.Aplicacao.Comunicacoes;
using Moq;
using Xunit;

namespace CalculaFinanceiro.TestesDeUnidade.Apresentacao
{
    public class ConsultaDeRepositoriosTeste
    {
        [Fact]
        public void Deve_obter_o_link_do_repositorio()
        {
            const string nomeDoUsuario = "vhpribeiro";
            const string nomeDoRepositorio = "Cervejaria";
            const string linkEsperado = "https://github.com/vhpribeiro/Cervejaria";
            var comunicacaoComOGithub = new Mock<IComunicacaoComServicoDeRepositorios>();
            var consultaDeRepositorios = new ConsultaDeRepositorios(comunicacaoComOGithub.Object);
            comunicacaoComOGithub.Setup(c => c.ObterUrlDoRepositorio(nomeDoUsuario, nomeDoRepositorio))
                .Returns(linkEsperado);

            var linkObtido = consultaDeRepositorios.ObterLinkDoRepositorio();

            Assert.Equal(linkEsperado, linkObtido);
        }
    }
}