using FoamMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoamMVC.DAL.CRUD.TagOperations
{
    interface ITagDAL
    {
        int Create(Tag tagToCreate);
        List<Tag> Get();
        Tag Get(int id);
        Tag Get(Tag tagToGet);
        Tag Get(string name);
        int Update(Tag updatedTag);
        void Delete(List<Tag> categoriesToDelete);
        void Delete(List<int> categoriesToDelete);
        void Delete(Tag tagToDelete);
        void Delete(int id);
        void Destroy(List<Tag> categoriesToDestroy);
        void Destroy(List<int> categoriesToDestroy);
        void Destroy(Tag tagToDestroy);
        void Destroy(int id);
    }
}
