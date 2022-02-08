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
                StudentEntities ss = new StudentEntities();
                ss.Students.Add(s);
                ss.SaveChanges();
                return RedirectToAction("AllstudentList");
            }
            return View();
        }

        public ActionResult AllstudentList()
        {
            StudentEntities ss = new StudentEntities();
           var data= ss.Students.ToList();
            return View(data);
        }

        public ActionResult Discount()
        {
            
            StudentEntities ss = new StudentEntities();
            var datas = ss.Students.ToList();
            String year = DateTime.Now.Year.ToString();
            var data = (from s in datas where (int.Parse(year)-int.Parse(s.dob.Substring(s.dob.Length-4)))> 40 &&
                        float.Parse(s.cgpa) > 3.50
                        select s);
 
            ViewBag.name = data;
            return View();
        }
        public ActionResult Scholarship()
        {
            
            StudentEntities ss = new StudentEntities();
            var datas = ss.Students.ToList();
            var data = (from s in datas where float.Parse(s.cgpa) > 3.75 select s);
            ViewBag.name = data;
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            StudentEntities ss = new StudentEntities();
            var students = (from s in ss.Students
                            where s.id == id
                            select s).FirstOrDefault();
            return View(students);
        }
        [HttpPost]
        public ActionResult Edit(Student edit)
        {
            StudentEntities ss = new StudentEntities();
            var students = (from s in ss.Students
                            where s.id == edit.id
                            select s).FirstOrDefault();

            ss.Entry(students).CurrentValues.SetValues(edit);
            ss.SaveChanges();
            return RedirectToAction("AllstudentList");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            StudentEntities ss = new StudentEntities();
            var students = (from s in ss.Students
                            where s.id == id
                            select s).FirstOrDefault();
            return View(students);
        }
        [HttpGet]
        public ActionResult Sure(int id )
        {
            StudentEntities ss = new StudentEntities();
            var students = (from s in ss.Students
                            where s.id == id
                            select s).FirstOrDefault();

            ss.Students.Remove(students);
            ss.SaveChanges();
            return RedirectToAction("AllstudentList");
        }
    }
}