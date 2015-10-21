using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoamMVC.Models.Interfaces
{
    interface IAuditable
    {
        bool IsDeleted { get; set; }
        DateTime DateAdded { get; set; }
        DateTime? DateUpdated { get; set; }
        DateTime? DateDeleted { get; set; }
    }
}
