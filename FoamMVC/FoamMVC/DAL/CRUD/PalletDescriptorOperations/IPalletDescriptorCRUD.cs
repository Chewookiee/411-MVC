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
        List<PalletDescriptor> Get();
        PalletDescriptor Get(int id);
        int Update(PalletDescriptor updatedPalletDescriptor);
        void Delete(List<PalletDescriptor> palletDescriptorsToDelete);
        void Delete(PalletDescriptor palletDescriptorToDelete);
        void Destroy(List<PalletDescriptor> palletDescriptorsToDestroy);
        void Destroy(PalletDescriptor palletDescriptorToDestroy);
    }
}
