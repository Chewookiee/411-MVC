using FoamMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoamMVC.DAL.CRUD.CategoryOperations
{
    interface ICategoryDAL
    {
        int Create(Category categoryToCreate);
        List<Category> Get();
        Category Get(int id);
        Category Get(Category categoryToGet);
        Category Get(string name);
        int Update(Category updatedCategory);
        void Delete(List<Category> categoriesToDelete);
        void Delete(List<int> categoriesToDelete);
        void Delete(Category categoryToDelete);
        void Delete(int id);
        void Destroy(List<Category> categoriesToDestroy);
        void Destroy(List<int> categoriesToDestroy);
        void Destroy(Category categoryToDestroy);
        void Destroy(int id);
    }
}
