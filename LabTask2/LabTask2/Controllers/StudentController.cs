using LabTask2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabTask2.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.IsValid = ModelState.IsValid;

            return View(new Student());
        }
        [HttpPost]
        public ActionResult Index(Student s)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("About", "Home");
            }
            return View(s);
        }

    }
}