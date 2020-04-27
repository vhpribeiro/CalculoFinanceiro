using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using System;

namespace CalculoFinanceiro.TesteDeIntegracao
{
    public class SetupParaTesteDeIntegracao<TStartup> : IDisposable where TStartup : class 
    {
        private const string HostingEnvironment = "Integration";

        private readonly WebApplicationFactory<TStartup> _servidor;

        public WebApplicationFactory<TStartup> WebApplicationFactory => _servidor ?? ConfigureWebApplicationFactory();

        public SetupParaTesteDeIntegracao()
        {
            _servidor = ConfigureWebApplicationFactory();
        }
        public void Dispose()
        {
            _servidor.Dispose();
        }

        private static WebApplicationFactory<TStartup> ConfigureWebApplicationFactory()
        {
            return new WebApplicationFactory<TStartup>().WithWebHostBuilder(builder =>
                {
                    builder.UseEnvironment(HostingEnvironment);
                });
        }
    }
}