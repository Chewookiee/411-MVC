using FoamMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoamMVC.DAL.CRUD.TagOperations
{
    interface ITagCRUD
    {
        int Create(Tag tagToCreate);
        IList<Tag> Get();
        Tag Get(int id);
        Tag Get(Tag tagToGet);
        Tag Get(string name);
        int Update(Tag updatedTag);
        void Delete(IList<Tag> categoriesToDelete);
        void Delete(IList<int> categoriesToDelete);
        void Delete(Tag tagToDelete);
        void Delete(int id);
        void Destroy(IList<Tag> categoriesToDestroy);
        void Destroy(IList<int> categoriesToDestroy);
        void Destroy(Tag tagToDestroy);
        void Destroy(int id);
    }
}
