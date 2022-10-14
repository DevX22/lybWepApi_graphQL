using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.common;
using Models.dto;
using Models.mapperConfig;
using Models.response;
using Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace Repository
{
    public class authClienteRepository
    {
        private readonly _dbContext _db = new _dbContext();
        private token oToken = new token();
        private IMapper _mapp = mapper.Go();

        public loginResponse authClient(authRequestModel request)
        {
            loginResponse loginResponse = new loginResponse();
            userResponse userResponse = new userResponse();
            userTokenDto userToken = new userTokenDto();
            if (request == null || request.password == "" || request.user == "")
            {
                loginResponse.status = "Datos de ingreso faltantes";
                return loginResponse;
            }
            string password = encrypt.SHA256(character.remove(request.password));
            clienteModel user = _db.cliente
                .Include(x => x.persona)
                .Where(x => x.usser == request.user && x.contrasena == password).FirstOrDefault();
            if (user == null)
            {
                loginResponse.status = "Datos de ingreso incorrectos";
                return loginResponse;
            }
            userResponse = _mapp.Map<clienteModel,userResponse>(user);
            userToken = _mapp.Map<clienteModel, userTokenDto>(user);
            loginResponse.user = userResponse;
            if (user.estado == false)
            {
                loginResponse.success = true;
                loginResponse.status = "Cuenta desabilitada";
                return loginResponse;
            }
            loginResponse.token = oToken.getToken(userToken, 60,null);
            loginResponse.success = true;
            loginResponse.status = $"Bienvenido {user.persona.nombre}";
            return loginResponse;
        }
    }
}
