using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LabTask1.Models;

namespace LabTask1.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult Education()
        {
            Education ssc = new Education()
            {
               Degree="SSC",
               Institute="GHMI",
               Year="2018"
            };
            Education hsc = new Education()
            {
                Degree = "HSC",
                Institute = "AKMCC",
                Year = "2020"
            };

            Education[] edu = new Education[] { ssc, hsc };

            return View(edu);
        }
        public ActionResult Projects()
        {
            return View();
        }
        public ActionResult Reference()
        {
            return View();
        }
       

    }
}