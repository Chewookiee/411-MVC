using FoamMVC.DAL.CRUD.BaseOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FoamMVC.Models;
using System.Data.Entity.Migrations;

namespace FoamMVC.DAL.CRUD.UserScoreForDescriptorOperations
{
    public class UserScoreForDescriptorCRUD : BaseCRUD, IUserScoreForDescriptorCRUD
    {
        public UserScoreForDescriptorCRUD() : base()
        {
        }
        public UserScoreForDescriptorCRUD(ApplicationDbContext context) : base(context)
        {
        }

        public int Create(UserScoreForDescriptor userScoreForDescriptorToCreate)
        {
            if (userScoreForDescriptorToCreate == null)
            {
                throw new Exception("The User Score For Descriptor To Create sent in for creation is null.");
            }

            base.UpdateDateAdded(userScoreForDescriptorToCreate);
            base.UpdateIsDeletedToFalse(userScoreForDescriptorToCreate);

            db.UserScoreForDescriptors.Add(userScoreForDescriptorToCreate);
            db.SaveChanges();
            int idOfUserScoreForDescriptor = userScoreForDescriptorToCreate.ID;

            return idOfUserScoreForDescriptor;
        }

        public void Delete(IList<int> userScoreForDescriptorsToDelete)
        {
            if (userScoreForDescriptorsToDelete == null)
            {
                throw new Exception("There were no User Score For Descriptors in the list to delete");
            }
            foreach (int userScoreForDescriptorsID in userScoreForDescriptorsToDelete)
            {
                Delete(userScoreForDescriptorsID);
            }
        }

        public void Delete(UserScoreForDescriptor userScoreForDescriptorToDelete)
        {
            Delete(userScoreForDescriptorToDelete.ID);
        }

        public void Delete(int id)
        {
            UserScoreForDescriptor userScoreForDescriptorToDelete = db.UserScoreForDescriptors.SingleOrDefault(i => i.ID == id);

            if (userScoreForDescriptorToDelete == null)
            {
                throw new Exception("No User Score For Descriptor exists with the id " + id);
            }

            base.UpdateDateDeleted(userScoreForDescriptorToDelete);
            base.UpdateIsDeletedToTrue(userScoreForDescriptorToDelete);
            
            db.SaveChanges();
        }

        public void Delete(IList<UserScoreForDescriptor> userScoreForDescriptorsToDelete)
        {
            if (userScoreForDescriptorsToDelete == null)
            {
                throw new Exception("There were no User Score For Descriptors in the list to delete");
            }
            foreach (UserScoreForDescriptor userScoreForDescriptor in userScoreForDescriptorsToDelete)
            {
                Delete(userScoreForDescriptor);
            }
        }

        public void Destroy(int id)
        {
            UserScoreForDescriptor userScoreForDescriptorToDestroy = db.UserScoreForDescriptors.SingleOrDefault(i => i.ID == id);

            if (userScoreForDescriptorToDestroy == null)
            {
                throw new Exception("No User Score For Descriptor exists with the id " + id);
            }

            db.UserScoreForDescriptors.Remove(userScoreForDescriptorToDestroy);
            db.SaveChanges();
        }

        public void Destroy(UserScoreForDescriptor userScoreForDescriptorToDestroy)
        {
            Destroy(userScoreForDescriptorToDestroy.ID);
        }

        public void Destroy(IList<int> userScoreForDescriptorsToDestroy)
        {
            if (userScoreForDescriptorsToDestroy == null)
            {
                throw new Exception("There were no User Score For Descriptors in the list to destroy");
            }
            foreach (int userScoreForDescriptorID in userScoreForDescriptorsToDestroy)
            {
                Destroy(userScoreForDescriptorID);
            }
        }

        public void Destroy(IList<UserScoreForDescriptor> userScoreForDescriptorsToDestroy)
        {
            if (userScoreForDescriptorsToDestroy == null)
            {
                throw new Exception("There were no User Score For Descriptors in the list to destroy");
            }
            foreach (UserScoreForDescriptor userScoreForDescriptor in userScoreForDescriptorsToDestroy)
            {
                Destroy(userScoreForDescriptor);
            }
        }

        public IList<UserScoreForDescriptor> Get()
        {
            IList<UserScoreForDescriptor> userScoreForDescriptorsToReturn = db.UserScoreForDescriptors.ToList();

            if (userScoreForDescriptorsToReturn == null)
            {
                throw new Exception("No User Score For Descriptors exist in the database.");
            }

            return userScoreForDescriptorsToReturn;
        }

        public UserScoreForDescriptor Get(int id)
        {
            UserScoreForDescriptor userScoreForDescriptorToReturn = db.UserScoreForDescriptors.SingleOrDefault(i => i.ID == id);

            if (userScoreForDescriptorToReturn == null)
            {
                throw new Exception("No User Score For Descriptor exists with the id " + id);
            }

            return userScoreForDescriptorToReturn;
        }

        public int Update(UserScoreForDescriptor updatedUserScoreForDescriptor)
        {
            UserScoreForDescriptor userScoreForDescriptorToUpdate = db.UserScoreForDescriptors.SingleOrDefault(i => i.ID == updatedUserScoreForDescriptor.ID);

            if (userScoreForDescriptorToUpdate == null)
            {
                throw new Exception("No Like exists with the id " + updatedUserScoreForDescriptor.ID);
            }

            base.UpdateDateUpdated(userScoreForDescriptorToUpdate);

            db.UserScoreForDescriptors.AddOrUpdate(u => u.ID, updatedUserScoreForDescriptor);
            db.SaveChanges();
            int idOfUserScoreForDescriptor = userScoreForDescriptorToUpdate.ID;

            return idOfUserScoreForDescriptor;
        }
    }
}