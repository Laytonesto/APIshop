using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using APIshop.Models.Procedures;
using APIshop.Repository;

namespace APIshop.Controllers
{
    public class UsuariosController : ApiController
    {

        // POST: api/productos
        [ResponseType(typeof(usuario))]
        public IHttpActionResult Register(usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new UsuariosRepository();
            user.push_Usuario(usuario.nombre,usuario.genero,usuario.correo,usuario.password);


            return CreatedAtRoute("DefaultApi", new { id = usuario.id_usuario }, usuario);
        }

        // Post: api/login
        [ResponseType(typeof(usuario))]
        public IHttpActionResult Login(usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = new UsuariosRepository();

            return CreatedAtRoute("DefaultApi", new { id = usuario.id_usuario }, user.login(usuario.correo, usuario.password));
        }
    }
}
