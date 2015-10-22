using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FoamMVC.DAL.CRUD.BaseOperations;
using FoamMVC.DAL.CRUD.ReviewOperations;
using FoamMVC.Models;
using System.Data.Entity.Migrations;

namespace FoamMVC.DAL.CRUD.ReviewOperations
{
    public class ReviewDAL : BaseDAL, IReviewDAL
    {
        public ReviewDAL() : base()
        {
        }
        public ReviewDAL(ApplicationDbContext context) : base(context)
        {
        }

        public int Create(Review reviewToCreate)
        {
            if (reviewToCreate == null)
            {
                throw new Exception("The Review sent in for creation is null.");
            }

            base.UpdateDateAdded(reviewToCreate);
            base.UpdateIsDeletedToFalse(reviewToCreate);

            db.Reviews.Add(reviewToCreate);
            db.SaveChanges();
            int idOfReviewDescriptor = reviewToCreate.ID;

            return idOfReviewDescriptor;
        }

        public void Delete(Review reviewToDelete)
        {
            Delete(reviewToDelete.ID);
        }

        private void Delete(int id)
        {
            Review reviewToDelete = db.Reviews.SingleOrDefault(i => i.ID == id);

            if (reviewToDelete == null)
            {
                throw new Exception("No Review exists with the id " + id);
            }

            base.UpdateDateDeleted(reviewToDelete);
            base.UpdateIsDeletedToTrue(reviewToDelete);
            
            db.SaveChanges();
        }

        public void Delete(List<Review> reviewsToDelete)
        {
            if (reviewsToDelete == null)
            {
                throw new Exception("There were no Reviews in the list to delete");
            }
            foreach (Review review in reviewsToDelete)
            {
                Delete(review.ID);
            }
        }

        private void Destroy(int id)
        {
            Review reviewToDestroy = db.Reviews.SingleOrDefault(i => i.ID == id);

            if (reviewToDestroy == null)
            {
                throw new Exception("No Review exists with the id " + id);
            }

            db.Reviews.Remove(reviewToDestroy);
            db.SaveChanges();
        }

        public void Destroy(Review reviewToDestroy)
        {
            Destroy(reviewToDestroy.ID);
        }

        public void Destroy(List<Review> reviewsToDestroy)
        {
            if (reviewsToDestroy == null)
            {
                throw new Exception("There were no Reviews in the list to destroy");
            }
            foreach (Review review in reviewsToDestroy)
            {
                Destroy(review.ID);
            }
        }

        public List<Review> Get()
        {
<<<<<<< HEAD:FoamMVC/FoamMVC/DAL/CRUD/ReviewOperations/ReviewCRUD.cs
            IList<Review> reviewsToReturn = db.Reviews.Where(r => r.IsDeleted == false).ToList();
=======
            List<Review> reviewsToReturn = db.Reviews.ToList();
>>>>>>> 915ff1224ce01fdde97b367b7d18b87f664de4c6:FoamMVC/FoamMVC/DAL/CRUD/ReviewOperations/ReviewDAL.cs

            if (reviewsToReturn == null)
            {
                throw new Exception("No Reviews exist in the database.");
            }

            return reviewsToReturn;
        }

        public Review Get(int id)
        {
            Review reviewToReturn = db.Reviews.SingleOrDefault(i => i.ID == id && i.IsDeleted == false);

            if (reviewToReturn == null)
            {
                throw new Exception("No Review exists with the id " + id);
            }

            return reviewToReturn;
        }

        public int Update(Review review)
        {
            Review reviewToUpdate = db.Reviews.SingleOrDefault(i => i.ID == review.ID && i.IsDeleted == false);

            if (reviewToUpdate == null)
            {
                throw new Exception("No Review exists with the id " + review.ID);
            }

            base.UpdateDateUpdated(reviewToUpdate);

            db.Reviews.AddOrUpdate(r => r.ID, reviewToUpdate);
            db.SaveChanges();
            int idOfReview = reviewToUpdate.ID;

            return idOfReview;
        }
    }
}