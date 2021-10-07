using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using APIshop.Models;
using APIshop.Models.Procedures;

namespace APIshop.Repository
{
    public class ProductosRepository
    {
        public List<get_productos> get_productos()
        {
            using (var ctx = new EFShop())
            {
                var estado = 1;
                return ctx.Database.SqlQuery<get_productos>("get_productos @p0", estado)
                    .ToList();
            }
        }
    }
}