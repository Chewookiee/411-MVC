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
    public class LocationCRUD : BaseCRUD, ILocationCRUD
    {
        public LocationCRUD() : base()
        {
        }
        public LocationCRUD(ApplicationDbContext context) : base(context)
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

        public void Delete(IList<int> locationsToDelete)
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

        public void Delete(IList<Location> locationsToDelete)
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

        public void Destroy(IList<int> locationsToDestroy)
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

        public void Destroy(IList<Location> locationsToDestroy)
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

        public IList<Location> Get()
        {
            IList<Location> locationsToReturn = db.Locations.ToList();

            if (locationsToReturn == null)
            {
                throw new Exception("No Locations exist in the database.");
            }

            return locationsToReturn;
        }

        public Location Get(int id)
        {
            Location locationToReturn = db.Locations.SingleOrDefault(i => i.ID == id);

            if (locationToReturn == null)
            {
                throw new Exception("No Location exists with the id " + id);
            }

            return locationToReturn;
        }
        
        public int Update(Location updatedLocation)
        {
            Location locationToUpdate = db.Locations.SingleOrDefault(i => i.ID == updatedLocation.ID);

            if (locationToUpdate == null)
            {
                throw new Exception("No Location exists with the id " + updatedLocation.ID);
            }

            base.UpdateDateUpdated(updatedLocation);
            
            db.Locations.AddOrUpdate(l => l.ID, updatedLocation);
            db.SaveChanges();
            int idOfLocation = updatedLocation.ID;

            return idOfLocation;
        }
    }
}