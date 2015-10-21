using FoamMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoamMVC.DAL.CRUD.CompanyOperations
{
    public interface ICompanyCRUD
    {
        int Create(Company companyToCreate);
        IList<Company> Get();
        Company Get(int id);
        Company Get(Company companyToGet);
        Company Get(string name);
        int Update(Company updatedCompany);
        void Delete(IList<Company> companiesToDelete);
        void Delete(IList<int> companiessToDelete);
        void Delete(Company companyToDelete);
        void Delete(int id);
        void Destroy(IList<Company> companiesToDestroy);
        void Destroy(IList<int> companiesToDestroy);
        void Destroy(Company companyToDestroy);
        void Destroy(int id);
    }
}