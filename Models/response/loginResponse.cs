using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.response
{
    public class loginResponse
    {
        public string token { get; set; }
        public userResponse user { get; set; }
    }
}
