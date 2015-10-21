using System;
using System.ComponentModel.DataAnnotations;
using FoamMVC.Models;

namespace FoamMVC.ViewModels
{
    public abstract class LikeBaseViewModel
    {
        [Required]
        public int ApplicationUserID { get; set; }
        [Required]
        public int ItemID { get; set; }

        public bool IsLiked { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Item Item { get; set; }
    }

    public class LikeUpdateViewModel : LikeBaseViewModel
    {
        [Required]
        public int LikeID { get; set; }
        public DateTime DateLiked { get; set; }

    }

    public class LikeGetViewModel : LikeBaseViewModel
    {
        [Required]
        public int LikeID { get; set; }
        public DateTime DateLiked { get; set; }

    }

    public class LikeCreateViewModel : LikeBaseViewModel
    {
        public DateTime DateLike
        {
            set
            {
                DateLike = DateTime.Now;
            }
        }
    }

    public class LikeDeleteViewModel : LikeBaseViewModel
    {
        [Required]
        public int LikeID { get; set; }
    }

}