using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FoamMVC.Models;
using FoamMVC.Models.Context;
using FoamMVC.DAL.CRUD.BaseOperations;
using System.Data.Entity.Migrations;

namespace FoamMVC.DAL.CRUD.CompanyOperations
{
    public class CompanyDAL : BaseDAL, ICompanyDAL
    {
        public CompanyDAL() : base()
        {
        }
        public CompanyDAL(ApplicationDbContext context) : base(context)
        {
        }

        public int Create(Company companyToCreate)
        {
            if (companyToCreate == null)
            {
                throw new Exception("The Company sent in for creation is null.");
            }
            
            base.UpdateDateAdded(companyToCreate);
            base.UpdateIsDeletedToFalse(companyToCreate);

            db.Companies.Add(companyToCreate);
            db.SaveChanges();
            int idOfCompany = companyToCreate.ID;

            return idOfCompany;
        }

        public void Delete(int id)
        {
            Company companyToDelete = db.Companies.SingleOrDefault(c => c.ID == id && c.IsDeleted == false);

            if (companyToDelete == null)
            {
                throw new Exception("No Company exists with the id " + id);
            }

            base.UpdateDateDeleted(companyToDelete);
            base.UpdateIsDeletedToTrue(companyToDelete);
            db.SaveChanges();
        }

        public void Delete(Company companyToDelete)
        {
            Delete(companyToDelete.ID);
        }

        public void Delete(List<int> companiessToDelete)
        {
            if (companiessToDelete == null)
            {
                throw new Exception("There were no Companies in the list to delete");
            }
            foreach (int companyID in companiessToDelete)
            {
                Delete(companyID);
            }
        }

        public void Delete(List<Company> companiesToDelete)
        {
            if (companiesToDelete == null)
            {
                throw new Exception("There were no Companies in the list to delete");
            }
            foreach (Company company in companiesToDelete)
            {
                Delete(company);
            }
        }

        public void Destroy(List<int> companiesToDestroy)
        {
            if (companiesToDestroy == null)
            {
                throw new Exception("There were no Companies in the list to destroy");
            }
            foreach (int companyID in companiesToDestroy)
            {
                Destroy(companyID);
            }
        }

        public void Destroy(int id)
        {
            Company companyToDestroy = db.Companies.SingleOrDefault(c => c.ID == id);

            if (companyToDestroy == null)
            {
                throw new Exception("No Company exists with the id " + id);
            }

            db.Companies.Remove(companyToDestroy);
            db.SaveChanges();
        }

        public void Destroy(Company companyToDestroy)
        {
            Destroy(companyToDestroy.ID);
        }

        public void Destroy(List<Company> companiesToDestroy)
        {
            if (companiesToDestroy == null)
            {
                throw new Exception("There were no Companies in the list to destroy");
            }
            foreach (Company company in companiesToDestroy)
            {
                Destroy(company);
            }
        }

        public List<Company> Get()
        {
<<<<<<< HEAD:FoamMVC/FoamMVC/DAL/CRUD/CompanyOperations/CompanyCRUD.cs
            IList<Company> companiesToReturn = db.Companies.Where(c => c.IsDeleted == false).ToList();
=======
            List<Company> companiesToReturn = db.Companies.ToList();
>>>>>>> 915ff1224ce01fdde97b367b7d18b87f664de4c6:FoamMVC/FoamMVC/DAL/CRUD/CompanyOperations/CompanyDAL.cs

            if (companiesToReturn == null)
            {
                throw new Exception("No Companies exist in the database.");
            }

            return companiesToReturn;
        }



        public Company Get(int id)
        {
            Company companyToReturn = db.Companies.SingleOrDefault(c => c.ID == id && c.IsDeleted == false);

            if (companyToReturn == null)
            {
                throw new Exception("No Company exists with the id " + id);
            }

            return companyToReturn;
        }

        public Company Get(string name)
        {
            Company companyToReturn = db.Companies.SingleOrDefault(c => c.Name.Equals(name) && c.IsDeleted == false);

            if (companyToReturn == null)
            {
                throw new Exception("No Company exists with the name " + name);
            }

            return companyToReturn;
        }

        public Company Get(Company companyToGet)
        {
            return Get(companyToGet.Name);
        }

        public int Update(Company updatedCompany)
        {
            Company companyToUpdate;
            companyToUpdate = db.Companies.SingleOrDefault(c => c.ID == updatedCompany.ID && c.IsDeleted == false);

            if (companyToUpdate == null)
            {
                throw new Exception("No Company exists with the id " + updatedCompany.ID);
            }

            base.UpdateDateUpdated(updatedCompany);

            db.Companies.AddOrUpdate(c => c.ID, updatedCompany);
            db.SaveChanges();
            int idOfCompany = updatedCompany.ID;

            return idOfCompany;
        }
    }
}