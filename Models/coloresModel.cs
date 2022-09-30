using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("colores")]
    public class coloresModel
    {
        [Key]
        public int id { get; set; }
        public string colorName { get; set; }
        public string colorCode { get; set; }
    }
}
