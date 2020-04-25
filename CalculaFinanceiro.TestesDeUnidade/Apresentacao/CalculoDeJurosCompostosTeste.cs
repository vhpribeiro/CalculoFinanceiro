using CalculoFinanceiro.Aplicacao;
using CalculoFinanceiro.Aplicacao.Comunicacoes;
using Moq;
using Xunit;

namespace CalculaFinanceiro.TestesDeUnidade.Apresentacao
{
    public class CalculoDeJurosCompostosTeste
    {
        [Theory]
        [InlineData(100, 5, 105.10)]
        [InlineData(106.4, 2, 108.53)]
        [InlineData(156.99, 10, 173.41)]
        public void Deve_calcular_o_juro_composto(decimal valorInicial,int tempoEmMeses, decimal valorTotalEsperado)
        {
            const double taxaDeJuros = 0.01;
            var comunicacaoComServicoDeTaxaDeJuros = new Mock<IComunicacaoComServicoDeTaxaDeJuros>();
            var calculoDeJurosCompostos = new CalculoDeJurosComposto(comunicacaoComServicoDeTaxaDeJuros.Object);
            comunicacaoComServicoDeTaxaDeJuros.Setup(cstj => cstj.ObterTaxaDeJuros()).Returns(taxaDeJuros);

            var valorTotalObtido = calculoDeJurosCompostos.Calcular(valorInicial, tempoEmMeses);

            Assert.Equal(valorTotalEsperado, valorTotalObtido);
        }
    }
}