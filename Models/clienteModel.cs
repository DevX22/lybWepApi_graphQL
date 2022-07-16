using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models
{
    public class clienteModel
    {
        public int id { get; set; }
        public string usser { get; set; }
        public string direccionEnvio { get; set; }
        public string direccionCasa { get; set; }
        public int id_avatar { get; set; }
        public int id_persona { get; set; }
        public bool estado { get; set; }

        [JsonIgnore,ForeignKey("id_avatar")]
        public virtual avatarModel avatar { get; set; }

        [ForeignKey("id_persona")]
        public virtual personaModel persona { get; set; }
    }
}
