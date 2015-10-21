using FoamMVC.Models.Interfaces;
using FoamMVC.Services.Cloning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoamMVC.Models
{
    public class Like : IAuditable
    {
        public int ID { get; set; }
        public int ApplicationUserID { get; set; }
        public int ItemID { get; set; }

        public bool? IsLiked { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime? DateDeleted { get; set; }
        public DateTime? DateUpdated { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Item Item { get; set; }
    }
}