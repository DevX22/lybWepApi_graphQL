using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public static class appConfig
    {
        public static IHostEnvironment Production(this IHostEnvironment enviroment)
        {
            enviroment.EnvironmentName = "Production";
            return enviroment;
        }
        public static IHostEnvironment Development(this IHostEnvironment enviroment)
        {
            enviroment.EnvironmentName = "Development";
            return enviroment;
        }
    }
}
