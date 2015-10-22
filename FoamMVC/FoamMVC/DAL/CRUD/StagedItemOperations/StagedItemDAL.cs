using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FoamMVC.DAL.CRUD.BaseOperations;
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

        public List<StagedItem> Get()
        {
            return db.StagedItems.ToList();
        }

        public StagedItem Get(StagedItem item)
        {
            return db.StagedItems.Find(item.ID);
        }
    }
}