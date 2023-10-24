using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebTest.Models;

namespace WebTest.Controllers
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
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Sumar([FromBody] SumaRequest request)
        {
            int suma = request.Numero1 + request.Numero2 + request.Numero3;
            var resultado = new { suma = suma };
            return Json(resultado);
        }

        public class SumaRequest
        {
            public int Numero1 { get; set; }
            public int Numero2 { get; set; }
            public int Numero3 { get; set; }
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}