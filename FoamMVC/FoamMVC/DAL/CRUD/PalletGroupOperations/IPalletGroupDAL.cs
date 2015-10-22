using FoamMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoamMVC.DAL.CRUD.PalletGroupOperations
{
    public interface IPalletGroupDAL
    {
        int Create(PalletGroup palletGroupToCreate);
        List<PalletGroup> Get();
        PalletGroup Get(int id);
        PalletGroup Get(PalletGroup palletGroupToGet);
        PalletGroup Get(string name);
        int Update(PalletGroup updatedPalletGroup);
        void Delete(List<PalletGroup> palletGroupsToDelete);
        void Delete(List<int> palletGroupsToDelete);
        void Delete(PalletGroup palletGroupToDelete);
        void Delete(int id);
        void Destroy(List<PalletGroup> palletGroupsToDestroy);
        void Destroy(List<int> palletGroupsToDestroy);
        void Destroy(PalletGroup palletGroupToDestroy);
        void Destroy(int id);
    }
}