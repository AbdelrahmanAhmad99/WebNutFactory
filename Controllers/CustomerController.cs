using Microsoft.AspNetCore.Mvc;
using WebNutFactory.Models;

namespace WebNutFactory.Controllers
{
    public class CustomerController : Controller
    {
        //In Customer Controller Name Action (RegistrationForm) -> Name View (RegistrationForm) in other page to Login Customer .
        public IActionResult RegistrationForm()
        {
            return View();
        }

        //In Customer Controller Name Action (LoginForm) -> Name View (LoginForm) in other page to Login Customer .
        public IActionResult LoginForm()
        {
            return View();
        }

        //In Customer Controller Name Action (Products) -> Name View (Products) in other page to buy Products.
        public IActionResult Products()
        {
            return View();
        }

        //In Customer Controller Name Action (Orders) -> Name View (Orders) in other page  to watch your Orders .
        public IActionResult Orders()
        {
            return View();
        }

       [HttpPost]
        public IActionResult SubmitForm(Customer model)
        {
            if (ModelState.IsValid)
            {
                // Process the data (e.g., save to a database, send an email, etc.)
                ViewData["Massage"] = $"welcome {model.FirstName} in our Factory";

                FactoryContext con = new FactoryContext();
                con.Customers.Add(model);
                con.SaveChanges();

                Customer c = con.Customers.ToList()[con.Customers.Count() - 1];

                ViewData["ID"] = c.CustomerID;
                ViewData["Password"] = c.CPassword;

                return View("Index");
            }

            // If validation fails, redisplay the form with validation messages
            return View("RegistrationForm");
        }

       [HttpPost]
        public IActionResult SubmitForm2(Customer model)
        {
            FactoryContext con = new FactoryContext();
            var CData = con.Customers.Find(model.CustomerID);
            if (CData != null)
            {

                if (CData.CPassword == model.CPassword) return View("Products", CData);
                return View("LoginForm");
            }
            // If validation fails, redisplay the form with validation messages
            return View("LoginForm");
        }
    }
}
