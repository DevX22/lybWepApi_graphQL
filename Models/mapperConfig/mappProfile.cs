﻿using AutoMapper;
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
            CreateMap<usuarioModel, userResponse>()
                .ForMember(d => d.email, o => o.MapFrom(m => m.persona.correo))
                .ForMember(d => d.rolUser, o => o.MapFrom(m => m.rolUser.rolUsuario))
                .ForMember(d => d.nombreApellido, o => o.MapFrom(m => m.persona.nombre + " " + m.persona.apellidoPaterno));
            CreateMap<usuarioModel, userTokenDto>();
            CreateMap<usuarioModel, usuarioDto>().ReverseMap();
            CreateMap<usuarioDto,usuarioModel>().ReverseMap();
            CreateMap<productoModel, productoDto>().ReverseMap();
            CreateMap<colorProductoModel,colorProductoDto>().ReverseMap();
            CreateMap<imgProductoModel, imgProductoDto>().ReverseMap();
            CreateMap<tallaColorModel, colorProductoDto>().ReverseMap();
            CreateMap<tallaProductoModel, tallaProductoDto>().ReverseMap();
            CreateMap<ventaDto, ventaModel>()
                .ForMember(des => des.horaPedido, op => op.MapFrom(src =>string.IsNullOrEmpty(src.horaPedido)?(TimeSpan?)null:TimeSpan.Parse(src.horaPedido)))
                .ForMember(des => des.horaVenta, op => op.MapFrom(src => string.IsNullOrEmpty(src.horaVenta)?(TimeSpan?)null:TimeSpan.Parse(src.horaVenta)))
                .ReverseMap()
                .ForMember(src=>src.horaPedido, op => op.MapFrom(des=>des.horaPedido==null?"":des.horaPedido.Value.ToString(@"hh\:mm\:ss")))
                .ForMember(src=>src.horaVenta, op => op.MapFrom(des=>des.horaVenta==null?"":des.horaVenta.Value.ToString(@"hh\:mm\:ss")));
        }
    }
}
