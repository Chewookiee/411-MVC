using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FoamMVC.Models;

namespace FoamMVC.DAL.CRUD.ReviewOperations
{
    public interface IReviewCRUD
    {
        int Create(Review reviewToCreate);
        IList<Review> Get();
        Review Get(int id);
        int Update(Review reviewGroup);
        void Delete(IList<Review> reviewsToDelete);
        void Delete(Review reviewToDelete);
        void Destroy(IList<Review> reviewsToDestroy);
        void Destroy(Review reviewToDestroy);
    }
}