using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FoamMVC.Models;
using FoamMVC.DAL.CRUD.BaseOperations;
using FoamMVC.Models.Context;
using System.Data.Entity.Migrations;

namespace FoamMVC.DAL.CRUD.ItemOperations
{
    public class ItemCRUD : BaseCRUD, IItemCRUD
    {
        public ItemCRUD() : base()
        {
        }
        public ItemCRUD(ApplicationDbContext context) : base(context)
        {
        }

        public int Create(Item itemToCreate)
        {
            if (itemToCreate == null)
            {
                throw new Exception("The Item sent in for creation is null.");
            }

            base.UpdateDateAdded(itemToCreate);
            base.UpdateIsDeletedToFalse(itemToCreate);

            db.Items.Add(itemToCreate);
            db.SaveChanges();
            int idOfItem = itemToCreate.ID;

            return idOfItem;
        }

        public void Delete(int id)
        {
            Item itemToDelete = db.Items.SingleOrDefault(i => i.ID == id);

            if (itemToDelete == null)
            {
                throw new Exception("No Item exists with the id " + id);
            }

            base.UpdateIsDeletedToTrue(itemToDelete);
            base.UpdateDateDeleted(itemToDelete);

            db.SaveChanges();
        }

        public void Delete(Item itemToDelete)
        {
            Delete(itemToDelete.ID);
        }

        public void Delete(IList<int> itemsToDelete)
        {
            if (itemsToDelete == null)
            {
                throw new Exception("There were no Items in the list to delete");
            }
            foreach (int itemID in itemsToDelete)
            {
                Delete(itemID);
            }
        }

        public void Delete(IList<Item> itemsToDelete)
        {
            if (itemsToDelete == null)
            {
                throw new Exception("There were no Items in the list to delete");
            }
            foreach (Item item in itemsToDelete)
            {
                Delete(item);
            }
        }

        public void Destroy(IList<int> itemsToDestroy)
        {
            if (itemsToDestroy == null)
            {
                throw new Exception("There were no Items in the list to destroy");
            }
            foreach (int itemID in itemsToDestroy)
            {
                Destroy(itemID);
            }
        }

        public void Destroy(int id)
        {
            Item itemToDestroy = db.Items.SingleOrDefault(i => i.ID == id);

            if (itemToDestroy == null)
            {
                throw new Exception("No Item exists with the id " + id);
            }

            db.Items.Remove(itemToDestroy);
            db.SaveChanges();
        }

        public void Destroy(Item itemToDestroy)
        {
            Destroy(itemToDestroy.ID);
        }

        public void Destroy(IList<Item> itemsToDestroy)
        {
            if (itemsToDestroy == null)
            {
                throw new Exception("There were no Items in the list to destroy");
            }
            foreach (Item item in itemsToDestroy)
            {
                Destroy(item);
            }
        }

        public IList<Item> Get()
        {
            IList<Item> itemsToReturn = db.Items.ToList();

            if (itemsToReturn == null)
            {
                throw new Exception("No Items exist in the database.");
            }

            return itemsToReturn;
        }

        public Item Get(int id)
        {
            Item itemToReturn = db.Items.SingleOrDefault(i => i.ID == id);

            if (itemToReturn == null)
            {
                throw new Exception("No Item exists with the id " + id);
            }

            return itemToReturn;
        }

        public Item Get(string upc)
        {
            Item itemToReturn = db.Items.SingleOrDefault(i => i.UPC.Equals(upc));

            if (itemToReturn == null)
            {
                throw new Exception("No Item exists with the UPC " + upc);
            }

            return itemToReturn;
        }

        public Item Get(Item itemToGet)
        {
            return Get(itemToGet.UPC);
        }

        public int Update(Item updatedItem)
        {
            Item itemToUpdate = db.Items.SingleOrDefault(i => i.ID == updatedItem.ID);

            if (itemToUpdate == null)
            {
                throw new Exception("No Item exists with the id " + updatedItem.ID);
            }

            base.UpdateDateUpdated(updatedItem);

            db.Items.AddOrUpdate(i => i.ID, updatedItem);
            db.SaveChanges();
            int idOfItem = itemToUpdate.ID;

            return idOfItem;
        }
    }
}