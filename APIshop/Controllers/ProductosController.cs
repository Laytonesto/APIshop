using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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
    }
}
