using Models;
using Models.response;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class authUsuarioLogic
    {
        private readonly authUsuarioRespository _logic = new authUsuarioRespository();

        public loginResponse authUsuario(authRequestModel request)
        {
            loginResponse response=_logic.authUsuario(request);
            return response;
        }
    }
}
