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
    public class LikeCRUD : BaseCRUD, ILikeCRUD
    {
        public LikeCRUD() : base()
        {
        }
        public LikeCRUD(ApplicationDbContext context) : base(context)
        {
        }

        public int Create(Like likeToCreate)
        {
            if (likeToCreate == null)
            {
                throw new Exception("The Like sent in for creation is null.");
            }
            db.Likes.Add(likeToCreate);
            int idOfLike = db.SaveChanges();

            return idOfLike;
        }

        public void Delete(Like likeToDelete)
        {
            Delete(likeToDelete.ID);
        }

        public void Delete(IList<int> likesToDelete)
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
            Like likeToDelete;
            likeToDelete = db.Likes.SingleOrDefault(i => i.ID == id);

            if (likeToDelete == null)
            {
                throw new Exception("No Like exists with the id " + id);
            }

            likeToDelete.IsDeleted = true;
            db.SaveChanges(); 
        }

        public void Delete(IList<Like> likesToDelete)
        {
            bool allSucceeded = true;

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
            Like likeToDestroy;
            likeToDestroy = db.Likes.SingleOrDefault(i => i.ID == id);

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

        public void Destroy(IList<int> likesToDestroy)
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

        public void Destroy(IList<Like> likesToDestroy)
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

        public IList<Like> Get()
        {
            IList<Like> likesToReturn;
            likesToReturn = db.Likes.ToList();

            if (likesToReturn == null)
            {
                throw new Exception("No Likes exist in the database.");
            }

            return likesToReturn;
        }

        public Like Get(int id)
        {
            Like likeToReturn;
            likeToReturn = db.Likes.SingleOrDefault(i => i.ID == id);

            if (likeToReturn == null)
            {
                throw new Exception("No Like exists with the id " + id);
            }

            return likeToReturn;
        }

        public int Update(Like updatedLike)
        {
            Like likeToUpdate;
            likeToUpdate = db.Likes.SingleOrDefault(i => i.ID == updatedLike.ID);

            if (likeToUpdate == null)
            {
                throw new Exception("No Like exists with the id " + updatedLike.ID);
            }

            db.Likes.AddOrUpdate(l => l.ID, updatedLike);
            int idOfLike = db.SaveChanges();

            return idOfLike;
        }
    }
}