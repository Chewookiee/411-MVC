using FoamMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoamMVC.DAL.CRUD.ReviewScoreForDescriptorOperations
{
    public interface IReviewScoreForDescriptorCRUD
    {
        int Create(ReviewScoreForDescriptor reviewScoreForDescriptorToCreate);
        IList<ReviewScoreForDescriptor> Get();
        ReviewScoreForDescriptor Get(int id);
        int Update(ReviewScoreForDescriptor updatedReviewScoreForDescriptor);
        void Delete(IList<ReviewScoreForDescriptor> reviewScoreForDescriptorsToDelete);
        void Delete(IList<int> reviewScoreForDescriptorsToDelete);
        void Delete(ReviewScoreForDescriptor reviewScoreForDescriptorToDelete);
        void Delete(int id);
        void Destroy(IList<ReviewScoreForDescriptor> reviewScoreForDescriptorsToDestroy);
        void Destroy(IList<int> reviewScoreForDescriptorsToDestroy);
        void Destroy(ReviewScoreForDescriptor reviewScoreForDescriptorToDestroy);
        void Destroy(int id);
    }
}
