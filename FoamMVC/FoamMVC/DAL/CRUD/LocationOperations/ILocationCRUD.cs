using FoamMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoamMVC.DAL.CRUD.LocationOperations
{
    interface ILocationCRUD
    {
        int Create(Location locationToCreate);
        IList<Location> Get();
        Location Get(int id);
        int Update(Location updatedLocation);
        void Delete(IList<Location> locationsToDelete);
        void Delete(IList<int> locationsToDelete);
        void Delete(Location locationToDelete);
        void Delete(int id);
        void Destroy(IList<Location> locationsToDestroy);
        void Destroy(IList<int> locationsToDestroy);
        void Destroy(Location locationToDestroy);
        void Destroy(int id);
    }
}
