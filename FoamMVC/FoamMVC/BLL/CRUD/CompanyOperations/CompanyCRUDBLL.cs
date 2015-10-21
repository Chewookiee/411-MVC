using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FoamMVC.DAL.CRUD.CompanyOperations;
using FoamMVC.Models;
using FoamMVC.ViewModels;

namespace FoamMVC.BLL.CRUD.CompanyOperations
{
    public class CompanyCRUDBLL
    {
        private readonly CompanyCRUD _companyCRUD;
        public CompanyCRUDBLL()
        {
            _companyCRUD = new CompanyCRUD();
        }
        #region Gets
        public IList<CompanyViewModel> GetItemsNameAndID()
        {
            var itemsToReturn = _companyCRUD.Get().Select(x => new CompanyViewModel
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
            return _companyCRUD.Create(new Company
            {
                Name = viewModel.Name,
                LocationID = viewModel.LocationID,
                Description = viewModel.Description
            });
        }

        public int UpdateItem(CompanyViewModel viewModel)
        {
            return _companyCRUD.Update(ConvertViewModelToEntity(viewModel));
        }
        #endregion
        #region Delete/Destroy
        public void DeleteItem(CompanyViewModel viewModel)
        {
            _companyCRUD.Create(ConvertViewModelToEntity(viewModel));
        }

        public void DeleteItems(List<CompanyViewModel> viewModels)
        {
            var items = viewModels.Select(ConvertViewModelToEntity).ToList();
            _companyCRUD.Delete(items);
        }

        public void DestroyItem(CompanyViewModel viewModel)
        {
            _companyCRUD.Destroy(ConvertViewModelToEntity(viewModel));
        }

        public void DestroyItems(List<CompanyViewModel> viewModels)
        {
            var items = viewModels.Select(ConvertViewModelToEntity).ToList();
            _companyCRUD.Destroy(items);

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