using FoamMVC.Models;
using FoamMVC.Models.Context;
using FoamMVC.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoamMVC.DAL.CRUD.BaseOperations
{
    public class BaseCRUD
    {
        public ApplicationDbContext db { get; set; }

        public BaseCRUD()
            : this(new ApplicationDbContext())
        {
        }

        public BaseCRUD(ApplicationDbContext db)
        {
            this.db = db;
        }

        protected void UpdateDateAdded(IAuditable itemToChange)
        {
            itemToChange.DateAdded = DateTime.Now;
        }

        protected void UpdateDateUpdated(IAuditable itemToChange)
        {
            itemToChange.DateUpdated = DateTime.Now;
        }

        protected void UpdateDateDeleted(IAuditable itemToChange)
        {
            itemToChange.DateDeleted = DateTime.Now;
        }

        protected void UpdateIsDeletedToFalse(IAuditable itemToChange)
        {
            itemToChange.IsDeleted = false;
        }

        protected void UpdateIsDeletedToTrue(IAuditable itemToChange)
        {
            itemToChange.IsDeleted = true;
        }
    }
}