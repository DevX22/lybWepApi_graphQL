﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.dto
{
    public class personaDto
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellidoPaterno { get; set; }
        public string? apellidoMaterno { get; set; }
        public string tipoDocumento { get; set; }
        [MaxLength(12)]
        public string numeroDocumento { get; set; }
        [MaxLength(9)]
        public string celular { get; set; }
        [MaxLength(9)]
        public string? whatsApp { get; set; }
        public string? correo { get; set; }
        public DateTime? fechaNacimiento { get; set; }
    }
}
