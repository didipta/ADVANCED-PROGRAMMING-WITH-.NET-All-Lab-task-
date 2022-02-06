using Labtask_3.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Labtask_3.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        [HttpGet]
        public ActionResult Create()
        {
            return View(new Student());
        }
        public ActionResult Create (Student s)
        {
            if(ModelState.IsValid)
            {
                StudentEntities1 ss = new StudentEntities1();
                ss.Students.Add(s);
                ss.SaveChanges();
                return RedirectToAction("AllstudentList");
            }
            return View();
        }

        public ActionResult AllstudentList()
        {
            StudentEntities1 ss = new StudentEntities1();
           var data= ss.Students.ToList();
            return View(data);
        }

        public ActionResult Discount()
        {
            
            StudentEntities1 ss = new StudentEntities1();
            var datas = ss.Students.ToList();
            String year = DateTime.Now.Year.ToString();
            var data = (from s in datas where (int.Parse(year)-int.Parse(s.dob.Substring(s.dob.Length-4)))> 40 select s);
 
            ViewBag.name = data;
            return View();
        }
        public ActionResult Scholarship()
        {
            
            StudentEntities1 ss = new StudentEntities1();
            var datas = ss.Students.ToList();
            var data = (from s in datas where float.Parse(s.cgpa) > 3.75 select s);
            ViewBag.name = data;
            return View();
        }
    }
}