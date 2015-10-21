using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoamMVC.BLL.CRUD.ItemOperations;

namespace FoamMVC.Controllers
{
    public class ItemController : Controller
    {
        private readonly ItemCRUDBLL _itemCrud = new ItemCRUDBLL();
        // GET: Item
        public ActionResult Index()
        {
            return View("~/Views/Item/List.cshtml", _itemCrud.GetItemsNameAndID());
        }
    }
}