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
}