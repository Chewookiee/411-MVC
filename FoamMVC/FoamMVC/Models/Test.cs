using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoamMVC.Models
{
    public class Test
    {
        public int ID { get; set; }
        public int LocationID { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime? DateDeleted { get; set; }
        public DateTime? DateUpdated { get; set; }

        public virtual Location Location { get; set; }
        public virtual IList<Item> Items { get; set; }
    }
}