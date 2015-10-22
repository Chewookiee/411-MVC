using FoamMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoamMVC.DAL.CRUD.LikeOperations
{
    public interface ILikeDAL
    {
        int Create(Like likeToCreate);
        List<Like> Get();
        Like Get(int id);
        int Update(Like updatedLike);
        void Delete(List<Like> likesToDelete);
        void Delete(List<int> likesToDelete);
        void Delete(Like likeToDelete);
        void Delete(int id);
        void Destroy(List<Like> likesToDestroy);
        void Destroy(List<int> likesToDestroy);
        void Destroy(Like likeToDestroy);
        void Destroy(int id);
    }
}
