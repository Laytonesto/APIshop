using APIshop.Models.Procedures;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WEBshop.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync("http://localhost/APIshop/api/Productos/Get");
            var productosList = JsonConvert.DeserializeObject<List<get_productos>>(json);
            return View(productosList);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public async Task<ActionResult> Login(usuario usuario)
        {
            var response = string.Empty;

            var payload = "{\"correo\": \"" + usuario.correo+ "\",\"password\": \"" + usuario.password+ "\"}";
            HttpContent c = new StringContent(payload, Encoding.UTF8, "application/json");
            var httpClient = new HttpClient();
            var result = await httpClient.PostAsync(new Uri("http://localhost/APIshop/api/Usuarios/Login"), c );
            

            if (result.IsSuccessStatusCode)
            {
                response = result.StatusCode.ToString();
            }

            return View();
        }

        public async Task<ActionResult> Registro(usuario usuario)
        {
            var response = string.Empty;

            var payload = "{\"nombre\": \"" + usuario.nombre + "\",\"genero\": \"" + usuario.genero + "\",\"correo\": \"" + usuario.correo + "\",\"password\": \"" + usuario.password + "\"}";
            HttpContent c = new StringContent(payload, Encoding.UTF8, "application/json");
            var httpClient = new HttpClient();
            var result = await httpClient.PostAsync(new Uri("http://localhost/APIshop/api/Usuarios/Registro"), c);


            if (result.IsSuccessStatusCode)
            {
                response = result.StatusCode.ToString();
            }
            var loginList = JsonConvert.DeserializeObject<List<usuario>>(response);

            return View();


        }
    }
}