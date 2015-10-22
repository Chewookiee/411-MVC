using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using FoamMVC.BLL.CRUD.CategoryOperations;
using FoamMVC.ViewModels;

namespace FoamMVC.Controllers
{
    public class AdminController : Controller
    {
        private CategoryBLL _categoryBll = new CategoryBLL();

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DisplayCategory(int id)
        {
            CategoryDisplayViewModel categoryToDisplay = _categoryBll.GetSingleCategoryByIDForDisplay(id);

            return View(categoryToDisplay);
        }

        [HttpGet]
        public ActionResult CreateCategory()
        {
            CategoryCreateViewModel viewModel = new CategoryCreateViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult CreateCategory(CategoryCreateViewModel categoryCreate)
        {
            if (!ModelState.IsValid)
            {
                return View(categoryCreate);
            }
             
            // Call the BLL and send it the model categoryCreate to be created
            int idOfCategoryCreated = _categoryBll.CreateCategory(categoryCreate);
            return RedirectToAction("DisplayCategory", new RouteValueDictionary(
                new { controller = "Admin", action = "DisplayCategory", Id = idOfCategoryCreated }));
        }

        public ActionResult CreateCompany()
        {
            return View(new CompanyCreateViewModel());
        }

        [HttpPost]
        public ActionResult CreateCompany(CompanyCreateViewModel companyCreate)
        {
            if (!ModelState.IsValid)
            {
                return View(companyCreate);
            }

            return new JsonResult();
        }

        [HttpPost]
        public ActionResult CreatePalletGroup(PalletGroupCreateViewModel_Old palletGroupCreate)
        {
            if (!ModelState.IsValid)
            {
                return View(palletGroupCreate);
            }

            return new JsonResult();
        }
    }
}