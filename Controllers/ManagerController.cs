using Microsoft.AspNetCore.Mvc;
using WebNutFactory.Models;

namespace WebNutFactory.Controllers
{
    public class ManagerController : Controller
    {
         public IActionResult Login()
        {
            return View();
        }

         public IActionResult AddEmployee()
        {
            return View();
        }

        public IActionResult AddInventory()
        {
            return View();
        }


        public IActionResult Update()
        {
            return View();
        }

        public IActionResult DisplayProduct()
        {
            return View();
        }

        public ActionResult DisplayInventories()
        {
            using FactoryContext con = new FactoryContext();

            var inv = from a in con.Inventories select a;


            return View(inv.ToList());
        }

         public ActionResult DisplayEmployees()
        {
            using FactoryContext con = new FactoryContext();

            var Emp = con.Employees.ToList();

            return View(Emp);
        }

        [HttpPost]
        public IActionResult SubmitForm3(LoginManager model)
        {
            if (model?.UserName == "admin" && model.Password == "admin") return View("choose");

            return View("Login");
        }

         [HttpPost]
        public IActionResult SubmitForm(Inventory model)
        {
            if (ModelState.IsValid)
            {
                FactoryContext con = new FactoryContext();
                con.Add(model);
                con.SaveChanges();

                var Inv = con.Inventories.ToList();

                return View("DisplayInventories", Inv);
            }
 
            return View("AddInventory");
        }
       
        [HttpPost]
        public IActionResult SubmitForm5(Employee model)
        {
            model.StoreID = 1;
            if (ModelState.IsValid)
            {

                FactoryContext con = new FactoryContext();
                con.Add(model);
                con.SaveChanges();

                var Emp = con.Employees.ToList();

                return View("DisplayEmployees", Emp);
            }

  
            return View("AddEmployee");
        }
    }
}
