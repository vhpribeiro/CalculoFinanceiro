namespace CalculoFinanceiro.Aplicacao
{
    public interface ICalculoDeJurosCompostos
    {
        decimal Calcular(decimal valorInicial, int tempoEmMeses);
    }
}