using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Labtask_1_cv_.Controllers
{
    public class CvController : Controller
    {
        // GET: Cv
        public ActionResult Home()
        {
            return View();
        }
        public ActionResult Education()
        {
            return View();
        }

        public ActionResult Projects()
        {
            return View();
        }

        public ActionResult References()
        {
            return View();
        }
    }
}