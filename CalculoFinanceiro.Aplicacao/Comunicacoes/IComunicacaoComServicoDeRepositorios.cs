namespace CalculoFinanceiro.Aplicacao.Comunicacoes
{
    public interface IComunicacaoComServicoDeRepositorios
    {
        string ObterUrlDoRepositorio(string nomeDoUsuario, string nomeDoRepositorio);
    }
}