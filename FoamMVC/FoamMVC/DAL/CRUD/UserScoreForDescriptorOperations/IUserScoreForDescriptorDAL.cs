using FoamMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoamMVC.DAL.CRUD.UserScoreForDescriptorOperations
{
    public interface IUserScoreForDescriptorDAL
    {
        int Create(UserScoreForDescriptor userScoreForDescriptorToCreate);
        List<UserScoreForDescriptor> Get();
        UserScoreForDescriptor Get(int id);
        int Update(UserScoreForDescriptor updatedUserScoreForDescriptor);
        void Delete(List<UserScoreForDescriptor> userScoreForDescriptorsToDelete);
        void Delete(List<int> userScoreForDescriptorsToDelete);
        void Delete(UserScoreForDescriptor userScoreForDescriptorToDelete);
        void Delete(int id);
        void Destroy(List<UserScoreForDescriptor> userScoreForDescriptorsToDestroy);
        void Destroy(List<int> userScoreForDescriptorsToDestroy);
        void Destroy(UserScoreForDescriptor userScoreForDescriptorToDestroy);
        void Destroy(int id);
    }
}
