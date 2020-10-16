using MyBooksCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBooksCart.Controllers
{
    public class HomeController : Controller
    {
        private BOOKSDBEntities db = new BOOKSDBEntities();

        public ActionResult Index(int? categoryId)
        {
            ViewBag.categoryList = db.Categories.ToList();
            try
            {
                if (categoryId != null)
                {
                    return View();
                }
                else
                {
                    var homeProducts = db.Products
                        .Join(db.Categories, p => p.Category_Id, c => c.Id, (p, c) => p)
                        .Where(c => c.IsPublic == true)
                        .OrderByDescending(c => c.Id).ToList();
                    return View(homeProducts);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}