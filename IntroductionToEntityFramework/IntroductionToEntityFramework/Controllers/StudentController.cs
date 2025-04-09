using IntroductionToEntityFramework.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntroductionToEntityFramework.Controllers
{
    public class StudentController : Controller
    {
        MyDatabsaeEntities db = new MyDatabsaeEntities();
        // GET: Student
        public ActionResult Index()
        {
            //listing all the students
            var data = db.Students.ToList();

            return View(data);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student s)
        {
            //no validationnn
           
            db.Students.Add(s);
           // db.SaveChanges();

            if(db.SaveChanges()>0)
            {
                TempData["msg"] = "Student Added";
                return RedirectToAction("Index");
            }
            TempData["msg"] = "Student is not Added";
            return View(s);
        }
        public ActionResult Edit(int id)
        {
            var student = db.Students.Find(id);
            return View(student);
        }
        [HttpPost]
        public ActionResult Edit(Student s)
        {
            var exobj = db.Students.Find(s.Id);
            exobj.Name = s.Name;
            exobj.Dob = s.Dob;
            if (db.SaveChanges() > 0)
            {

                TempData["Msg"] = "Student Updated";
                return RedirectToAction("Index");
            }
            return View(s);
        }
       
        [HttpGet]
        public ActionResult Delete(Student s)
        {
            var exobj = db.Students.Find(s.Id);
            db.Students.Remove(exobj);

            if (db.SaveChanges() > 0)
            {

                TempData["Msg"] = "Student Deleted";
                return RedirectToAction("Index");
            }
            return View(s);
        }
    }
}