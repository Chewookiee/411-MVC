using FoamMVC.DAL.CRUD.BaseOperations;
using FoamMVC.Models;
using FoamMVC.Models.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace FoamMVC.DAL.CRUD.CategoryOperations
{
    public class CategoryDAL : BaseDAL, ICategoryDAL
    {
        public CategoryDAL() : base()
        {
        }
        public CategoryDAL(ApplicationDbContext context) : base(context)
        {
        }

        public int Create(Category categoryToCreate)
        {
            if (categoryToCreate == null)
            {
                throw new Exception("The Category sent in for creation is null.");
            }

            base.UpdateIsDeletedToFalse(categoryToCreate);
            base.UpdateDateAdded(categoryToCreate);

            db.Categories.Add(categoryToCreate);
            db.SaveChanges();
            int idOfCategory = categoryToCreate.ID;

            return idOfCategory;
        }

        public List<Category> Get()
        {
            List<Category> categoriesToReturn = db.Categories.ToList();

            if (categoriesToReturn == null)
            {
                throw new Exception("No Categories exist in the database.");
            }

            return categoriesToReturn;
        }
        public Category Get(int id)
        {
            Category categoryToReturn = db.Categories.SingleOrDefault(c => c.ID == id);

            if (categoryToReturn == null)
            {
                throw new Exception("No Category exists with the id " + id);
            }

            return categoryToReturn;
        }

        public Category Get(Category categoryToGet)
        {
            return Get(categoryToGet.Name);
        }
        public Category Get(string name)
        {
            Category categoryToReturn = db.Categories.SingleOrDefault(c => c.Name.Equals(name));
            
            if (categoryToReturn == null)
            {
                throw new Exception("No Category exists with the name " + name);
            }

            return categoryToReturn;
        }

        public int Update(Category updatedCategory)
        {
            Category categoryToUpdate = db.Categories.SingleOrDefault(c => c.ID == updatedCategory.ID);

            if (categoryToUpdate == null)
            {
                throw new Exception("No Category exists with the id " + updatedCategory.ID);
            }
           
            base.UpdateDateUpdated(updatedCategory);

            db.Categories.AddOrUpdate(c => c.ID, updatedCategory);
            db.SaveChanges();
            int idOfCategory = categoryToUpdate.ID;

            return idOfCategory;
        }

        public void Delete(List<Category> categoriesToDelete)
        {
            if (categoriesToDelete == null)
            {
                throw new Exception("There were no Categories in the list to delete");
            }
            foreach (Category category in categoriesToDelete)
            {
                Delete(category);
            }
        }
        public void Delete(List<int> categoriesToDelete)
        {
            if (categoriesToDelete == null)
            {
                throw new Exception("There were no Categories in the list to delete");
            }
            foreach (int categoryID in categoriesToDelete)
            {
                Delete(categoryID);
            }
        }
        public void Delete(Category categoryToDelete)
        {
            Delete(categoryToDelete.ID);
        }
        public void Delete(int id)
        {
            Category categoryToDelete = db.Categories.SingleOrDefault(c => c.ID == id);

            if (categoryToDelete == null)
            {
                throw new Exception("No Category exists with the id " + id);
            }
            
            base.UpdateIsDeletedToTrue(categoryToDelete);
            db.SaveChanges();
        }

        public void Destroy(List<Category> categoriesToDestroy)
        {
            if (categoriesToDestroy == null)
            {
                throw new Exception("There were no Categories in the list to destroy");
            }
            foreach (Category category in categoriesToDestroy)
            {
                Destroy(category);
            }
        }
        public void Destroy(List<int> categoriesToDestroy)
        {
            if (categoriesToDestroy == null)
            {
                throw new Exception("There were no Categories in the list to destroy");
            }
            foreach (int categoryID in categoriesToDestroy)
            {
                Destroy(categoryID);
            }
        }
        public void Destroy(Category categoryToDestroy)
        {
            Destroy(categoryToDestroy.ID);
        }
        public void Destroy(int id)
        {
            Category categoryToDestroy = db.Categories.SingleOrDefault(c => c.ID == id);

            if (categoryToDestroy == null)
            {
                throw new Exception("No Category exists with the id " + id);
            }

            db.Categories.Remove(categoryToDestroy);
            db.SaveChanges();
        }
    }
}