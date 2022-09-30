using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("rolUsuario")]
    public class rolUsuarioModel
    {
        [Key]
        public int id { get; set; }
        public int pesoRol { get; set; }
        public string rolUsuario { get; set; }
    }
}
