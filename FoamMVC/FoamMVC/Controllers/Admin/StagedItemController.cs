using System;
using System.Web.Mvc;
using FoamMVC.BLL.CRUD.ItemOperations;
using FoamMVC.BLL.CRUD.StagedItemsOperations;
using FoamMVC.ViewModels;

namespace FoamMVC.Controllers.Admin
{
    public class StagedItemController : Controller
    {
        private readonly StagedItemBLL _stagedItemBll;
        private readonly ItemBLL _itemBll;

        public StagedItemController()
        {
            _stagedItemBll = new StagedItemBLL();
            _itemBll = new ItemBLL();
        }
        // GET: StagedItem
        public ActionResult Index()
        {
            return View(_stagedItemBll.GetViewModels());
        }

        [HttpGet]
        public ActionResult CompleteStaged(string UPC)
        {
            return View(_stagedItemBll.GetItemWithStagedItemReflectedOnItByUPC(UPC));
        }

        [HttpPost]
        public ActionResult CompleteStaged(ItemViewModelStringItemPrice viewModel)
        {
            var newViewModel = new ItemViewModel
            {
                ItemID = viewModel.ItemID,
                PalletGroupID = viewModel.PalletGroupID,
                CompanyID = viewModel.CompanyID,
                CategoryID = viewModel.CategoryID,
                UPC = viewModel.UPC,
                IsFeautured = viewModel.IsFeautured,
                ItemPrice = Convert.ToDouble(viewModel.ItemPrice.Replace("$", String.Empty)),
                ImagePath = viewModel.ImagePath,
                Name = viewModel.Name
            };
            _itemBll.CreateItem(newViewModel);
            _stagedItemBll.DeleteStagedItem(viewModel.UPC);

            return RedirectToAction("Index");
        }
    }
}