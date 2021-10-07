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

        public List<get_productos> estado_producto(int id_producto, int? estado)
        {
            using (var ctx = new EFShop())
            {
                return ctx.Database.SqlQuery<get_productos>("estado_producto @p0, @p1", id_producto, estado)
                     .ToList();
            }
        }

        public void insert_producto(string nombre, int? cantidad, double? precio)
        {
            using (var ctx = new EFShop())
            {
                ctx.Database.ExecuteSqlCommand("insert_producto @p0, @p1, @p2", nombre, cantidad, precio);
            }
        }
    }
}