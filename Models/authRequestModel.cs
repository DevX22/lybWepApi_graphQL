using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class authRequestModel
    {
        [Required]
        public string user { get; set; }
        [Required]
        public string password{ get; set; }
    }
}
