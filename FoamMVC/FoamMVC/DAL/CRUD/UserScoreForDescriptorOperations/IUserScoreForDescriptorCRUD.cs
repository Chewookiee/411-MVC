using FoamMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoamMVC.DAL.CRUD.UserScoreForDescriptorOperations
{
    public interface IUserScoreForDescriptorCRUD
    {
        int Create(UserScoreForDescriptor userScoreForDescriptorToCreate);
        IList<UserScoreForDescriptor> Get();
        UserScoreForDescriptor Get(int id);
        int Update(UserScoreForDescriptor updatedUserScoreForDescriptor);
        void Delete(IList<UserScoreForDescriptor> userScoreForDescriptorsToDelete);
        void Delete(IList<int> userScoreForDescriptorsToDelete);
        void Delete(UserScoreForDescriptor userScoreForDescriptorToDelete);
        void Delete(int id);
        void Destroy(IList<UserScoreForDescriptor> userScoreForDescriptorsToDestroy);
        void Destroy(IList<int> userScoreForDescriptorsToDestroy);
        void Destroy(UserScoreForDescriptor userScoreForDescriptorToDestroy);
        void Destroy(int id);
    }
}
