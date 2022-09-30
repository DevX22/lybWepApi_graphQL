using AutoMapper;
using Models;
using Models.dto;
using Models.mapperConfig;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace Logic
{
    public class clienteLogic
    {
        private readonly clienteRepository _repo = new clienteRepository();
        private IMapper _map = mapper.Go();
        
        public bool Create(clienteModel request)
        {
            request.usser = request.persona.correo;
            request.contrasena = encrypt.SHA256(character.remove(request.contrasena));
            _repo.Create(request);
            if (request.id == 0 || request.id==null)
            {
                return false;
            }
            return true;
        }

        public List<clienteModel> listDetaild()
        {
            List<clienteDto> response = _map.Map<List<clienteDto>>(_repo.listDetaild());
            return _map.Map<List<clienteModel>>(response);
        }

        public bool existsCliente(string usser)
        {
            return _repo.existsCliente(usser);
        }
    }
}
