using FoamMVC.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoamMVC.Models
{
    public class PalletDescriptor : IAuditable
    {
        public int ID { get; set; }

        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime? DateDeleted { get; set; }
        public DateTime? DateUpdated { get; set; }

        public virtual IList<PalletGroup> PalletGroups { get; set; }
        public virtual IList<ReviewScoreForDescriptor> ReviewScoreForDescriptors { get; set; }
        public virtual IList<UserScoreForDescriptor> UserScoreForDescriptors { get; set; }
        public virtual IList<Category> Categories { get; set; }
    }
}