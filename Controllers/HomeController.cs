using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebNutFactory.Models;

namespace WebNutFactory.Controllers
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
         public IActionResult HomePage()
        {
            return View();
        }


        public IActionResult Products()
        {
            FactoryContext con = new FactoryContext();
            ProductsOfFactory Product = new ProductsOfFactory() { ProductName = "Phone android", Price = 5000 };
            con.Ords.Add(Product);
            con.SaveChanges();

            return View(Product);
        }

        public IActionResult Orders()
        {
            FactoryContext con = new FactoryContext();
            Order Ord = new Order() { OrderID = 1, oStatus = "done", InvetoryID = 23, TotalPrice = 345 };
           // con.Ords.Add(Ord);
            con.SaveChanges();

            return View(Ord);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
