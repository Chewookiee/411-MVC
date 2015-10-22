using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using FoamMVC.Models;
using System.Web.Mvc;

namespace FoamMVC.ViewModels
{
    public abstract class PalletGroupBaseViewModel
    {
        public int PalletGroupID { get; set; }
        public string Name { get; set; }

        public virtual IList<PalletDescriptor> PalletDescriptors { get; set; }
        public virtual IList<Item> Items { get; set; }
    }

    public class PalletGroupDisplayViewModel
    {
        public int ID { get; set; }

        [Display(Name = "Name", Description = "This is the name that will be associated with this Pallet Group")]
        public string Name { get; set; }

        [Display(Description = "Date that the Pallet Group was added", Name = "Date Added")]
        public DateTime DateAdded { get; set; }

        [Display(Description = "Date that the Pallet Group was last updated", Name = "Date Updated")]
        public DateTime? DateUpdated { get; set; }
    }

    public class PalletGroupCreateViewModel
    {
        [Required(ErrorMessage = "Please enter a name")]
        [Display(Name = "Name", Description = "This is the name that will be associated with this Pallet Group")]
        public string Name { get; set; }

        public int[] PalletDescriptorID { get; set; }

        [Display(Name = "Pallet Descriptors", Description = "This is the Pallet Descriptors that will be associated with this Pallet Group")]
        public MultiSelectList PalletDescriptors { get; set; }
    }

    public class PalletGroupUpdateViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please enter a name")]
        [Display(Name = "Name", Description = "This is the name that will be associated with this Pallet Group")]
        public string Name { get; set; }

        public int[] PalletDescriptorID { get; set; }

        [Display(Name = "Pallet Descriptors", Description = "This is the Pallet Descriptors that will be associated with this Pallet Group")]
        public MultiSelectList PalletDescriptors { get; set; }
    }

    public class PalletGroupDeleteViewModel
    {
        public int ID { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }
    }

    public class PalletGroupCreateViewModel_Old
    {
        [Required(ErrorMessage = "A Pallet Group name must be entered")]
        public string Name { get; set; }
    }
}