using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APIshop.Models.Procedures
{
    public class get_productos
    {
        [Key]
        public int id_producto { get; set; }

        [StringLength(100)]
        public string nombre_producto { get; set; }

        public int? cantidad_unidades { get; set; }

        public double? precio_unidad { get; set; }

        public int? estado { get; set; }

    }
}