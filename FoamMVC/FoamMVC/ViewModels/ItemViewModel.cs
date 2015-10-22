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

    public class ItemViewModelStringItemPrice
    {
        public int ItemID { get; set; }

        public int PalletGroupID { get; set; }
        public int CompanyID { get; set; }
        public int CategoryID { get; set; }
        public DateTime DateAdded { get; private set; }
        public bool IsFeautured { get; set; }
        public string ImagePath { get; set; }
        public int StockCount { get; set; }
        public string ItemPrice { get; set; }
        public string Name { get; set; }
        public string UPC { get; set; }

        public virtual Company Company { get; set; }
        public virtual PalletGroup PalletGroup { get; set; }
        public virtual Category Category { get; set; }
        public virtual IList<Review> Reviews { get; set; }
        public virtual IList<Tag> Tags { get; set; }
        public virtual IList<Like> Likes { get; set; }

    }

    public class ItemDisplayViewModel
    {
        public int ID { get; set; }
        public string ItemName { get; set; }
        public string CompanyName { get; set; }
        public int StockCount { get; set; }
        public string ItemPrice { get; set; }
    }

    public class ItemDisplaySingleViewModel
    {
        public int ID { get; set; }
        public string ItemName { get; set; }
        public string CategoryName { get; set; }
        public string CompanyName { get; set; }
        public string Location { get; set; }
        public string ImagePath { get; set; }
        public int StockCount { get; set; }
        public double ItemPrice { get; set; }
        public List<string> Tags { get; set; }
        public List<PalletDescriptorDisplayViewModel> PalletDescriptors { get; set; }

    }
}