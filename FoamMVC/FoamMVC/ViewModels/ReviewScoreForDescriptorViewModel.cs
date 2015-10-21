using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using FoamMVC.Models;

namespace FoamMVC.ViewModels
{
    public abstract class ReviewScoreForDescriptorBaseViewModel
    {
        public int ReviewForDescriptorID { get; set; }
        public int PalletDescriptorID { get; set; }
        public int Score { get; set; }

        public virtual Review Review { get; set; }
        public virtual PalletDescriptor PalletDescriptor { get; set; }
    }
}