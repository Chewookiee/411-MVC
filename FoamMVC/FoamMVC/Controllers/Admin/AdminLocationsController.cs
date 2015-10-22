using FoamMVC.BLL.CRUD.LocationOperations;
using FoamMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FoamMVC.Controllers.Admin
{
    public class AdminLocationsController : Controller
    {
        private LocationCRUDBLL _locationCRUDBLL;

        public AdminLocationsController()
        {
            _locationCRUDBLL = new LocationCRUDBLL();
        }
        
        public ActionResult Index()
        {
            return View(_locationCRUDBLL.GetAllLocationsForDisplay());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            LocationDisplayViewModel loaction = _locationCRUDBLL.GetSingleLocationForDisplayByID((int)id);

            if (loaction == null)
            {
                return HttpNotFound();
            }

            return View(loaction);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(LocationCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                _locationCRUDBLL.CreateLocation(model);
                return RedirectToAction("Index");
            }
            
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            LocationUpdateViewModel location = _locationCRUDBLL.GetSingleLocationForUpdateByID((int)id);

            if (location == null)
            {
                return HttpNotFound();
            }

            return View(location);
        }

        [HttpPost]
        public ActionResult Edit(LocationUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                _locationCRUDBLL.UpdateLocation(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            LocationDeleteViewModel location = _locationCRUDBLL.GetSingleLocationForDeleteByID((int)id);

            if (location == null)
            {
                return HttpNotFound();
            }

            return View(location);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _locationCRUDBLL.DeleteLocation(_locationCRUDBLL.GetSingleLocationForDeleteByID((int)id));

            return RedirectToAction("Index");
        }
    }
}