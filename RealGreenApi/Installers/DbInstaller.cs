using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RealGreenApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealGreenApi.Installers
{
    public class DbInstaller : IInstaller
    {
        public void InstallerServices(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddSingleton<IPostService, PostService>();
        }
    }
}
