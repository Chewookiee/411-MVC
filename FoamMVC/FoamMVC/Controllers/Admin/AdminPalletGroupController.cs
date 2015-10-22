using FoamMVC.Models;
using FoamMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebGrease.Css.Extensions;

namespace FoamMVC.Controllers.Admin
{
    public class AdminPalletGroupController : Controller
    {
        // GET: AdminPalletGroup
        public ActionResult Index()
        {
            using (var db = new ApplicationDbContext())
            {
                var palletGroups = db.PalletGroups.Where(p => p.IsDeleted == false).ToList();
                var palletGroupsToShow = new List<PalletGroupDisplayViewModel>();

                foreach (var palletGroup in palletGroups)
                {
                    palletGroupsToShow.Add(new PalletGroupDisplayViewModel
                    {
                        ID = palletGroup.ID,
                        Name = palletGroup.Name,
                        DateAdded = palletGroup.DateAdded,
                        DateUpdated = palletGroup.DateUpdated
                    });
                }

                return View(palletGroupsToShow);
            }
        }

        public ActionResult Details(int? id)
        {
            using (var db = new ApplicationDbContext())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                PalletGroup palletGroup = db.PalletGroups.SingleOrDefault(p => p.ID == (int)id);

                if (palletGroup == null)
                {
                    return HttpNotFound();
                }

                PalletGroupDisplayViewModel palletGroupToDisplay = new PalletGroupDisplayViewModel
                {
                    ID = palletGroup.ID,
                    DateAdded = palletGroup.DateAdded,
                    DateUpdated = palletGroup.DateUpdated,
                    Name = palletGroup.Name
                };

                return View(palletGroupToDisplay);
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            using (var db = new ApplicationDbContext())
            {
                var model = new PalletGroupCreateViewModel();
                var palletDescriptors = db.PalletDescriptors.Select(p => new
                {
                    ID = p.ID,
                    Name = p.Name
                }).ToList();
                model.PalletDescriptors = new MultiSelectList(palletDescriptors, "ID", "Name");

                model.PalletDescriptorID = new int[0];
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Create(PalletGroupCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new ApplicationDbContext())
            {
                List<PalletDescriptor> palletDescriptorsToAdd = new List<PalletDescriptor>();
                foreach (var id in model.PalletDescriptorID)
                {
                    palletDescriptorsToAdd.Add(db.PalletDescriptors.Single(p => p.ID == id));
                }

                PalletGroup palletGroupToCreate = new PalletGroup
                {
                    Name = model.Name,
                    IsDeleted = false,
                    DateAdded = DateTime.Now,
                    Items = new List<Item>(),
                    PalletDescriptors = palletDescriptorsToAdd
                };

                db.PalletGroups.Add(palletGroupToCreate);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            using (var db = new ApplicationDbContext())
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                PalletGroup palletGroup = db.PalletGroups.SingleOrDefault(p => p.ID == (int)id);

                if (palletGroup == null)
                {
                    return HttpNotFound();
                }

                var model = new PalletGroupUpdateViewModel();
                var palletDescriptors = db.PalletDescriptors.Select(p => new
                {
                    ID = p.ID,
                    Name = p.Name
                }).ToList();
                model.PalletDescriptors = new MultiSelectList(palletDescriptors, "ID", "Name");
                model.Name = palletGroup.Name;

                List<int> palletDescriptorIdsAsList = new List<int>();
                PalletGroup palletGroupToGetPalletDescriptorsFrom = db.PalletGroups.Single(p => p.ID == (int)id);

                foreach (var item in palletGroupToGetPalletDescriptorsFrom.PalletDescriptors)
                {
                    palletDescriptorIdsAsList.Add(item.ID);
                }

                model.PalletDescriptorID = palletDescriptorIdsAsList.ToArray();
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Edit(PalletGroupUpdateViewModel model)
        {
            using (var db = new ApplicationDbContext())
            {
                if (ModelState.IsValid)
                {
                    List<PalletDescriptor> palletDescriptorsToAdd = new List<PalletDescriptor>();
                    foreach (var id in model.PalletDescriptorID)
                    {
                        palletDescriptorsToAdd.Add(db.PalletDescriptors.Single(p => p.ID == id));
                    }

                    PalletGroup palletGroupToUpdate = db.PalletGroups.Single(p => p.ID == model.ID);

                    palletGroupToUpdate.DateUpdated = DateTime.Now;
                    palletGroupToUpdate.Name = model.Name;
                    palletGroupToUpdate.PalletDescriptors = palletDescriptorsToAdd;

                    return RedirectToAction("Index");
                }

                return View(model);
            }
        }
    }
}