using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.dto
{
    public class clienteDto
    {
        public int id { get; set; }
        public string usser { get; set; }
        public string? direccionEnvio { get; set; }
        public decimal? destinoLat { get; set; }
        public decimal? destinoLng { get; set; }
        public string? direccionCasa { get; set; }
        public string? avatar { get; set; }
        public int id_persona { get; set; }
        public bool estado { get; set; }

        [ForeignKey("id_persona")]
        public virtual personaModel persona { get; set; }
    }
}
