using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using FoamMVC.Models;

namespace FoamMVC.ViewModels
{
    public abstract class ReviewBaseViewModel
    {
        [Required]
        public int ApplicationUserID { get; set; }
        [Required]
        public int ItemID { get; set; }

        public DateTime DateOfReview { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Item Item { get; set; }
        public virtual IList<ReviewScoreForDescriptor> ReviewScoreForDescriptors { get; set; }
    }

    public class ReviewGetViewModel : ReviewBaseViewModel
    {
        [Required]
        public int ReviewID { get; set; }
    }
    public class ReviewUpdateViewModel : ReviewBaseViewModel
    {
        [Required]
        public int ReviewID { get; set; }
    }
    public class ReviewCreateViewModel : ReviewBaseViewModel { }

    public class ReviewDeleteViewModel : ReviewBaseViewModel
    {
        [Required]
        public int ReviewID { get; set; }
    }
}