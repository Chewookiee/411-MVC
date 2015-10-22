using FoamMVC.DAL.CRUD.BaseOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FoamMVC.Models;
using FoamMVC.Models.Context;
using System.Data.Entity.Migrations;

namespace FoamMVC.DAL.CRUD.PalletDescriptorOperations
{
    public class PalletDescriptorDAL : BaseDAL, IPalletDescriptorDAL
    {
        public PalletDescriptorDAL() : base()
        {
        }
        public PalletDescriptorDAL(ApplicationDbContext context) : base(context)
        {
        }

        public int Create(PalletDescriptor palletDescriptorToCreate)
        {
            if (palletDescriptorToCreate == null)
            {
                throw new Exception("The Pallet Descriptor sent in for creation is null.");
            }

            base.UpdateDateAdded(palletDescriptorToCreate);
            base.UpdateIsDeletedToFalse(palletDescriptorToCreate);

            db.PalletDescriptors.Add(palletDescriptorToCreate);
            db.SaveChanges();
            int idOfPalletDescriptor = palletDescriptorToCreate.ID;

            return idOfPalletDescriptor;
        }

        public void Delete(PalletDescriptor palletDescriptorToDelete)
        {
            Delete(palletDescriptorToDelete.ID);
        }

        private void Delete(int id)
        {
            PalletDescriptor palletDescriptorToDelete = db.PalletDescriptors.SingleOrDefault(i => i.ID == id);

            if (palletDescriptorToDelete == null)
            {
                throw new Exception("No Pallet Descriptors exists with the id " + id);
            }
            
            base.UpdateDateDeleted(palletDescriptorToDelete);
            base.UpdateIsDeletedToTrue(palletDescriptorToDelete);

            db.SaveChanges();
        }

        public void Delete(List<PalletDescriptor> palletDescriptorsToDelete)
        {
            if (palletDescriptorsToDelete == null)
            {
                throw new Exception("There were no Pallet Descriptors in the list to delete");
            }
            foreach (PalletDescriptor palletDescriptor in palletDescriptorsToDelete)
            {
                Delete(palletDescriptor);
            }
        }

        private void Destroy(int id)
        {
            PalletDescriptor palletDescriptorToDestroy = db.PalletDescriptors.SingleOrDefault(i => i.ID == id);

            if (palletDescriptorToDestroy == null)
            {
                throw new Exception("No Pallet Descriptor exists with the id " + id);
            }

            db.PalletDescriptors.Remove(palletDescriptorToDestroy);
            db.SaveChanges();
        }

        public void Destroy(PalletDescriptor palletDescriptorToDestroy)
        {
            Destroy(palletDescriptorToDestroy.ID);
        }

        private void Destroy(List<int> palletDescriptorsToDestroy)
        {
            if (palletDescriptorsToDestroy == null)
            {
                throw new Exception("There were no Pallet Descriptors in the list to destroy");
            }
            foreach (int palletDescriptorID in palletDescriptorsToDestroy)
            {
                Destroy(palletDescriptorID);
            }
        }

        public void Destroy(List<PalletDescriptor> palletDescriptorsToDestroy)
        {
            if (palletDescriptorsToDestroy == null)
            {
                throw new Exception("There were no Pallet Descriptors in the list to destroy");
            }
            foreach (PalletDescriptor palletDescriptor in palletDescriptorsToDestroy)
            {
                Destroy(palletDescriptor);
            }
        }

        public List<PalletDescriptor> Get()
        {
            List<PalletDescriptor> palletDescriptorsToReturn = db.PalletDescriptors.ToList();

            if (palletDescriptorsToReturn == null)
            {
                throw new Exception("No Pallet Descriptors exist in the database.");
            }

            return palletDescriptorsToReturn;
        }

        public PalletDescriptor Get(int id)
        {
            PalletDescriptor palletDescriptorToReturn = db.PalletDescriptors.SingleOrDefault(i => i.ID == id);

            if (palletDescriptorToReturn == null)
            {
                throw new Exception("No Pallet Descriptor exists with the id " + id);
            }

            return palletDescriptorToReturn;
        }

        public int Update(PalletDescriptor updatedPalletDescriptor)
        {
            var palletDescriptorToUpdate = Get(updatedPalletDescriptor.ID);
            palletDescriptorToUpdate?.Categories.Clear();
            if (palletDescriptorToUpdate == null)
            {
                throw new Exception("No Location exists with the id " + updatedPalletDescriptor.ID);
            }

            palletDescriptorToUpdate.Name = updatedPalletDescriptor.Name;

            base.UpdateDateUpdated(palletDescriptorToUpdate);

            db.PalletDescriptors.AddOrUpdate(p => p.ID, palletDescriptorToUpdate);
            db.SaveChanges();
            int idOfLocation = palletDescriptorToUpdate.ID;

            return idOfLocation;
        }
    }
}