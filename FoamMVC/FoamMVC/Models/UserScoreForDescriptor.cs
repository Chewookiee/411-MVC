using FoamMVC.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoamMVC.Models
{
    public class UserScoreForDescriptor : IAuditable
    {
        public int ID { get; set; }
        public int ApplicationUserID { get; set; }
        public int PalletDescriptorID { get; set; }

        public int UserSelectedScore { get; set; }
        public int GeneratedScore { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime? DateDeleted { get; set; }
        public DateTime? DateUpdated { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual PalletDescriptor PalletDescriptor { get; set; }
    }
}