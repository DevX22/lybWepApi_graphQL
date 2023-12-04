using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("salida")]
    public class salidaProductoModel
    {
        [Key]
        public int id { get; set; }
        public int id_usuario { get; set; }
        public string? usuario { get; set; }
        public int? id_establecimiento { get; set; }
        public string? establecimiento { get; set; }
        public DateTime fecha { get; set; }
    }
}
