using FoamMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoamMVC.DAL.CRUD.CategoryOperations
{
    interface ICategoryCRUD
    {
        int Create(Category categoryToCreate);
        IList<Category> Get();
        Category Get(int id);
        Category Get(Category categoryToGet);
        Category Get(string name);
        int Update(Category updatedCategory);
        void Delete(IList<Category> categoriesToDelete);
        void Delete(IList<int> categoriesToDelete);
        void Delete(Category categoryToDelete);
        void Delete(int id);
        void Destroy(IList<Category> categoriesToDestroy);
        void Destroy(IList<int> categoriesToDestroy);
        void Destroy(Category categoryToDestroy);
        void Destroy(int id);
    }
}
