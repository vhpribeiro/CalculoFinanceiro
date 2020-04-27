using System;

namespace CalculoFinanceiro.Aplicacao.Helpers
{
    public static class ExtensaoDeDecimal
    {
        public static decimal Truncar(this decimal valorParaSerTruncado, int quantidadeDeCasasParaTruncar)
        {
            return Math.Round(valorParaSerTruncado - Convert.ToDecimal(0.5 / Math.Pow(10, quantidadeDeCasasParaTruncar)), quantidadeDeCasasParaTruncar);
        }
    }
}