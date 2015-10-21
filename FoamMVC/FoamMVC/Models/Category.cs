using FoamMVC.Models.Interfaces;
using FoamMVC.Services.Cloning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebGrease.Css.Extensions;

namespace FoamMVC.Models
{
    public class Category : IAuditable
    {
        public int ID { get; set; }

        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime? DateDeleted { get; set; }
        public DateTime? DateUpdated { get; set; }

        public virtual IList<Item> Items { get; set; }
        public virtual IList<PalletDescriptor> PalletDescriptors { get; set; }
    }
}