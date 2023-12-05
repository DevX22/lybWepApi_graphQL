﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("tipoComprobante")]
    public class tipoComprobanteModel
    {
        [Key]
        public int id { get; set; }
        public string comprobante { get; set; }
        public string abrev { get; set; }

    }
}
