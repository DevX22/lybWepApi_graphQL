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
            userTokenDto UToken = new userTokenDto();
            string password = encrypt.SHA256(character.remove(request.password));
            clienteModel user = _db.cliente
                .Include(x => x.persona)
                .Where(x => x.usser == request.user && x.contrasena == password).FirstOrDefault();

            userResponse = _mapp.Map<clienteModel,userResponse>(user);
            UToken = _mapp.Map<clienteModel, userTokenDto>(user);
            loginResponse.user = userResponse;
            if (user.estado == false)
            {
                return loginResponse;
            }
            if (user == null)
            {
                return loginResponse;
            }
            loginResponse.token = oToken.getToken(UToken, 15,null);
            return loginResponse;
        }
    }
}
