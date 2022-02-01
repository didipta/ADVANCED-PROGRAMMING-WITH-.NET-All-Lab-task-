using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Labtask_2_product_.Models;

namespace Labtask_2_product_.Controllers
{
    public class productsController : Controller
    {
        // GET: products
        public ActionResult Index()
        {
            List<products> product = new List<products>();
            var p = new products()
            {
                id = 12020,
                name = "Iphone 13"

            };
              var p1 = new products()
            {
                id = 12022,
                name = "Iphone 13 pro"

              };
            var p3 = new products()
            {
                id = 12024,
                name = "Iphone 12"

            };
            var p4 = new products()
            {
                id = 12026,
                name = "Iphone 12 pro"

            };
            var p5 = new products()
            {
                id = 12027,
                name = "Iphone 11"

            };
            var p6 = new products()
            {
                id = 12029,
                name = "Iphone 11 pro"

            };
            var p7 = new products()
            {
                id = 13029,
                name = "Poco X2"

            };
            var p8 = new products()
            {
                id = 14029,
                name = "Vivo Y11"

            };
            var p9 = new products()
            {
                id = 19029,
                name = "Note 10 lite"

            };
            product.Add(p);
            product.Add(p1);
            product.Add(p3);
            product.Add(p4);
            product.Add(p5);
            product.Add(p6);
            product.Add(p7);
            product.Add(p8);
            product.Add(p9);
 
            return View(product);
        }
    }
}