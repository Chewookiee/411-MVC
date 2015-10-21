using FoamMVC.Models;
using FoamMVC.Models.Context;
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
    }
}