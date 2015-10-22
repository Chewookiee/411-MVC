using FoamMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoamMVC.DAL.CRUD.ReviewScoreForDescriptorOperations
{
    public interface IReviewScoreForDescriptorDAL
    {
        int Create(ReviewScoreForDescriptor reviewScoreForDescriptorToCreate);
        List<ReviewScoreForDescriptor> Get();
        ReviewScoreForDescriptor Get(int id);
        int Update(ReviewScoreForDescriptor updatedReviewScoreForDescriptor);
        void Delete(List<ReviewScoreForDescriptor> reviewScoreForDescriptorsToDelete);
        void Delete(List<int> reviewScoreForDescriptorsToDelete);
        void Delete(ReviewScoreForDescriptor reviewScoreForDescriptorToDelete);
        void Delete(int id);
        void Destroy(List<ReviewScoreForDescriptor> reviewScoreForDescriptorsToDestroy);
        void Destroy(List<int> reviewScoreForDescriptorsToDestroy);
        void Destroy(ReviewScoreForDescriptor reviewScoreForDescriptorToDestroy);
        void Destroy(int id);
    }
}
