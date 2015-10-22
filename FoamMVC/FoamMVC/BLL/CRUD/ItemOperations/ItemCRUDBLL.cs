using FoamMVC.DAL.CRUD.ItemOperations;
using FoamMVC.Models;
using FoamMVC.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace FoamMVC.BLL.CRUD.ItemOperations
{
    public class ItemCRUDBLL
    {
        private readonly ItemCRUD _itemCRUD;
        public ItemCRUDBLL()
        {
            _itemCRUD = new ItemCRUD();
        }
        #region Gets
        public IList<ItemViewModel> GetItemsNameAndID()
        {
            var itemsToReturn = _itemCRUD.Get().Select(x => new ItemViewModel
            {
                ItemID = x.ID,
                Name = x.Name
            });

            return itemsToReturn.ToList();
        }

        public IList<ItemDisplayViewModel> GetAllItemsForClient()
        {
            var itemsToReturn = _itemCRUD.Get().Select(x => new ItemDisplayViewModel
            {
                ID = x.ID,
                ItemName = x.Name,
                CompanyName = x.Company.Name,
                StockCount = x.StockCount,
                ItemPrice = x.ItemPrice
            });
            return itemsToReturn.ToList();
        }

        public ItemDisplaySingleViewModel GetSingleItemForDisplayByID(int id)
        {
            return ConvertEntityToDisplaySingleViewModel(_itemCRUD.Get(id));
            
        }
        #endregion

        #region Create/Update
        public int CreateItem(ItemViewModel viewModel)
        {
            return _itemCRUD.Create(ConvertViewModelToEntity(viewModel));
        }

        public int UpdateItem(ItemViewModel viewModel)
        {
            return _itemCRUD.Update(ConvertViewModelToEntity(viewModel));
        } 
        #endregion
        #region Delete/Destroy
        public void DeleteItem(ItemViewModel viewModel)
        {
            _itemCRUD.Create(ConvertViewModelToEntity(viewModel));
        }

        public void DeleteItems(List<ItemViewModel> viewModels)
        {
            var items = viewModels.Select(ConvertViewModelToEntity).ToList();
            _itemCRUD.Delete(items);
        }

        public void DestroyItem(ItemViewModel viewModel)
        {
            _itemCRUD.Destroy(ConvertViewModelToEntity(viewModel));
        }

        public void DestroyItems(List<ItemViewModel> viewModels)
        {
            var items = viewModels.Select(ConvertViewModelToEntity).ToList();
            _itemCRUD.Destroy(items);

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
                Likes = viewModel.Likes
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