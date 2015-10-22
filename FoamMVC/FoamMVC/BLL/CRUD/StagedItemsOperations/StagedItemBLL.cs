using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FoamMVC.BLL.CRUD.ItemOperations;
using FoamMVC.DAL.CRUD.ItemOperations;
using FoamMVC.DAL.CRUD.StagedItemOperations;
using FoamMVC.DTOs;
using FoamMVC.ExtensionMethods;
using FoamMVC.Models;
using FoamMVC.ViewModels;

namespace FoamMVC.BLL.CRUD.StagedItemsOperations
{
    public class StagedItemBLL
    {
        private IStagedItemDAL _stagedItemDal;
        private ItemBLL _itemBll;

        public StagedItemBLL()
        {
            _stagedItemDal = new StagedItemDAL();
            _itemBll = new ItemBLL();
        }

        public void DeleteStagedItem(string UPC)
        {
            _stagedItemDal.Destroy(ConvertDTOToEntity(GetStagedItemDTOByUPC(UPC)));
        } 

        public List<StagedItemDTO> Get()
        {
            return _stagedItemDal.Get().Select(x => new StagedItemDTO
            {
                Name = x.Name,
                UPC = x.UPC,
                ItemPrice = x.ItemPrice,
                StockCount = x.StockCount
            }).ToList();
        }

        public List<StagedItemsViewModel> GetViewModels()
        {
            return _stagedItemDal.Get().Select(x => new StagedItemsViewModel
            {
                ID = x.ID,
                Name = x.Name,
                UPC = x.UPC,
                ItemPrice = x.ItemPrice.AsCurrency(),
                StockCount = x.StockCount
            }).ToList();
        } 

        public void ProcessStagedItems(List<StagedItemDTO> stagedItems)
        {
            foreach (var item in stagedItems)
            {
                if (ItemAlreadyExits(item))
                {
                    _itemBll.UpdateFromStagedItem(item);
                }
                else if (StagedItemAlreadyExists(item))
                {
                    UpdateStagedItems(item);
                }
                else
                {
                    CreateStagedItems(item);
                }
            }
        }

        public StagedItemsViewModel GetStagedItemByUPC(string UPC)
        {
            try
            {
                return ConvertEntityToViewModel(_stagedItemDal.Get(UPC));
            }
            catch (Exception)
            {
                return null;
            }
        }
        public StagedItemDTO GetStagedItemDTOByUPC(string UPC)
        {
            try
            {
                return EntityToDTOMapper(_stagedItemDal.Get(UPC));
            }
            catch (Exception)
            {
                return null;
            }
        }

        public ItemViewModelStringItemPrice GetItemWithStagedItemReflectedOnItByUPC(string UPC)
        {
            var staged = GetStagedItemByUPC(UPC);
            return new ItemViewModelStringItemPrice
            {
                Name = staged.Name,
                UPC = staged.UPC,
                StockCount = staged.StockCount,
                ItemPrice = staged.ItemPrice
            };
        }
        
        private bool StagedItemAlreadyExists(StagedItemDTO item)
        {
            try
            {
                return (_stagedItemDal.Get(item.UPC) != null);
            }
            catch (Exception)
            {
                return false;
            }

        }

        private void UpdateStagedItems(StagedItemDTO item)
        {
            _stagedItemDal.Update(DTOtoEntityMapper(item));
        }

        private bool ItemAlreadyExits(StagedItemDTO item)
        {
            return (_itemBll.GetItemByUPC(item.UPC) != null);
        }

        private void CreateStagedItems(StagedItemDTO stagedItemDTO)
        {
            _stagedItemDal.Create(DTOtoEntityMapper(stagedItemDTO));
        }

        private StagedItem DTOtoEntityMapper(StagedItemDTO stagedItemDTO)
        {
            return new StagedItem
            {
                ItemPrice = stagedItemDTO.ItemPrice,
                Name = CleanName(stagedItemDTO.Name),
                UPC = stagedItemDTO.UPC,
                StockCount = stagedItemDTO.StockCount
            };
        }

        private StagedItemDTO EntityToDTOMapper(StagedItem entity)
        {
            return new StagedItemDTO
            {
                ID = entity.ID, 
                ItemPrice = entity.ItemPrice,
                Name = CleanName(entity.Name),
                UPC = entity.UPC,
                StockCount = entity.StockCount
            };

        }

        private string CleanName(string name)
        {
            return name.Split('/')[0];
        }

        private StagedItemsViewModel ConvertEntityToViewModel(StagedItem entity)
        {
            return new StagedItemsViewModel
            {
                ItemPrice = entity.ItemPrice.AsCurrency(),
                Name = entity.Name,
                StockCount = entity.StockCount,
                UPC = entity.UPC
            };
        }

        private StagedItem ConvertDTOToEntity(StagedItemDTO dto)
        {
            return new StagedItem
            {
                ID = dto.ID,
                ItemPrice = dto.ItemPrice,
                Name = dto.Name,
                StockCount = dto.StockCount,
                UPC = dto.UPC
            };
        }
    }
}