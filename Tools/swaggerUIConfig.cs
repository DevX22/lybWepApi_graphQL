using Microsoft.AspNetCore.Builder;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public static class swaggerUIConfig
    {
        public static WebApplication UseCustomSwaggerUI(this WebApplication options)
        {
            options.UseSwaggerUI(o =>
            {
                o.DocumentTitle = swaggerData.title;
                o.SwaggerEndpoint($"{swaggerData.version}/swagger.json", $"{swaggerData.title} {swaggerData.version}");
            });
            return options;
        }
    }
}
