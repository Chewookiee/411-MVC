using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FoamMVC.Models;

namespace FoamMVC.ViewModels
{
    public class CategoryViewModel
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }

        public ICollection<Item> Items { get; set; }
        public ICollection<PalletDescriptor> PalletDescriptors { get; set; }
    }

    public class CategoryCreateViewModel
    {
        [Required(ErrorMessage = "Please enter a name for the Category")]
        public string Name { get; set; }
    }

    public class CategoryUpdateViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class CategoryDisplayViewModel
    {
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime? DateDeleted { get; set; }
        public DateTime? DateUpdated { get; set; }  
    }
}