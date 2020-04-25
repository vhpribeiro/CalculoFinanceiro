using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace TaxaDeJuros.API.ConfiguracaoDeInicializacao
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
                        Title = "Taxa de Juros",
                        Version = "v1",
                        Description =
                            "API para obter o valor da taxa de juros.",
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