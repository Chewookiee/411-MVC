using FoamMVC.DAL.CRUD.BaseOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FoamMVC.Models;
using FoamMVC.Models.Context;
using System.Data.Entity.Migrations;

namespace FoamMVC.DAL.CRUD.LikeOperations
{
    public class LikeDAL : BaseDAL, ILikeDAL
    {
        public LikeDAL() : base()
        {
        }
        public LikeDAL(ApplicationDbContext context) : base(context)
        {
        }

        public int Create(Like likeToCreate)
        {
            if (likeToCreate == null)
            {
                throw new Exception("The Like sent in for creation is null.");
            }

            base.UpdateDateAdded(likeToCreate);
            base.UpdateIsDeletedToTrue(likeToCreate);

            db.Likes.Add(likeToCreate);
            db.SaveChanges();
            int idOfLike = likeToCreate.ID;

            return idOfLike;
        }

        public void Delete(Like likeToDelete)
        {
            Delete(likeToDelete.ID);
        }

        public void Delete(List<int> likesToDelete)
        {
            if (likesToDelete == null)
            {
                throw new Exception("There were no Likes in the list to delete");
            }
            foreach (int likeID in likesToDelete)
            {
                Delete(likeID);
            }
        }

        public void Delete(int id)
        {
            Like likeToDelete = db.Likes.SingleOrDefault(i => i.ID == id);

            if (likeToDelete == null)
            {
                throw new Exception("No Like exists with the id " + id);
            }

            base.UpdateIsDeletedToTrue(likeToDelete);
            base.UpdateDateDeleted(likeToDelete);

            db.SaveChanges(); 
        }

        public void Delete(List<Like> likesToDelete)
        {
            if (likesToDelete == null)
            {
                throw new Exception("There were no Likes in the list to delete");
            }
            foreach (Like like in likesToDelete)
            {
                Delete(like);
            }
        }

        public void Destroy(int id)
        {
            Like likeToDestroy = db.Likes.SingleOrDefault(i => i.ID == id);

            if (likeToDestroy == null)
            {
                throw new Exception("No Like exists with the id " + id);
            }

            db.Likes.Remove(likeToDestroy);
            db.SaveChanges();
        }

        public void Destroy(Like likeToDestroy)
        {
            Destroy(likeToDestroy.ID);
        }

        public void Destroy(List<int> likesToDestroy)
        {
            if (likesToDestroy == null)
            {
                throw new Exception("There were no Likes in the list to destroy");
            }
            foreach (int likeID in likesToDestroy)
            {
                Destroy(likeID);
            }
        }

        public void Destroy(List<Like> likesToDestroy)
        {
            if (likesToDestroy == null)
            {
                throw new Exception("There were no Likes in the list to destroy");
            }
            foreach (Like like in likesToDestroy)
            {
                Destroy(like);
            }
        }

        public List<Like> Get()
        {
            List<Like> likesToReturn = db.Likes.Where(i => i.IsDeleted == false).ToList();

            if (likesToReturn == null)
            {
                throw new Exception("No Likes exist in the database.");
            }

            return likesToReturn;
        }

        public Like Get(int id)
        {
            Like likeToReturn = db.Likes.SingleOrDefault(i => i.ID == id && i.IsDeleted == false);

            if (likeToReturn == null)
            {
                throw new Exception("No Like exists with the id " + id);
            }

            return likeToReturn;
        }

        public int Update(Like updatedLike)
        {
            Like likeToUpdate = db.Likes.SingleOrDefault(i => i.ID == updatedLike.ID && i.IsDeleted == false);

            if (likeToUpdate == null)
            {
                throw new Exception("No Like exists with the id " + updatedLike.ID);
            }

            base.UpdateDateUpdated(updatedLike);

            db.Likes.AddOrUpdate(l => l.ID, updatedLike);
            db.SaveChanges();
            int idOfLike = updatedLike.ID;

            return idOfLike;
        }
    }
}