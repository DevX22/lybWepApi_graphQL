using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public static class globalVar
    {
        public static string cnn { get; set; }
        public static string JWTSubject { get; set; }
        public static string JWTKey { get; set; }
        public static string JWTIssuer { get; set; }
        public static string JWTAudience { get; set; }

        public static void Go(ConfigurationManager configuration)
        {
            cnn = configuration["ConnectionStrings:db"];
            JWTSubject = configuration["Jwt:Subject"];
            JWTKey = configuration["Jwt:Key"];
            JWTIssuer = configuration["Jwt:Issuer"];
            JWTAudience = configuration["Jwt:Audience"];
        }
    }
}
