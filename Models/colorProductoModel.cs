﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models
{
    [Table("colorProducto")]
    public class colorProductoModel
    {
        [Key]
        public Int64 id { get; set; }
        public int id_producto { get; set; }
        public int stock { get; set; }
        public string colorName { get; set; }
        public string colorCode { get; set; }

        [ForeignKey("id_producto"),JsonIgnore]
        public virtual productoModel? producto { get; set; }
    }
}
