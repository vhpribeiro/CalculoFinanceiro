using CalculoFinanceiro.Aplicacao.Helpers;
using Xunit;

namespace CalculaFinanceiro.TestesDeUnidade.Apresentacao.Helpers
{
    public class ExtensaoDeDecimalTeste
    {
        [Theory]
        [InlineData(105.6598, 1, 105.6)]
        [InlineData(1.456986, 3, 1.456)]
        [InlineData(105.6598, 4, 105.6598)]
        [InlineData(98.65984569878, 7, 98.6598456)]
        public void Deve_truncar_o_numero_em_uma_determinada_quantidade_de_casas_decimais(decimal valorSemTruncar,
            int quantidadeDeCasasDecimais, decimal valorTruncadoEsperado)
        {
            var valorTruncadoObtido = valorSemTruncar.Truncar(quantidadeDeCasasDecimais);

            Assert.Equal(valorTruncadoEsperado, valorTruncadoObtido);
        }
    }
}