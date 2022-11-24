using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.request
{
    public class updatePasswordRequest
    {
        public int id_usser { get; set; }
        public string oldPassword { get; set; }
        public string newPassword { get; set; }
        public string repeatPassword { get; set; }
    }
}
