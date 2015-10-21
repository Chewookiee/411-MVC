using FoamMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoamMVC.DAL.CRUD.PalletGroupOperations
{
    public interface IPalletGroupCRUD
    {
        int Create(PalletGroup palletGroupToCreate);
        IList<PalletGroup> Get();
        PalletGroup Get(int id);
        PalletGroup Get(PalletGroup palletGroupToGet);
        PalletGroup Get(string name);
        int Update(PalletGroup updatedPalletGroup);
        void Delete(IList<PalletGroup> palletGroupsToDelete);
        void Delete(IList<int> palletGroupsToDelete);
        void Delete(PalletGroup palletGroupToDelete);
        void Delete(int id);
        void Destroy(IList<PalletGroup> palletGroupsToDestroy);
        void Destroy(IList<int> palletGroupsToDestroy);
        void Destroy(PalletGroup palletGroupToDestroy);
        void Destroy(int id);
    }
}