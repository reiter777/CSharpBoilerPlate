using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealGreenApi.Installers
{
    public class SwaggerInstaller : IInstaller
    {
        public void InstallerServices(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RealGreenApi", Version = "v1" });
            });
        }
    }
}
