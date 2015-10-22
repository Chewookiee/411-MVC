using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FoamMVC.Models;

namespace FoamMVC.DAL.CRUD.ReviewOperations
{
    public interface IReviewDAL
    {
        int Create(Review reviewToCreate);
        List<Review> Get();
        Review Get(int id);
        int Update(Review reviewGroup);
        void Delete(List<Review> reviewsToDelete);
        void Delete(Review reviewToDelete);
        void Destroy(List<Review> reviewsToDestroy);
        void Destroy(Review reviewToDestroy);
    }
}