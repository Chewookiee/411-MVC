using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoamMVC.BLL.CRUD.PalletDescriptorOperation;
using FoamMVC.ViewModels;

namespace FoamMVC.Controllers.Admin
{
    public class AdminPalletDescriptorsController : Controller
    {
        private readonly PalletDescriptorBLL _descriptorBLL;

        public AdminPalletDescriptorsController()
        {
            _descriptorBLL = new PalletDescriptorBLL();
        }

        public ActionResult Index()
        {
            return View(_descriptorBLL.Get());
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(_descriptorBLL.GetForUpdate(id));
        }

        [HttpPost]
        public ActionResult Edit(PalledDescriptorUpdateViewModel viewModel)
        {
            _descriptorBLL.Update(viewModel);

            return RedirectToAction("Index");
        }
    }
}