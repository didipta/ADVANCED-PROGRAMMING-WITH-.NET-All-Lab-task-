using LabTsak_product_.Models;
using LabTsak_product_.Models.database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace LabTsak_product_.Controllers
{
    
    public class productController : Controller
    {
        string json;
        List<Addtocartss> cart = new List<Addtocartss>();
        ProductEntities ss = new ProductEntities();
        [HttpGet]
        // GET: product
        public ActionResult Home()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create (Product s)
        {
            if(ModelState.IsValid)
            {
                
                ss.Products.Add(s);
                ss.SaveChanges();
                return RedirectToAction("AllProducttList");
            }
            return View();
        }
        [HttpGet]
        public ActionResult AllProducttList()
        {
            
            var data = ss.Products.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult Allproduct()
        {
            
            var data = ss.Products.ToList();
            return View(data);
        }
        [HttpPost]
        public ActionResult Allproduct(Addtocartss A)
        {
            if (Session["cards"]==null)
                {
                    cart.Add(A);
                    json = new JavaScriptSerializer().Serialize(cart);
                    Session["cards"] = json;
                return RedirectToAction("myorder");
            }
            else
            {
                string cart = Session["cards"].ToString();
                var D = new JavaScriptSerializer().Deserialize<List<Addtocartss>>(cart);
                D.Add(A);
                json = new JavaScriptSerializer().Serialize(D);
                Session["cards"] = json;
                return RedirectToAction("myorder");
            }
               
            return View();
        }
        [HttpGet]
        public ActionResult myorder()
        {

            if(Session["cards"]!=null)
            {
                string cart = Session["cards"].ToString();
                var D = new JavaScriptSerializer().Deserialize<List<Addtocartss>>(cart);
                return View(D);
            }
            return View();

        }
        [HttpPost]
        public ActionResult Orderproduct()
        {

            int i = 0;
            string cart = Session["cards"].ToString();
            var D = new JavaScriptSerializer().Deserialize<List<Addtocartss>>(cart);
            myorder order = new myorder();
            var x= order.Order_id;
            order.total_order = D.Count.ToString() ;
            ss.myorders.Add(order);
            ss.SaveChanges();
            foreach (var item in D)
            {
                Addtocart addcart = new Addtocart();
                addcart.order_id = order.Order_id;
                addcart.p_name = item.pname;
                addcart.p_qty = item.pqty;
                addcart.p_price = item.pprice;
                ss.Addtocarts.Add(addcart);
                ss.SaveChanges();
            }
            
            Session["cards"] = null;
            return RedirectToAction("Myallorder");
            return View();

        }
        [HttpGet]
        public ActionResult Myallorder()
        {
            var data=ss.myorders.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult Showdetails(int id)
        {
            var addtocart= (from s in ss.Addtocarts
                            where s.order_id == id
                            select s).ToList();
            return View(addtocart);
        }

    }
}