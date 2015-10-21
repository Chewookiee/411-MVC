using FoamMVC.DAL.CRUD.CategoryOperations;
using FoamMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoamMVC.DAL.CRUD.ItemOperations;

namespace FoamMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            IItemCRUD x = new ItemCRUD();
            ApplicationDbContext db = new ApplicationDbContext();
            var item = x.Get();
            return View();
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