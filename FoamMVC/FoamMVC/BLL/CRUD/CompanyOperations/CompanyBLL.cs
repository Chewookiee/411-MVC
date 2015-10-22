using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FoamMVC.DAL.CRUD.CompanyOperations;
using FoamMVC.Models;
using FoamMVC.ViewModels;

namespace FoamMVC.BLL.CRUD.CompanyOperations
{
    public class CompanyBLL
    {
        private readonly ICompanyDAL _companyDal;
        public CompanyBLL()
        {
            _companyDal = new CompanyDAL();
        }
        #region Gets
        public IList<CompanyViewModel> GetItemsNameAndID()
        {
            var itemsToReturn = _companyDal.Get().Select(x => new CompanyViewModel
            {
                CompanyID = x.ID,
                Name = x.Name
            });

            return itemsToReturn.ToList();
        }
        #endregion

        #region Create/Update
        public int CreateCompany(CompanyCreateViewModel viewModel)
        {
            return _companyDal.Create(new Company
            {
                Name = viewModel.Name,
                LocationID = viewModel.LocationID,
                Description = viewModel.Description
            });
        }

        public int UpdateItem(CompanyViewModel viewModel)
        {
            return _companyDal.Update(ConvertViewModelToEntity(viewModel));
        }
        #endregion
        #region Delete/Destroy
        public void DeleteItem(CompanyViewModel viewModel)
        {
            _companyDal.Create(ConvertViewModelToEntity(viewModel));
        }

        public void DeleteItems(List<CompanyViewModel> viewModels)
        {
            var items = viewModels.Select(ConvertViewModelToEntity).ToList();
            _companyDal.Delete(items);
        }

        public void DestroyItem(CompanyViewModel viewModel)
        {
            _companyDal.Destroy(ConvertViewModelToEntity(viewModel));
        }

        public void DestroyItems(List<CompanyViewModel> viewModels)
        {
            var items = viewModels.Select(ConvertViewModelToEntity).ToList();
            _companyDal.Destroy(items);

        }
        #endregion

        #region Utils

        private Company ConvertViewModelToEntity(CompanyViewModel viewModel)
        {
            return new Company
            {
                ID = viewModel.CompanyID,
                LocationID = viewModel.LocationID,
                Name = viewModel.Name,
                Description = viewModel.Description
            };
        }

        
        #endregion
    }
}