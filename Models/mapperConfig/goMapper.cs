using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.mapperConfig
{
    public class mapper
    {
        public static IMapper Go()
        {
            IMapper _mapper = mappConfig.registerMaps().CreateMapper();
            return _mapper;
        }
    }
}
