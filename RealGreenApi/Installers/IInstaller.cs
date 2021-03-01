﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealGreenApi.Installers
{
    public interface IInstaller
    {
        void InstallerServices(IServiceCollection services, IConfiguration Configuration);
    }
}
