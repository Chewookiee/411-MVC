using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using FoamMVC.Models;

namespace FoamMVC.ViewModels
{
    public abstract class PalletDescriptorBaseViewModel
    {
        public int PalletDescriptorID { get; set; }

        public string Name { get; set; }

        public virtual IList<PalletGroup> PalletGroups { get; set; }
        public virtual IList<ReviewScoreForDescriptor> ReviewScoreForDescriptors { get; set; }
        public virtual IList<UserScoreForDescriptor> UserScoreForDescriptors { get; set; }
        public virtual IList<Category> Categories { get; set; }
    }
}