using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("destino")]
    public class destinoModel
    {
        [Key]
        public int id { get; set; }
        public int direccion { get; set; }
        public int latitud { get; set; }
        public int longitud { get; set; }
    }
}
