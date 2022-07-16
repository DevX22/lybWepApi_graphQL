using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("color")]
    public class colorModel
    {
        [Key]
        public int id { get; set; }
        public string colorNombre { get; set; }
        public string colorCodigo { get; set; }
    }
}
