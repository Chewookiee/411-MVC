using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FoamMVC.Models;
using FoamMVC.DAL.CRUD.BaseOperations;
using System.Data.Entity.Migrations;

namespace FoamMVC.DAL.CRUD.ReviewScoreForDescriptorOperations
{
    public class ReviewScoreForDescriptorCRUD : BaseCRUD, IReviewScoreForDescriptorCRUD
    {
        public ReviewScoreForDescriptorCRUD() : base()
        {
        }
        public ReviewScoreForDescriptorCRUD(ApplicationDbContext context) : base(context)
        {
        }

        public int Create(ReviewScoreForDescriptor reviewScoreForDescriptorToCreate)
        {
            if (reviewScoreForDescriptorToCreate == null)
            {
                throw new Exception("The Review Score For Descriptor sent in for creation is null.");
            }

            base.UpdateDateAdded(reviewScoreForDescriptorToCreate);
            base.UpdateIsDeletedToFalse(reviewScoreForDescriptorToCreate);

            db.ReviewScoreForDescriptors.Add(reviewScoreForDescriptorToCreate);
            db.SaveChanges();
            int idOfreviewScoreForDescriptor = reviewScoreForDescriptorToCreate.ID;

            return idOfreviewScoreForDescriptor;
        }

        public void Delete(IList<int> reviewScoreForDescriptorsToDelete)
        {
            if (reviewScoreForDescriptorsToDelete == null)
            {
                throw new Exception("There were no Review Score For Descriptors in the list to delete");
            }
            foreach (int reviewScoreForDescriptorsToDeleteID in reviewScoreForDescriptorsToDelete)
            {
                Delete(reviewScoreForDescriptorsToDeleteID);
            }
        }

        public void Delete(ReviewScoreForDescriptor reviewScoreForDescriptorToDelete)
        {
            Delete(reviewScoreForDescriptorToDelete.ID);
        }

        public void Delete(int id)
        {
            ReviewScoreForDescriptor reviewScoreForDescriptorToDelete = db.ReviewScoreForDescriptors.SingleOrDefault(i => i.ID == id);

            if (reviewScoreForDescriptorToDelete == null)
            {
                throw new Exception("No Review Score For Descriptor exists with the id " + id);
            }

            base.UpdateDateDeleted(reviewScoreForDescriptorToDelete);
            base.UpdateIsDeletedToTrue(reviewScoreForDescriptorToDelete);
            
            db.SaveChanges();
        }

        public void Delete(IList<ReviewScoreForDescriptor> reviewScoreForDescriptorsToDelete)
        {
            if (reviewScoreForDescriptorsToDelete == null)
            {
                throw new Exception("There were no Review Score For Descriptors in the list to delete");
            }
            foreach (ReviewScoreForDescriptor reviewScoreForDescriptor in reviewScoreForDescriptorsToDelete)
            {
                Delete(reviewScoreForDescriptor);
            }
        }

        public void Destroy(int id)
        {
            ReviewScoreForDescriptor reviewScoreForDescriptorToDestroy = db.ReviewScoreForDescriptors.SingleOrDefault(i => i.ID == id);

            if (reviewScoreForDescriptorToDestroy == null)
            {
                throw new Exception("No Review Score For Descriptor exists with the id " + id);
            }

            db.ReviewScoreForDescriptors.Remove(reviewScoreForDescriptorToDestroy);
            db.SaveChanges();
        }

        public void Destroy(ReviewScoreForDescriptor reviewScoreForDescriptorToDestroy)
        {
            Destroy(reviewScoreForDescriptorToDestroy.ID);
        }

        public void Destroy(IList<int> reviewScoreForDescriptorsToDestroy)
        {
            if (reviewScoreForDescriptorsToDestroy == null)
            {
                throw new Exception("There were no Review Score For Descriptors in the list to destroy");
            }
            foreach (int reviewScoreForDescriptorID in reviewScoreForDescriptorsToDestroy)
            {
                Destroy(reviewScoreForDescriptorID);
            }
        }

        public void Destroy(IList<ReviewScoreForDescriptor> reviewScoreForDescriptorsToDestroy)
        {
            if (reviewScoreForDescriptorsToDestroy == null)
            {
                throw new Exception("There were no Review Score For Descriptors in the list to destroy");
            }
            foreach (ReviewScoreForDescriptor reviewScoreForDescriptor in reviewScoreForDescriptorsToDestroy)
            {
                Destroy(reviewScoreForDescriptor);
            }
        }

        public IList<ReviewScoreForDescriptor> Get()
        {
            IList<ReviewScoreForDescriptor> reviewScoreForDescriptorsToReturn = db.ReviewScoreForDescriptors.ToList();

            if (reviewScoreForDescriptorsToReturn == null)
            {
                throw new Exception("No Review Score For Descriptors exist in the database.");
            }

            return reviewScoreForDescriptorsToReturn;
        }

        public ReviewScoreForDescriptor Get(int id)
        {
            ReviewScoreForDescriptor reviewScoreForDescriptorToReturn = db.ReviewScoreForDescriptors.SingleOrDefault(i => i.ID == id);

            if (reviewScoreForDescriptorToReturn == null)
            {
                throw new Exception("No Review Score For Descriptor exists with the id " + id);
            }

            return reviewScoreForDescriptorToReturn;
        }

        public int Update(ReviewScoreForDescriptor updatedReviewScoreForDescriptor)
        {
            ReviewScoreForDescriptor reviewScoreForDescriptorToUpdate = db.ReviewScoreForDescriptors.SingleOrDefault(i => i.ID == updatedReviewScoreForDescriptor.ID);

            if (updatedReviewScoreForDescriptor == null)
            {
                throw new Exception("No Review Score For Descriptor exists with the id " + updatedReviewScoreForDescriptor.ID);
            }

            base.UpdateDateUpdated(updatedReviewScoreForDescriptor);

            db.ReviewScoreForDescriptors.AddOrUpdate(l => l.ID, updatedReviewScoreForDescriptor);
            int idOfReviewScoreForDescriptor = db.SaveChanges();

            return idOfReviewScoreForDescriptor;
        }
    }
}