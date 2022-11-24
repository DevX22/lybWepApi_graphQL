using AutoMapper;
using Models;
using Models.dto;
using Models.mapperConfig;
using Models.request;
using Models.response;
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
    public class usuarioLogic : usuarioRepository
    {
        private readonly IMapper _map = mapper.Go();

        public async Task<usuarioModel> CreateAsyncUsser(usuarioModel request)
        {
            request.usser = character.remove(request.usser.ToUpper());
            request.contrasena = encrypt.SHA256(character.remove(request.contrasena));
            await CreateAsync(request);
            return request;
        }

        public async Task<List<usuarioDto>> listDetaildAsyncUsser()
        {
            List<usuarioDto> response = _map.Map<List<usuarioDto>>(await listDetaildAsync());
            return response;
        }

        public async Task<bool> existsUsuarioAsyncUsser(string usser)
        {
            return await existsUsuarioAsync(usser);
        }

        public async Task<ResponseBack> updatePasswordAsyncUsser(updatePasswordRequest req)
        {
            ResponseBack _res = new();
            string oldPass, newPass;
            if (req == null)
            {
                _res.isSuccess = false;
                _res.DisplayMessage = "Datos obligatorios";
                return _res;
            }
            if (req.newPassword.Trim() != req.repeatPassword.Trim())
            {
                _res.isSuccess = false;
                _res.DisplayMessage = "Repita la nueva contraseña";
                return _res;
            }
            usuarioModel res = await GetByIdAsync(req.id_usser);
            oldPass = encrypt.SHA256(character.remove(req.oldPassword));
            newPass = encrypt.SHA256(character.remove(req.newPassword));
            if (res.contrasena != oldPass)
            {
                _res.isSuccess = false;
                _res.DisplayMessage = "Contraseña anterior incorrecta";
                return _res;
            }
            res.contrasena = newPass;
            await UpdateAsync(res);
            _res.DisplayMessage = "Contraseña actualizada existosamente";
            return _res;
        }

        //new password -- recuperar password
    }
}
