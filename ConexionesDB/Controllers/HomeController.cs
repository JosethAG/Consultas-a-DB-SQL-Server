using ConexionesDB.Architectur;
using ConexionesDB.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Diagnostics;

namespace ConexionesDB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            DataTable tusers = Conection.ExcSPList("ListUsers"); //Se ejecuta el proceso
            string userJson = JsonConvert.SerializeObject(tusers);
            var userList = JsonHelppers.DeserializeSimple<IEnumerable<User>>(userJson);
            return View(userList); //Se envia el IEnumerable como model
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
