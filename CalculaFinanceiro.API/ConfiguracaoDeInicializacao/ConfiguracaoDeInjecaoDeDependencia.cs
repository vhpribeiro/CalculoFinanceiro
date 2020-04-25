using CalculoFinanceiro.Aplicacao;
using CalculoFinanceiro.Aplicacao.Comunicacoes;
using CalculoFinanceiro.Infra.Comunicacoes;
using Microsoft.Extensions.DependencyInjection;

namespace CalculaFinanceiro.API.ConfiguracaoDeInicializacao
{
    public class ConfiguracaoDeInjecaoDeDependencia
    {
        public static void Configurar(IServiceCollection services)
        {
            services.AddScoped<IComunicacaoComServicoDeRepositorios, ComunicacaoComGithub>();
            services.AddScoped<IComunicacaoComServicoDeTaxaDeJuros, ComunicacaoComServicoDeTaxaDeJuros>();
            services.AddScoped<ICalculoDeJurosCompostos, CalculoDeJurosComposto>();
            services.AddScoped<IConsultaDeRepositorios, ConsultaDeRepositorios>();
        }
    }
}