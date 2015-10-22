using FoamMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoamMVC.DAL.CRUD.LocationOperations
{
    interface ILocationDAL
    {
        int Create(Location locationToCreate);
        List<Location> Get();
        Location Get(int id);
        int Update(Location updatedLocation);
        void Delete(List<Location> locationsToDelete);
        void Delete(List<int> locationsToDelete);
        void Delete(Location locationToDelete);
        void Delete(int id);
        void Destroy(List<Location> locationsToDestroy);
        void Destroy(List<int> locationsToDestroy);
        void Destroy(Location locationToDestroy);
        void Destroy(int id);
    }
}
