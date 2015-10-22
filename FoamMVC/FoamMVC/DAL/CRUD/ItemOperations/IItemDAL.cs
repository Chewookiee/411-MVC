using FoamMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoamMVC.DAL.CRUD.ItemOperations
{
    public interface IItemDAL
    {
        int Create(Item itemToCreate);
        List<Item> Get();
        Item Get(int id);
        Item Get(Item itemToGet);
        Item Get(string upc);
        int Update(Item updatedItem);
        void Delete(List<Item> itemsToDelete);
        void Delete(List<int> itemsToDelete);
        void Delete(Item itemToDelete);
        void Delete(int id);
        void Destroy(List<Item> itemsToDestroy);
        void Destroy(List<int> itemsToDestroy);
        void Destroy(Item itemToDestroy);
        void Destroy(int id);
    }
}