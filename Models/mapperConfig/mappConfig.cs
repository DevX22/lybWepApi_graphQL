using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.mapperConfig
{
    public class mappConfig
    {
        public static MapperConfiguration registerMaps()
        {
            var mapperConfig = new MapperConfiguration(config =>
            {
                config.AddProfile(new mappProfile());
            });
            return mapperConfig;
        }
    }
}
