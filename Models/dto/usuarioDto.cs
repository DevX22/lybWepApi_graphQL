using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.dto
{
    public class usuarioDto
    {
        public int id { get; set; }
        public string usser { get; set; }
        public string email { get; set; }
        public int id_persona { get; set; }
        public int id_rolUsuario { get; set; }
        public string avatar { get; set; }
        public string direccion { get; set; }
        public string condicion { get; set; }
        public bool estado { get; set; }

        [ForeignKey("id_persona")]
        public virtual personaModel persona { get; set; }

        [ForeignKey("id_rolUsuario")]
        public virtual rolUsuarioModel rolUser { get; set; }
    }
}
