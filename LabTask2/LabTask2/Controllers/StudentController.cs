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
            return View();
        }
        [HttpPost]
       
        public ActionResult Index(Student s)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Success"); 
            }

            return View(s); 
        }
    }
}