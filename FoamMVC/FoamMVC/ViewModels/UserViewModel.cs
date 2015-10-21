using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using FoamMVC.Models;

namespace FoamMVC.ViewModels
{
    public abstract class UserBaseViewModel
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public IList<Like> Likes { get; set; }
        public IList<Review> Reviews { get; set; }
        public IList<UserScoreForDescriptor> UserScoreForDescriptors { get; set; }
    }
}