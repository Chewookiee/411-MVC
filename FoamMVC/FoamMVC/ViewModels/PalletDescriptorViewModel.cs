using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoamMVC.BLL.CRUD.CategoryOperations;
using FoamMVC.Models;

namespace FoamMVC.ViewModels
{
    public class PalletDescriptorViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public virtual IList<PalletGroup> PalletGroups { get; set; }
        public virtual IList<ReviewScoreForDescriptor> ReviewScoreForDescriptors { get; set; }
        public virtual IList<UserScoreForDescriptor> UserScoreForDescriptors { get; set; }
        public virtual IList<Category> Categories { get; set; }
    }

    public class PalletDescriptorDisplayViewModel
    {
        public int PalletDescriptorID { get; set; }
        public string PalletDescriptorName { get; set; }

        public class PalledDescriptorUpdateViewModel
        {
            public int ID { get; set; }
            public string Name { get; set; }

            public List<SelectListItem> AllCategories { get; set; }

            private List<int> _selectedCategories;

            public List<int> SelectedCategories
            {
                get
                {
                    return _selectedCategories ??
                           (_selectedCategories =
                               new CategoryCRUDBLL().GetCategoryNameAndID().Select(x => x.CategoryID).ToList());
                }
                set { _selectedCategories = value; }
            }
        }

        public class CategorySelectList
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }
    }
}