using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CingeRazor
{
    public static class Extensiones
    {
        public static void AgregarVariablesCinge(this IServiceCollection services,
               IConfiguration configuration)
        {
            var settingsSection = configuration.GetSection("VariablesCinge");
            var settings = settingsSection.Get<VariablesCinge>();

            // Inject VariablesCinge so that others can use too
            services.Configure<VariablesCinge>(settingsSection);
        }
    }
}
