using FoamMVC.Models.Interfaces;
using FoamMVC.Services.Cloning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoamMVC.Models
{
    public class Item : IAuditable
    {
        public int ID { get; set; }
        public int PalletGroupID { get; set; }
        public int CompanyID { get; set; }
        public int CategoryID { get; set; }

        public string Name { get; set; }
        public string UPC { get; set; }
        public bool IsFeatured { get; set; }
        public string ImagePath { get; set; }
        public int StockCount { get; set; }
        public double ItemPrice { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime? DateDeleted { get; set; }
        public DateTime? DateUpdated { get; set; }

        public virtual Company Company { get; set; }
        public virtual PalletGroup PalletGroup { get; set; }
        public virtual Category Category { get; set; }
        public virtual IList<Review> Reviews { get; set; }
        public virtual IList<Tag> Tags { get; set; }
        public virtual IList<Like> Likes { get; set; }
    }
}