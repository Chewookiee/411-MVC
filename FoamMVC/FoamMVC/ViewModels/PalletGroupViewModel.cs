using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using FoamMVC.Models;

namespace FoamMVC.ViewModels
{
    public abstract class PalletGroupBaseViewModel
    {
        public int PalletGroupID { get; set; }
        public string Name { get; set; }

        public virtual IList<PalletDescriptor> PalletDescriptors { get; set; }
        public virtual IList<Item> Items { get; set; }
    }

    public class PalletGroupCreateViewModel
    {
        [Required(ErrorMessage = "A Pallet Group name must be entered")]
        public string Name { get; set; }
    }
}