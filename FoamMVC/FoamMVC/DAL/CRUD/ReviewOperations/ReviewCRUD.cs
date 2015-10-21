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
    public class ReviewCRUD : BaseCRUD, IReviewCRUD
    {
        public ReviewCRUD() : base()
        {
        }
        public ReviewCRUD(ApplicationDbContext context) : base(context)
        {
        }

        public int Create(Review reviewToCreate)
        {
            if (reviewToCreate == null)
            {
                throw new Exception("The Review sent in for creation is null.");
            }
            db.Reviews.Add(reviewToCreate);
            int idOfReviewDescriptor = db.SaveChanges();

            return idOfReviewDescriptor;
        }

        public void Delete(Review reviewToDelete)
        {
            Delete(reviewToDelete.ID);
        }

        private void Delete(int id)
        {
            Review reviewToDelete;
            reviewToDelete = db.Reviews.SingleOrDefault(i => i.ID == id);

            if (reviewToDelete == null)
            {
                throw new Exception("No Review exists with the id " + id);
            }

            reviewToDelete.IsDeleted = true;
            db.SaveChanges();
        }

        public void Delete(IList<Review> reviewsToDelete)
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
            Review reviewToDestroy;
            reviewToDestroy = db.Reviews.SingleOrDefault(i => i.ID == id);

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

        public void Destroy(IList<Review> reviewsToDestroy)
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

        public IList<Review> Get()
        {
            IList<Review> reviewsToReturn;
            reviewsToReturn = db.Reviews.ToList();

            if (reviewsToReturn == null)
            {
                throw new Exception("No Reviews exist in the database.");
            }

            return reviewsToReturn;
        }

        public Review Get(int id)
        {
            Review reviewToReturn;
            reviewToReturn = db.Reviews.SingleOrDefault(i => i.ID == id);

            if (reviewToReturn == null)
            {
                throw new Exception("No Review exists with the id " + id);
            }

            return reviewToReturn;
        }

        public int Update(Review review)
        {
            Review reviewToUpdate;
            reviewToUpdate = db.Reviews.SingleOrDefault(i => i.ID == review.ID);

            if (reviewToUpdate == null)
            {
                throw new Exception("No Review exists with the id " + review.ID);
            }

            db.Reviews.AddOrUpdate(r => r.ID, reviewToUpdate);
            int idOfReview = db.SaveChanges();

            return idOfReview;
        }
    }
}