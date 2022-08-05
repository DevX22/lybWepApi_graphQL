using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.response
{
    public class userResponse
    {
        public int id { get; set; }
        public string nombreApellido { get; set; }
        public string usser { get; set; }
        public string email { get; set; }
        public string avatar { get; set; }
        public string rolUser { get; set; }
        public bool estado { get; set; }
    }
}
