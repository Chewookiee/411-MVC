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
            return View(_stagedItemBll.Get());
        }

        [HttpGet]
        public ActionResult CompleteStaged(string UPC)
        {
            return View(_stagedItemBll.GetItemWithStagedItemReflectedOnItByUPC(UPC));
        }

        [HttpPost]
        public ActionResult CompleteStaged(ItemViewModel viewModel)
        {
            _itemBll.CreateItem(viewModel);
            _stagedItemBll.DeleteStagedItem(viewModel.UPC);

            return RedirectToAction("Index");
        }
    }
}