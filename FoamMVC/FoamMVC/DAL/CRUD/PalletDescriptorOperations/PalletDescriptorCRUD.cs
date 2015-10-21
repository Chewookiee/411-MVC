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
    public class PalletDescriptorCRUD : BaseCRUD, IPalletDescriptorCRUD
    {
        public PalletDescriptorCRUD() : base()
        {
        }
        public PalletDescriptorCRUD(ApplicationDbContext context) : base(context)
        {
        }

        public int Create(PalletDescriptor palletDescriptorToCreate)
        {
            if (palletDescriptorToCreate == null)
            {
                throw new Exception("The Pallet Descriptor sent in for creation is null.");
            }
            db.PalletDescriptors.Add(palletDescriptorToCreate);
            int idOfPalletDescriptor = db.SaveChanges();

            return idOfPalletDescriptor;
        }

        public void Delete(IList<int> palletDescriptorsToDelete)
        {
            throw new NotImplementedException();
        }

        public void Delete(PalletDescriptor palletDescriptorToDelete)
        {
            Delete(palletDescriptorToDelete.ID);
        }

        public void Delete(int id)
        {
            PalletDescriptor palletDescriptorToDelete;
            palletDescriptorToDelete = db.PalletDescriptors.SingleOrDefault(i => i.ID == id);

            if (palletDescriptorToDelete == null)
            {
                throw new Exception("No Pallet Descriptors exists with the id " + id);
            }

            palletDescriptorToDelete.IsDeleted = true;
            db.SaveChanges();
        }

        public void Delete(IList<PalletDescriptor> palletDescriptorsToDelete)
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

        public void Destroy(int id)
        {
            PalletDescriptor palletDescriptorToDestroy;
            palletDescriptorToDestroy = db.PalletDescriptors.SingleOrDefault(i => i.ID == id);

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

        public void Destroy(IList<int> palletDescriptorsToDestroy)
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

        public void Destroy(IList<PalletDescriptor> palletDescriptorsToDestroy)
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

        public IList<PalletDescriptor> Get()
        {
            IList<PalletDescriptor> palletDescriptorsToReturn;
            palletDescriptorsToReturn = db.PalletDescriptors.ToList();

            if (palletDescriptorsToReturn == null)
            {
                throw new Exception("No Pallet Descriptors exist in the database.");
            }

            return palletDescriptorsToReturn;
        }

        public PalletDescriptor Get(int id)
        {
            PalletDescriptor palletDescriptorToReturn;
            palletDescriptorToReturn = db.PalletDescriptors.SingleOrDefault(i => i.ID == id);

            if (palletDescriptorToReturn == null)
            {
                throw new Exception("No Pallet Descriptor exists with the id " + id);
            }

            return palletDescriptorToReturn;
        }

        public int Update(PalletDescriptor updatedPalletDescriptor)
        {
            PalletDescriptor palletDescriptorToUpdate;
            palletDescriptorToUpdate = db.PalletDescriptors.SingleOrDefault(i => i.ID == updatedPalletDescriptor.ID);

            if (palletDescriptorToUpdate == null)
            {
                throw new Exception("No Location exists with the id " + updatedPalletDescriptor.ID);
            }

            db.PalletDescriptors.AddOrUpdate(p => p.ID, updatedPalletDescriptor);
            int idOfLocation = db.SaveChanges();

            return idOfLocation;
        }
    }
}