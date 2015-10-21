using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using FoamMVC.Models;

namespace FoamMVC.ViewModels
{
    public class ItemViewModel
    {
        public int ItemID { get; set; }

        public int PalletGroupID { get; set; }
        public int CompanyID { get; set; }
        public int CategoryID { get; set; }
        public DateTime DateAdded { get; private set; }
        public bool IsFeautured { get; set; }
        public string ImagePath { get; set; }
        public int StockCount { get; set; }
        public double ItemPrice { get; set; }
        public string Name { get; set; }
        public string UPC { get; set; }

        public virtual Company Company { get; set; }
        public virtual PalletGroup PalletGroup { get; set; }
        public virtual Category Category { get; set; }
        public virtual IList<Review> Reviews { get; set; }
        public virtual IList<Tag> Tags { get; set; }
        public virtual IList<Like> Likes { get; set; }
    }
}