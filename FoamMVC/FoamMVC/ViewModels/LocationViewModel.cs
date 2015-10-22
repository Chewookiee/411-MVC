using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using FoamMVC.Models;

namespace FoamMVC.ViewModels
{
    public class LocationViewModel
    {
        public int ID { get; set; }
        public string PrimaryLocation { get; set; }
        public string SecondaryLocation { get; set; }
    }

    public class LocationDisplayViewModel
    {
        public int ID { get; set; }

        [Display(Description = "This is the Country or State (if it is in the United States)", Name = "Primary Location")]
        public string PrimaryLocation { get; set; }

        [Display(Description = "This is the City (if it is in the United States)", Name = "Secondary Location")]
        public string SecondaryLocation { get; set; }

        [Display(Description = "Date that the location was added", Name = "Date Added")]
        public DateTime DateAdded { get; set; }

        [Display(Description = "Date that the location was last updated", Name = "Date Updated")]
        public DateTime? DateUpdated { get; set; }
    }

    public class LocationCreateViewModel
    {
        [Required(ErrorMessage = "Please enter a Country or State (if it is in the United States)")]
        [Display(Description = "This is the Country or State (if it is in the United States)", Name = "Primary Location")]
        public string PrimaryLocation { get; set; }

        [Display(Description = "This is the City (if it is in the United States)", Name = "Secondary Location")]
        public string SecondaryLocation { get; set; }
    }

    public class LocationUpdateViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please enter a Country or State (if it is in the United States)")]
        [Display(Description = "This is the Country or State (if it is in the United States)", Name = "Primary Location")]
        public string PrimaryLocation { get; set; }

        [Display(Description = "This is the City (if it is in the United States)", Name = "Secondary Location")]
        public string SecondaryLocation { get; set; }
    }

    public class LocationDeleteViewModel
    {
        public int ID { get; set; }

        [Display(Name = "Primary Location")]
        public string PrimaryLocation { get; set; }

        [Display(Name = "Secondary Location")]
        public string SecondaryLocation { get; set; }
    }
}