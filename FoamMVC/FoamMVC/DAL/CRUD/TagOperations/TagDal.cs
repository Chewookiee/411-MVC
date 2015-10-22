using FoamMVC.DAL.CRUD.BaseOperations;
using FoamMVC.Models;
using FoamMVC.Models.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace FoamMVC.DAL.CRUD.TagOperations
{
    public class TagDAL : BaseDAL, ITagDAL
    {
        public TagDAL() : base()
        {
        }
        public TagDAL(ApplicationDbContext context) : base(context)
        {
        }

        public int Create(Tag tagToCreate)
        {
            if (tagToCreate == null)
            {
                throw new Exception("The Tag sent in for creation is null.");
            }

            base.UpdateDateAdded(tagToCreate);
            base.UpdateIsDeletedToFalse(tagToCreate);

            db.Tags.Add(tagToCreate);
            db.SaveChanges();
            int idOfTag = tagToCreate.ID;

            return idOfTag;
        }

        public List<Tag> Get()
        {
            List<Tag> tagsToReturn = db.Tags.Where(t => t.IsDeleted == false).ToList();

            if (tagsToReturn == null)
            {
                throw new Exception("No Tags exist in the database.");
            }

            return tagsToReturn;
        }

        public Tag Get(int id)
        {
            Tag tagToReturn = db.Tags.SingleOrDefault(c => c.ID == id && c.IsDeleted == false);

            if (tagToReturn == null)
            {
                throw new Exception("No Tag exists with the id " + id);
            }

            return tagToReturn;
        }

        public Tag Get(Tag tagToGet)
        {
            return Get(tagToGet.Name);
        }

        public Tag Get(string name)
        {
            Tag tagToReturn;
            tagToReturn = db.Tags.SingleOrDefault(c => c.Name.Equals(name) && c.IsDeleted == false);

            if (tagToReturn == null)
            {
                throw new Exception("No Tag exists with the name " + name);
            }

            return tagToReturn;
        }

        public int Update(Tag updatedTag)
        {
            Tag tagToUpdate = db.Tags.SingleOrDefault(c => c.ID == updatedTag.ID && c.IsDeleted == false);

            if (tagToUpdate == null)
            {
                throw new Exception("No Tag exists with the id " + updatedTag.ID);
            }

            base.UpdateDateUpdated(updatedTag);

            db.Tags.AddOrUpdate(c => c.ID, updatedTag);
            db.SaveChanges();
            int idOfTag = updatedTag.ID;

            return idOfTag;
        }

        public void Delete(List<Tag> tagsToDelete)
        {
            if (tagsToDelete == null)
            {
                throw new Exception("There were no Tags in the list to delete");
            }
            foreach (Tag tag in tagsToDelete)
            {
                Delete(tag);
            }
        }

        public void Delete(List<int> tagsToDelete)
        {
            if (tagsToDelete == null)
            {
                throw new Exception("There were no Tags in the list to delete");
            }
            foreach (int tagID in tagsToDelete)
            {
                Delete(tagID);
            }
        }

        public void Delete(Tag tagToDelete)
        {
            Delete(tagToDelete.ID);
        }

        public void Delete(int id)
        {
            Tag tagToDelete = db.Tags.SingleOrDefault(c => c.ID == id);

            if (tagToDelete == null)
            {
                throw new Exception("No Tag exists with the id " + id);
            }

            base.UpdateDateDeleted(tagToDelete);
            base.UpdateIsDeletedToTrue(tagToDelete);
            
            db.SaveChanges();
        }

        public void Destroy(List<Tag> tagsToDestroy)
        {
            if (tagsToDestroy == null)
            {
                throw new Exception("There were no Tags in the list to destroy");
            }
            foreach (Tag tag in tagsToDestroy)
            {
                Destroy(tag);
            }
        }

        public void Destroy(List<int> tagsToDestroy)
        {
            if (tagsToDestroy == null)
            {
                throw new Exception("There were no Tags in the list to destroy");
            }
            foreach (int tagID in tagsToDestroy)
            {
                Destroy(tagID);
            }
        }

        public void Destroy(Tag tagToDestroy)
        {
            Destroy(tagToDestroy.ID);
        }

        public void Destroy(int id)
        {
            Tag tagToDestroy = db.Tags.SingleOrDefault(c => c.ID == id);

            if (tagToDestroy == null)
            {
                throw new Exception("No Tag exists with the id " + id);
            }

            db.Tags.Remove(tagToDestroy);
            db.SaveChanges();
        }
    }
}