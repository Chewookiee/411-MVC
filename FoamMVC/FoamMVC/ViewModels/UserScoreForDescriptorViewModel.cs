using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using FoamMVC.Models;

namespace FoamMVC.ViewModels
{
    public abstract class UserScoreForDescriptorBaseViewModel
    {
        [Required]
        public int ApplicationUserID { get; set; }
        [Required]
        public int PalletDescriptorID { get; set; }

        public int UserSelectedScore { get; set; }
        public int GeneratedScore { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual PalletDescriptor PalletDescriptor { get; set; }
    }

    public class UserScoreForDescriptorGetViewModel : UserScoreForDescriptorBaseViewModel
    {
        [Required]
        public int UserScoreForDescriptorID { get; set; }
    }
    public class UserScoreForDescriptorUpdateViewModel : UserScoreForDescriptorBaseViewModel
    {
        [Required]
        public int UserScoreForDescriptorID { get; set; }
    }
    public class UserScoreForDescriptorDeleteViewModel : UserScoreForDescriptorBaseViewModel
    {
        [Required]
        public int UserScoreForDescriptorID { get; set; }
    }
    public class UserScoreForDescriptorCreateViewModel : UserScoreForDescriptorBaseViewModel { }
}