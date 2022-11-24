using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.response
{
    public class ResponseBack
    {
        public bool isSuccess { get; set; } = true;
        public string DisplayMessage { get; set; }
        //public List<string> ErrorMessage { get; set; }
    }
}
