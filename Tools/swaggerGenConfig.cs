using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public static class swaggerGenConfig
    {
        public static void AddConfigSwaggerGen(this IServiceCollection service)
        {
            service.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(swaggerData.version, new OpenApiInfo
                {
                    Version = swaggerData.version,
                    Title = swaggerData.title,
                    //Description = swaggerData.description,
                    /*TermsOfService = new Uri(swaggerData.termsOfService),
                    Contact = new OpenApiContact
                    {
                        Name = swaggerData.contactName,
                        Url = new Uri(swaggerData.contactUrl),
                    },
                    License = new OpenApiLicense
                    {
                        Name = swaggerData.licenseName,
                        Url = new Uri(swaggerData.licenseUrl)
                    }*/
                });
            });
        }
    }
}
