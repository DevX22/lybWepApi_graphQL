using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.request
{
    public class newPasswordRequest
    {
        public int id_usser { get; set; }
        public string password { get; set; }
        public string repeatPassword { get; set; }
    }
}
