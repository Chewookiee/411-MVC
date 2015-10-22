using FoamMVC.DAL.CRUD.BaseOperations;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using FoamMVC.Models;

namespace FoamMVC.DAL.CRUD.PalletGroupOperations
{
    public class PalletGroupDAL : BaseDAL, IPalletGroupDAL 
    {
        public PalletGroupDAL() : base()
        {
        }

        public PalletGroupDAL(ApplicationDbContext context) : base(context)
        {
        }

        public int Create(PalletGroup palletGroupToCreate)
        {
            if (palletGroupToCreate == null)
            {
                throw new Exception("The pallet group sent in for creation is null");
            }

            base.UpdateDateAdded(palletGroupToCreate);
            base.UpdateIsDeletedToFalse(palletGroupToCreate);

            db.PalletGroups.Add(palletGroupToCreate);
            db.SaveChanges();
            int idOfPalletGroup = palletGroupToCreate.ID;

            return idOfPalletGroup;
        }

        public List<PalletGroup> Get()
        {
<<<<<<< HEAD:FoamMVC/FoamMVC/DAL/CRUD/PalletGroupOperations/PalletGroupCRUD.cs
            IList<PalletGroup> palletGroupsToReturn = db.PalletGroups.Where(p => p.IsDeleted == false).ToList();
=======
            List<PalletGroup> palletGroupsToReturn = db.PalletGroups.ToList();
>>>>>>> 915ff1224ce01fdde97b367b7d18b87f664de4c6:FoamMVC/FoamMVC/DAL/CRUD/PalletGroupOperations/PalletGroupDal.cs

            if (palletGroupsToReturn == null)
            {
                throw new Exception("There are no Pallet groups that exist in the database.");
            }

            return palletGroupsToReturn;
        }

        public PalletGroup Get(int id)
        {
            PalletGroup palletGroupToReturn = db.PalletGroups.SingleOrDefault(c => c.ID == id && c.IsDeleted == false);

            if (palletGroupToReturn == null)
            {
                throw new Exception("No Pallet Group with the ID " + id + " exists.");
            }

            return palletGroupToReturn;
        }

        public PalletGroup Get(PalletGroup palletGroupToGet)
        {
            return Get(palletGroupToGet.Name);
        }

        public PalletGroup Get(string name)
        {
            PalletGroup palletGroupToGet = db.PalletGroups.SingleOrDefault(c => c.Name.Equals(name) && c.IsDeleted == false);

            if (palletGroupToGet == null)
            {
                throw new Exception("There is no Pallet Group that exists with the name " + name);
            }

            return palletGroupToGet;
        }

        public int Update(PalletGroup updatedPalletGroup)
        {
            PalletGroup palletGroupToUpdate = db.PalletGroups.SingleOrDefault(c => c.ID == updatedPalletGroup.ID && c.IsDeleted == false);

            if (palletGroupToUpdate == null)
            {
                throw new Exception("There is no Pallet Group with the ID " + updatedPalletGroup.ID);
            }

            base.UpdateDateUpdated(updatedPalletGroup);

            db.PalletGroups.AddOrUpdate(c => c.ID, updatedPalletGroup);
            db.SaveChanges();
            int idOfPalletGroup = updatedPalletGroup.ID;

            return idOfPalletGroup;
        }

        public void Delete(List<PalletGroup> palletGroupsToDelete)
        {
            if (palletGroupsToDelete == null)
            {
                throw new Exception("There were no Pallet Groups in the list to delete.");
            }
            foreach (PalletGroup palletGroup in palletGroupsToDelete)
            {
                Delete(palletGroup);
            }
        }
        public void Delete(List<int> palletGroupsToDelete)
        {
            if (palletGroupsToDelete == null)
            {
                throw new Exception("There were no Pallet Groups in the list to delete.");
            }
            foreach (int palletGroupID in palletGroupsToDelete)
            {
                Delete(palletGroupID);
            }
        }

        public void Delete(PalletGroup palletGroupToDelete)
        {
            Delete(palletGroupToDelete.ID);
        }

        public void Delete(int id)
        {
            PalletGroup palletGroupToDelete = db.PalletGroups.SingleOrDefault(c => c.ID == id);
            if (palletGroupToDelete == null)
            {
                throw new Exception("No Pallete Group exists with the ID " + id);
            }

            base.UpdateDateDeleted(palletGroupToDelete);
            base.UpdateIsDeletedToTrue(palletGroupToDelete);
            
            db.SaveChanges();
        }

        public void Destroy(List<PalletGroup> palletGroupsToDestroy)
        {
            if (palletGroupsToDestroy == null)
            {
                throw new Exception("There were no Pallet Groups in the list to destroy");
            }
            foreach (PalletGroup palletGroup in palletGroupsToDestroy)
            {
                Destroy(palletGroup);
            }
        }

        public void Destroy(List<int> palletGroupsToDestroy)
        {
            if (palletGroupsToDestroy == null)
            {
                throw new Exception("There were no Pallet Groups in the list to destroy");
            }
            foreach (int palletGroupID in palletGroupsToDestroy)
            {
                Destroy(palletGroupID);
            }
        }

        public void Destroy(PalletGroup palletGroupToDestroy)
        {
            Destroy(palletGroupToDestroy.ID);
        }

        public void Destroy(int id)
        {
            PalletGroup palletGroupToDestroy = db.PalletGroups.SingleOrDefault(c => c.ID == id);
            if (palletGroupToDestroy == null)
            {
                throw new Exception("No Pallet Group exists with the ID " + id);
            }

            db.PalletGroups.Remove(palletGroupToDestroy);
            db.SaveChanges();
        }
    }
}