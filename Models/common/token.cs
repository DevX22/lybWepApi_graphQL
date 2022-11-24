using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Models.dto;
using Models.response;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace Models.common
{
    public class token
    {
        public string getToken(userTokenDto user, int minExpire,string? rol)
        {
            if (rol == null||rol==string.Empty)
            {
                rol = "";
            }
            if (user.id_rolUsuario == 0 || user.id_rolUsuario == null)
            {
                user.id_rolUsuario = 0;
            }
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,globalVar.JWTSubject),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat,DateTime.UtcNow.ToString()),
                new Claim("id",user.id.ToString()),
                new Claim("user",user.usser),
                new Claim("id_rol",user.id_rolUsuario.ToString()),
                new Claim("rol",rol),
                new Claim(ClaimTypes.Role,rol),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(globalVar.JWTKey));
            var SingIn=new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                globalVar.JWTIssuer,
                globalVar.JWTAudience,
                claims,
                expires: DateTime.UtcNow.AddMinutes(minExpire),
                signingCredentials:SingIn
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
