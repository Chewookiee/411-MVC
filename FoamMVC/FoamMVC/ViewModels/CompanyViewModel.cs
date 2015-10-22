using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoamMVC.BLL.CRUD.LocationOperations;
using FoamMVC.Models;
using Newtonsoft.Json;

namespace FoamMVC.ViewModels
{
    public class CompanyViewModel
    {
        public int CompanyID { get; set; }
        public int LocationID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual Location Location { get; set; }
        public virtual IList<Item> Items { get; set; }
    }

    public class CompanyCreateViewModel
    {
        private List<SelectListItem> _location = new LocationBLL().GetDropDownDisplayForLocations();

        [Required(ErrorMessage = "A name of the company must be entered")]
        public string Name { get; set; }

        public string Description { get; set; }
   
        [Required(ErrorMessage = "A location must be selected")]
        public int LocationID { get; set; }

        public List<SelectListItem> Location
        {
            get { return _location; }
            set { _location = new LocationBLL().GetDropDownDisplayForLocations(); }
        }
    }

    public class CompanyDisplayViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int LocationID { get; set; }
    }
}