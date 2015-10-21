using FoamMVC.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoamMVC.Models
{
    public class Location : IAuditable
    {
        public int ID { get; set; }
        
        public string PrimaryLocation { get; set; }
        public string SecondaryLocation { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime? DateDeleted { get; set; }
        public DateTime? DateUpdated { get; set; }

        public IList<Company> Companies { get; set; }
    }
}