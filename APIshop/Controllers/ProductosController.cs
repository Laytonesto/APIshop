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
    public class ProductosController : ApiController
    {
        // GET api/productos
        public IEnumerable<get_productos> Get()
        {
            var pr = new ProductosRepository();

            return pr.get_productos();
        }


        // POST: api/productos
        [ResponseType(typeof(get_productos))]
        public IHttpActionResult Estado(get_productos get_productos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pr = new ProductosRepository();
            


            return CreatedAtRoute("DefaultApi", new { id = get_productos.id_producto }, 
                pr.estado_producto(get_productos.id_producto, get_productos.estado));
        }


        // POST: api/productos
        [ResponseType(typeof(get_productos))]
        public IHttpActionResult Postproducto(get_productos get_productos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pr = new ProductosRepository();

            pr.insert_producto(get_productos.nombre_producto,get_productos.cantidad_unidades,get_productos.precio_unidad);


            return CreatedAtRoute("DefaultApi", new { id = get_productos.id_producto }, get_productos);
        }

    }



}
