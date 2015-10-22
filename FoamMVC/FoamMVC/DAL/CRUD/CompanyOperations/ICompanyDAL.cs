using FoamMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoamMVC.DAL.CRUD.CompanyOperations
{
    public interface ICompanyDAL
    {
        int Create(Company companyToCreate);
        List<Company> Get();
        Company Get(int id);
        Company Get(Company companyToGet);
        Company Get(string name);
        int Update(Company updatedCompany);
        void Delete(List<Company> companiesToDelete);
        void Delete(List<int> companiessToDelete);
        void Delete(Company companyToDelete);
        void Delete(int id);
        void Destroy(List<Company> companiesToDestroy);
        void Destroy(List<int> companiesToDestroy);
        void Destroy(Company companyToDestroy);
        void Destroy(int id);
    }
}