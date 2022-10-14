using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public static class corsConfig
    {
        public static string AddConfigCors(this IServiceCollection service,WebApplicationBuilder builder)
        {
            string _MyCoors = "SysLyB";
            service.AddCors(options =>
            {
                string Cliente = builder.Configuration["ClienteHost"];
                options.AddPolicy(name: _MyCoors,
                                  builder =>
                                  {
                                      builder.AllowAnyOrigin(); //<= permitir todas las rutas
                                      //builder.WithOrigins(Cliente); //<= esto es para host real
                                      //builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost");
                                      builder.AllowAnyHeader();
                                      builder.AllowAnyMethod();
                                  });
            });
            return _MyCoors;
        }
    }
}
