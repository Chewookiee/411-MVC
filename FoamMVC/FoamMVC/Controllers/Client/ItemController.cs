using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FoamMVC.BLL.CRUD.ItemOperations;

namespace FoamMVC.Controllers.Client
{
    public class ItemController : Controller
    {
        private readonly ItemCRUDBLL _itemCRUD = new ItemCRUDBLL();
        // GET: Item
        public ActionResult List()
        {
            return View(_itemCRUD.GetAllItemsForClient());
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(_itemCRUD.GetSingleItemForDisplayByID((int)id));
        }
    }
}