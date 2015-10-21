using FoamMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoamMVC.DAL.CRUD.PalletDescriptorOperations
{
    public interface IPalletDescriptorCRUD
    {
        int Create(PalletDescriptor palletDescriptorToCreate);
        IList<PalletDescriptor> Get();
        PalletDescriptor Get(int id);
        int Update(PalletDescriptor updatedPalletDescriptor);
        void Delete(IList<PalletDescriptor> palletDescriptorsToDelete);
        void Delete(IList<int> palletDescriptorsToDelete);
        void Delete(PalletDescriptor palletDescriptorToDelete);
        void Delete(int id);
        void Destroy(IList<PalletDescriptor> palletDescriptorsToDestroy);
        void Destroy(IList<int> palletDescriptorsToDestroy);
        void Destroy(PalletDescriptor palletDescriptorToDestroy);
        void Destroy(int id);
    }
}
