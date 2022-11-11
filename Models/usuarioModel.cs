using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models
{
    [Table("usuario")]
    public class usuarioModel
    {
        [Key]
        public int id { get; set; }
        public string usser { get; set; }
        public string email { get; set; }
        public string contrasena { get; set; }
        public int id_persona { get; set; }
        public int id_rolUsuario { get; set; }
        public string avatar { get; set; }
        public string direccion { get; set; }
        public string condicion { get; set; }
        public bool estado { get; set; }

        [ForeignKey("id_persona")]
        public virtual personaModel persona { get; set; }

        [ForeignKey("id_rolUsuario"),JsonIgnore]
        public virtual rolUsuarioModel? rolUser { get; set; }
    }
}
