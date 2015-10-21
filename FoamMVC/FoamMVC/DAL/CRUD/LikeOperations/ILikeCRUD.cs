using FoamMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoamMVC.DAL.CRUD.LikeOperations
{
    public interface ILikeCRUD
    {
        int Create(Like likeToCreate);
        IList<Like> Get();
        Like Get(int id);
        int Update(Like updatedLike);
        void Delete(IList<Like> likesToDelete);
        void Delete(IList<int> likesToDelete);
        void Delete(Like likeToDelete);
        void Delete(int id);
        void Destroy(IList<Like> likesToDestroy);
        void Destroy(IList<int> likesToDestroy);
        void Destroy(Like likeToDestroy);
        void Destroy(int id);
    }
}
