using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using FoamMVC.Models;

namespace FoamMVC.ViewModels
{
    public abstract class TagBaseViewModel
    {
        public int TagID { get; set; }
        public string Name { get; set; }

        public virtual IList<Item> Items { get; set; }
    }
}