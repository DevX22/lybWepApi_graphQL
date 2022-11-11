using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("timeToken")]
    public class timeTokenModel
    {
        public int minutos { get; set; }
    }
}
