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
        public ActionResult Edit(PalletDescriptorDisplayViewModel.PalledDescriptorUpdateViewModel viewModel)
        {
            _descriptorBLL.Update(viewModel);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new PalletDescriptorViewModel());
        }

        [HttpPost]
        public ActionResult Create(PalletDescriptorViewModel viewModel)
        {
            _descriptorBLL.CreatePalletDescriptor(viewModel);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(_descriptorBLL.Get(id));
        }

        [HttpPost]
        public ActionResult Delete(PalletDescriptorViewModel viewModel)
        {
            _descriptorBLL.Delete(viewModel);
            return RedirectToAction("Index");
        }
    }
}