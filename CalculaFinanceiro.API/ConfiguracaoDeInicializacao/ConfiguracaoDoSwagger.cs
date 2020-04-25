using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace CalculaFinanceiro.API.ConfiguracaoDeInicializacao
{
    public class ConfiguracaoDoSwagger
    {
        public static void Configurar(IServiceCollection services)
        {
            services.AddSwaggerGen(sg =>
            {
                sg.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Calculo Financeiro",
                        Version = "v1",
                        Description =
                            "API para fazer o calculo do juros e obter o link do repositório do projeto no Github.",
                        Contact = new OpenApiContact
                        {
                            Name = "Vitor Ribeiro",
                            Url = new Uri("https://github.com/vhpribeiro")
                        }
                    });
            });
        }
    }
}