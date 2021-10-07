using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using APIshop.Models;
using APIshop.Models.Procedures;

namespace APIshop.Repository
{
    public class UsuariosRepository
    {
        public void push_Usuario(string nombre, string genero, string correo, string password)
        { 
            using (var ctx = new EFShop()){
                ctx.Database.ExecuteSqlCommand("register_usuario @p0, @p1, @p2, @p3", nombre, genero, correo, password);
            }
        }

        public List<usuario> login(string correo, string pass)
        {
            using (var ctx = new EFShop())
            {
                return ctx.Database.SqlQuery<usuario>("get_usuario @p0, @p1", correo, pass)
                    .ToList();
            }
        }
    }
}