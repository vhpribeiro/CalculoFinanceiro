using CalculoFinanceiro.Aplicacao.Helpers;
using System;
using CalculoFinanceiro.Aplicacao.Comunicacoes;

namespace CalculoFinanceiro.Aplicacao
{
    public class CalculoDeJurosComposto : ICalculoDeJurosCompostos
    {
        private readonly IComunicacaoComServicoDeTaxaDeJuros _comunicacaoComServicoDeTaxaDeJuros;

        public CalculoDeJurosComposto(IComunicacaoComServicoDeTaxaDeJuros comunicacaoComServicoDeTaxaDeJuros)
        {
            _comunicacaoComServicoDeTaxaDeJuros = comunicacaoComServicoDeTaxaDeJuros;
        }

        public decimal Calcular(decimal valorInicial, int tempoEmMeses)
        {
            var taxaDeJuros = _comunicacaoComServicoDeTaxaDeJuros.ObterTaxaDeJuros();
            var juros = 1 + taxaDeJuros;
            var jurosCompostos = (decimal)Math.Pow(juros, tempoEmMeses);
            var valorTotal = valorInicial * jurosCompostos;

            return valorTotal.Truncar(2);
        }
    }
}