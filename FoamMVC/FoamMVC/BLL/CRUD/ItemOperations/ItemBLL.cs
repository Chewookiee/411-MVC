using System;
using FoamMVC.DAL.CRUD.ItemOperations;
using FoamMVC.Models;
using FoamMVC.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using FoamMVC.DTOs;
using FoamMVC.ExtensionMethods;

namespace FoamMVC.BLL.CRUD.ItemOperations
{
    public class ItemBLL
    {
        private readonly IItemDAL _itemDal;
        public ItemBLL()
        {
            _itemDal = new ItemDAL();
        }
        #region Gets
        public List<ItemViewModel> GetItemsNameAndID()
        {
            var itemsToReturn = _itemDal.Get().Select(x => new ItemViewModel
            {
                ItemID = x.ID,
                Name = x.Name
            });

            return itemsToReturn.ToList();
        }

        public ItemViewModel GetItemByUPC(string UPC)
        {
            try
            {
                return ConvertEntityToViewModel(_itemDal.Get(UPC));
            }
            catch (Exception)
            {
                return null;
            }

        }

        public List<ItemDisplayViewModel> GetAllItemsForClient()
        {
            var itemsToReturn = _itemDal.Get().Select(x => new ItemDisplayViewModel
            {
                ID = x.ID,
                ItemName = x.Name,
                CompanyName = x.Company.Name,
                StockCount = x.StockCount,
                ItemPrice = x.ItemPrice.AsCurrency(),
                ImagePath = x.ImagePath
            });
            return itemsToReturn.ToList();
        }

        public ItemDisplaySingleViewModel GetSingleItemForDisplayByID(int id)
        {
            return ConvertEntityToDisplaySingleViewModel(_itemDal.Get(id));

        }
        #endregion

        #region Create/Update
        public int CreateItem(ItemViewModel viewModel)
        {
            return _itemDal.Create(ConvertViewModelToEntity(viewModel));
        }

        public int UpdateFromStagedItem(StagedItemDTO staged)
        {
            var matchingEntity = _itemDal.Get(staged.UPC);

            matchingEntity.StockCount = staged.StockCount;
            matchingEntity.ItemPrice = staged.ItemPrice;

            return _itemDal.Update(matchingEntity);

        }
        public int UpdateItem(ItemViewModel viewModel)
        {
            return _itemDal.Update(ConvertViewModelToEntity(viewModel));
        }
        #endregion
        #region Delete/Destroy
        public void DeleteItem(ItemViewModel viewModel)
        {
            _itemDal.Create(ConvertViewModelToEntity(viewModel));
        }

        public void DeleteItems(List<ItemViewModel> viewModels)
        {
            var items = viewModels.Select(ConvertViewModelToEntity).ToList();
            _itemDal.Delete(items);
        }

        public void DestroyItem(ItemViewModel viewModel)
        {
            _itemDal.Destroy(ConvertViewModelToEntity(viewModel));
        }

        public void DestroyItems(List<ItemViewModel> viewModels)
        {
            var items = viewModels.Select(ConvertViewModelToEntity).ToList();
            _itemDal.Destroy(items);

        }
        #endregion

        #region Utils

        private Item ConvertViewModelToEntity(ItemViewModel viewModel)
        {
            return new Item
            {
                PalletGroupID = viewModel.PalletGroupID,
                CompanyID = viewModel.CompanyID,
                CategoryID = viewModel.CategoryID,
                Name = viewModel.Name,
                UPC = viewModel.UPC,
                IsFeatured = viewModel.IsFeautured,
                ImagePath = viewModel.ImagePath,
                Reviews = viewModel.Reviews,
                Tags = viewModel.Tags,
                Likes = viewModel.Likes,
                StockCount = viewModel.StockCount,
                ItemPrice = viewModel.ItemPrice
            };
        }
        private ItemViewModel ConvertEntityToViewModel(Item entity)
        {
            return new ItemViewModel
            {
                PalletGroupID = entity.PalletGroupID,
                CompanyID = entity.CompanyID,
                CategoryID = entity.CategoryID,
                Name = entity.Name,
                UPC = entity.UPC,
                ImagePath = entity.ImagePath,
                Reviews = entity.Reviews,
                Tags = entity.Tags,
                Likes = entity.Likes

            };
        }

        private ItemDisplaySingleViewModel ConvertEntityToDisplaySingleViewModel(Item entity)
        {

            return new ItemDisplaySingleViewModel
            {
                ID = entity.ID,
                ItemName = entity.Name,
                CategoryName = entity.Category.Name,
                CompanyName = entity.Company.Name,
                Location = IsSecondaryLocationNull(entity.Company.Location.SecondaryLocation) + entity.Company.Location.PrimaryLocation,
                ImagePath = entity.ImagePath,
                StockCount = entity.StockCount,
                ItemPrice = entity.ItemPrice,
                Tags = entity.Tags.Select(x => x.Name).ToList(),
                PalletDescriptors =
                    entity.PalletGroup.PalletDescriptors.Select(x => new PalletDescriptorDisplayViewModel
                    {
                        PalletDescriptorID = x.ID,
                        PalletDescriptorName = x.Name
                    }).ToList()
            };
        }

        private string IsSecondaryLocationNull(string secondaryLocation)
        {
            if (secondaryLocation != null)
            {
                secondaryLocation = secondaryLocation + ", ";
            }
            return secondaryLocation;
        }
        #endregion
    }
}