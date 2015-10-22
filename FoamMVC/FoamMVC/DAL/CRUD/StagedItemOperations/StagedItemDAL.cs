using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FoamMVC.DAL.CRUD.BaseOperations;
using FoamMVC.DTOs;
using FoamMVC.Models;

namespace FoamMVC.DAL.CRUD.StagedItemOperations
{
    public class StagedItemDAL : BaseDAL, IStagedItemDAL
    {
        public void Create(StagedItem item)
        {
            db.StagedItems.Add(item);
            db.SaveChanges();
        }

        public void Update(StagedItem stagedItem)
        {
            var toUpdate = db.StagedItems.Single(x => x.UPC == stagedItem.UPC);
            toUpdate.ItemPrice = stagedItem.ItemPrice;
            toUpdate.StockCount = stagedItem.StockCount;
            db.SaveChanges();
        }

        public void Destroy(StagedItem stagedItem)
        {
            Destroy(stagedItem.UPC);
        }

        private void Destroy(string UPC)
        {
            var stagedToDelete = db.StagedItems.SingleOrDefault(x => x.UPC == UPC);

            if (stagedToDelete == null)
            {
                throw new Exception("No Staged Item Exists");
            }

            db.StagedItems.Remove(stagedToDelete);
            db.SaveChanges();
        }

        public List<StagedItem> Get()
        {
            return db.StagedItems.ToList();
        }

        public StagedItem Get(string UPC)
        {
            var staged  = Get().SingleOrDefault(x => x.UPC == UPC);
            if (staged == null)
            {
                throw new Exception("No staged item exists with UPC: " + UPC);
            }
            return staged;
        }
        public StagedItem Get(StagedItem item)
        {
            return db.StagedItems.Find(item.ID);
        }
    }
}