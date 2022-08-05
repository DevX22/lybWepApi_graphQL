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
    public class authClienteLogic
    {
        private readonly authClienteRepository _repo = new authClienteRepository(); 
        public loginResponse authCliente(authRequestModel request)
        {
            loginResponse response = _repo.authClient(request);
            return response;
        }
    }
}
