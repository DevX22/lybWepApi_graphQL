using AutoMapper;
using Models;
using Models.dto;
using Models.response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.mapperConfig
{
    internal class mappProfile:Profile
    {
        public mappProfile()
        {
            CreateMap<clienteModel, userResponse>()
                .ForMember(dest=>dest.email,org=>org.MapFrom(map=>map.persona.correo))
                .ForMember(dest=>dest.nombreApellido,org=>org.MapFrom(map=>map.persona.nombre+" "+map.persona.apellidoPaterno));
            CreateMap<clienteModel, userTokenDto>();
            CreateMap<clienteModel, clienteDto>().ReverseMap();
        }
    }
}
