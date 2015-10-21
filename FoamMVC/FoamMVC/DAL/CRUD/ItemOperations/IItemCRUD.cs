using FoamMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoamMVC.DAL.CRUD.ItemOperations
{
    public interface IItemCRUD
    {
        int Create(Item itemToCreate);
        IList<Item> Get();
        Item Get(int id);
        Item Get(Item itemToGet);
        Item Get(string upc);
        int Update(Item updatedItem);
        int Update(StagedItem stagedItem);
        void Delete(IList<Item> itemsToDelete);
        void Delete(IList<int> itemsToDelete);
        void Delete(Item itemToDelete);
        void Delete(int id);
        void Destroy(IList<Item> itemsToDestroy);
        void Destroy(IList<int> itemsToDestroy);
        void Destroy(Item itemToDestroy);
        void Destroy(int id);
    }
}