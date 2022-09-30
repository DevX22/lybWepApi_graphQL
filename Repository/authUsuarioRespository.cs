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
    public class authUsuarioRespository
    {
        private readonly _dbContext _db = new _dbContext();
        private readonly token oToken = new token();
        private readonly IMapper _mapp = mapper.Go();

        public loginResponse authUsuario(authRequestModel request)
        {
            loginResponse loginResponse = new loginResponse();
            userResponse userResponse = new userResponse();
            userTokenDto userToken = new userTokenDto();
            string password = encrypt.SHA256(character.remove(request.password));
            usuarioModel user = _db.usuario
                .Include(x => x.persona)
                .Include(x => x.rolUser)
                .Where(x => x.contrasena == request.user && x.contrasena == password).FirstOrDefault();

            userResponse = _mapp.Map<usuarioModel, userResponse>(user);
            userToken = _mapp.Map<usuarioModel, userTokenDto>(user);
            loginResponse.user = userResponse;
            if (user.estado == false)
            {
                return loginResponse;
            }
            if (user == null)
            {
                return loginResponse;
            }
            loginResponse.token = oToken.getToken(userToken, 15, userResponse.rolUser);
            return loginResponse;
        }
    }
}
