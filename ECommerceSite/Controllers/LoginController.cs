using ECommerceSite.DTOs;
using ECommerceSite.EF;
using System;
using System.Linq;
using System.Web.Mvc;

namespace PMS.Controllers
{
    public class LoginController : Controller
    {
        ECommerceDBEntities3 db = new ECommerceDBEntities3();

        [HttpGet]
        public ActionResult Login() => View();

        [HttpPost]
        public ActionResult Login(string Uname, string Pass)
        {
            var user = db.Logins.SingleOrDefault(u => u.Username == Uname && u.Password == Pass);
            if (user != null)
            {
                Session["User"] = user;
                return RedirectToAction(user.UserType == "Customer" ? "Index" : "Index", user.UserType == "Customer" ? "Order" : "Employee");
            }
            TempData["Class"] = "danger";
            TempData["Msg"] = "Invalid username or password";
            return View();
        }

        [HttpGet]
        public ActionResult Registration() => View();

        [HttpPost]
        public ActionResult Registration(CustomerDTO cs)
        {
            var data = Convert(cs);
            data.CreatedAt = DateTime.Now;
            db.Customers.Add(data);
            db.SaveChanges();

            db.Logins.Add(new Login
            {
                Username = data.Email,
                Password = data.Password,
                UserId = data.Id,
                UserType = "Customer"
            });
            db.SaveChanges();

            TempData["Class"] = "success";
            TempData["Msg"] = "Registration Successful";
            return RedirectToAction("Login");
        }

        public static Customer Convert(CustomerDTO c) => new Customer
        {
            Name = c.Name,
            Address = c.Address,
            Email = c.Email,
            Password = c.Password
        };
    }
}
