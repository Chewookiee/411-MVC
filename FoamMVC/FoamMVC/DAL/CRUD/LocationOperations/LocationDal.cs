using FoamMVC.DAL.CRUD.BaseOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FoamMVC.Models;
using FoamMVC.Models.Context;
using System.Data.Entity.Migrations;

namespace FoamMVC.DAL.CRUD.LocationOperations
{
    public class LocationDAL : BaseDAL, ILocationDAL
    {
        public LocationDAL() : base()
        {
        }
        public LocationDAL(ApplicationDbContext context) : base(context)
        {
        }

        public int Create(Location locationToCreate)
        {
            if (locationToCreate == null)
            {
                throw new Exception("The Location sent in for creation is null.");
            }

            base.UpdateDateAdded(locationToCreate);
            base.UpdateIsDeletedToFalse(locationToCreate);

            db.Locations.Add(locationToCreate);
            db.SaveChanges();
            int idOfLocation = locationToCreate.ID;

            return idOfLocation;
        }

        public void Delete(Location locationToDelete)
        {
            Delete(locationToDelete.ID);
        }

        public void Delete(List<int> locationsToDelete)
        {
            if (locationsToDelete == null)
            {
                throw new Exception("There were no Locations in the list to delete");
            }
            foreach (int locationID in locationsToDelete)
            {
                Delete(locationID);
            }
        }

        public void Delete(int id)
        {
            Location locationToDelete = db.Locations.SingleOrDefault(i => i.ID == id);

            if (locationToDelete == null)
            {
                throw new Exception("No Locations exists with the id " + id);
            }

            base.UpdateDateDeleted(locationToDelete);
            base.UpdateIsDeletedToTrue(locationToDelete);

            db.SaveChanges();
        }

        public void Delete(List<Location> locationsToDelete)
        {
            if (locationsToDelete == null)
            {
                throw new Exception("There were no Locations in the list to delete");
            }
            foreach (Location location in locationsToDelete)
            {
                Delete(location);
            }
        }

        public void Destroy(int id)
        {
            Location locationToDestroy = db.Locations.SingleOrDefault(i => i.ID == id);

            if (locationToDestroy == null)
            {
                throw new Exception("No Location exists with the id " + id);
            }

            db.Locations.Remove(locationToDestroy);
            db.SaveChanges();
        }

        public void Destroy(Location locationToDestroy)
        {
            Destroy(locationToDestroy.ID);
        }

        public void Destroy(List<int> locationsToDestroy)
        {
            if (locationsToDestroy == null)
            {
                throw new Exception("There were no Locations in the list to destroy");
            }
            foreach (int locationID in locationsToDestroy)
            {
                Destroy(locationID);
            }
        }

        public void Destroy(List<Location> locationsToDestroy)
        {
            if (locationsToDestroy == null)
            {
                throw new Exception("There were no Locations in the list to destroy");
            }
            foreach (Location location in locationsToDestroy)
            {
                Destroy(location);
            }
        }

        public List<Location> Get()
        {
            List<Location> locationsToReturn = db.Locations.Where(l => l.IsDeleted == false).ToList();

            if (locationsToReturn == null)
            {
                throw new Exception("No Locations exist in the database.");
            }

            return locationsToReturn;
        }

        public Location Get(int id)
        {
            Location locationToReturn = db.Locations.SingleOrDefault(i => i.ID == id && i.IsDeleted == false);

            if (locationToReturn == null)
            {
                throw new Exception("No Location exists with the id " + id);
            }

            return locationToReturn;
        }
        
        public int Update(Location updatedLocation)
        {
            Location locationToUpdate = db.Locations.SingleOrDefault(i => i.ID == updatedLocation.ID && i.IsDeleted == false);

            if (locationToUpdate == null)
            {
                throw new Exception("No Location exists with the id " + updatedLocation.ID);
            }

            locationToUpdate.PrimaryLocation = updatedLocation.PrimaryLocation;
            locationToUpdate.SecondaryLocation = updatedLocation.SecondaryLocation;
            base.UpdateDateUpdated(locationToUpdate);
            
            db.Locations.AddOrUpdate(l => l.ID, locationToUpdate);
            db.SaveChanges();
            int idOfLocation = locationToUpdate.ID;

            return idOfLocation;
        }
    }
}