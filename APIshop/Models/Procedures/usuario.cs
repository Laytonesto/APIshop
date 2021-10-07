using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace APIshop.Models.Procedures
{
    public partial class usuario
    {

        [Key]
        public int id_usuario { get; set; }

        public int? rol { get; set; }

        [StringLength(100)]
        public string nombre { get; set; }

        [StringLength(10)]
        public string genero { get; set; }

        [StringLength(100)]
        public string correo { get; set; }

        [StringLength(1000)]
        public string password { get; set; }


    }
}