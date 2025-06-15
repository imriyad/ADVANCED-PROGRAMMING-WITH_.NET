using System.Web.Mvc;
using StudentManagement.BLL;
using StudentManagement.DAL.Models;

namespace StudentManagement.Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentService _service = new StudentService();

        public ActionResult Index()
        {
            var students = _service.GetAllStudents();
            return View(students);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _service.AddStudent(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }
    }
}
