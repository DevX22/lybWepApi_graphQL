using AutoMapper;
using Models;
using Models.dto;
using Models.mapperConfig;
using Repository;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace Logic
{
    public class usuarioLogic
    {
        private readonly usuarioRepository _repo = new usuarioRepository();
        private readonly IMapper _map = mapper.Go();

        public bool Create(usuarioModel request)
        {
            request.usser = character.remove(request.usser.ToUpper());
            request.contrasena = encrypt.SHA256(character.remove(request.contrasena));
            _repo.Create(request);
            if (request.id == 0 || request.id == null)
            {
                return false;
            }
            return true;
        }

        public List<usuarioDto> listDetaild()
        {
            List<usuarioDto> response = _map.Map<List<usuarioDto>>(_repo.listDetaild());
            return response;
        }

        public bool existsUsuario(string usser)
        {
            return _repo.existsUsuario(usser);
        }
    }
}
