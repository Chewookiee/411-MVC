using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FoamMVC.BLL.CRUD.CategoryOperations;
using FoamMVC.DAL.CRUD.CategoryOperations;
using FoamMVC.DAL.CRUD.PalletDescriptorOperations;
using FoamMVC.Models;
using FoamMVC.ViewModels;

namespace FoamMVC.BLL.CRUD.PalletDescriptorOperation
{
    public class PalletDescriptorBLL
    {
        private readonly IPalletDescriptorCRUD _palletDescriptorCRUD;
        private readonly CategoryCRUDBLL _categoryCrudbll;

        public PalletDescriptorBLL()
        {
            _palletDescriptorCRUD = new PalletDescriptorCRUD();
            _categoryCrudbll = new CategoryCRUDBLL();
        }

        public PalletDescriptorViewModel Get(int id)
        {
            var shti = _palletDescriptorCRUD.Get(id);
            return ConvertEntityToViewModel(shti);
        }

        public PalletDescriptorDisplayViewModel.PalledDescriptorUpdateViewModel GetForUpdate(int id)
        {
            return CreateUpdateViewModel(_palletDescriptorCRUD.Get(id));
        }

        public List<PalletDescriptorViewModel> Get()
        {
            return ConvertEntitiesToViewModels(_palletDescriptorCRUD.Get());
        } 

        #region create/update

        public int CreatePalletDescriptor(PalletDescriptorViewModel viewModel)
        {
            return _palletDescriptorCRUD.Create(ConvertViewModelToEntity(viewModel));
        }

        public int Update(PalletDescriptorDisplayViewModel.PalledDescriptorUpdateViewModel viewModel)
        {
            return _palletDescriptorCRUD.Update(ConvertUpdateViewModelToEntity(viewModel));
        } 
        #endregion

        #region delete/destroy

        public void Delete(PalletDescriptorViewModel viewModel)
        {
            _palletDescriptorCRUD.Delete(ConvertViewModelToEntity(viewModel));
        }

        public void Delete(List<PalletDescriptorViewModel> viewModel)
        {
            _palletDescriptorCRUD.Delete(ConvertViewModelToEntity(viewModel));
        }

        public void Destroy(PalletDescriptorViewModel viewModel)
        {
            _palletDescriptorCRUD.Destroy(ConvertViewModelToEntity(viewModel));
        }

        public void Destroy(List<PalletDescriptorViewModel> viewModel)
        {
            _palletDescriptorCRUD.Destroy(ConvertViewModelToEntity(viewModel));
        }
        #endregion

        #region utils

        private PalletDescriptor ConvertUpdateViewModelToEntity(PalletDescriptorDisplayViewModel.PalledDescriptorUpdateViewModel viewModel)
        {
            var categoryDAL = new CategoryCRUD();

            var entity = new PalletDescriptor
            {
                ID = viewModel.ID,
                Name = viewModel.Name,
                Categories = new List<Category>()
            };
            foreach (var selectedCategory in viewModel.SelectedCategories)
            {
                entity.Categories.Add(categoryDAL.Get(selectedCategory));
            }
            return entity;
        }
        private PalletDescriptorDisplayViewModel.PalledDescriptorUpdateViewModel CreateUpdateViewModel(PalletDescriptor entity)
        {
            return new PalletDescriptorDisplayViewModel.PalledDescriptorUpdateViewModel
            {
                ID = entity.ID,
                Name = entity.Name,
                AllCategories = _categoryCrudbll.GetDropDownDisplayForCategory()
        };
        }

        private PalletDescriptor ConvertViewModelToEntity(PalletDescriptorViewModel viewModel)
        {
            return new PalletDescriptor
            {
                ID = viewModel.ID,
                Name = viewModel.Name
            };
        }

        private List<PalletDescriptor> ConvertViewModelToEntity(List<PalletDescriptorViewModel> viewModels)
        {
            return viewModels.Select(x => new PalletDescriptor
            {
                ID = x.ID,
                Name = x.Name
            }).ToList();
        }

        private PalletDescriptorViewModel ConvertEntityToViewModel(PalletDescriptor entity)
        {
            return new PalletDescriptorViewModel
            {
                Categories = entity.Categories.ToList(),
                Name = entity.Name,
                ID = entity.ID,
            };
        }

        private List<PalletDescriptorViewModel> ConvertEntitiesToViewModels(List<PalletDescriptor> entities)
        {
            return entities.Select(x => new PalletDescriptorViewModel
            {
                Categories = x.Categories.ToList(),
                Name = x.Name,
                ID = x.ID,
            }).ToList();
        }
        #endregion
    }
}