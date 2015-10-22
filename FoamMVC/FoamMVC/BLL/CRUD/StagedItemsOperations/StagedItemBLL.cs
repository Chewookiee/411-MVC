using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FoamMVC.DAL.CRUD.ItemOperations;
using FoamMVC.DAL.CRUD.StagedItemOperations;
using FoamMVC.DTOs;
using FoamMVC.Models;

namespace FoamMVC.BLL.CRUD.StagedItemsOperations
{
    public class StagedItemBLL
    {
        private StagedItemDAL _stagedItemDal;
        private ItemDAL _itemDal;

        public StagedItemBLL()
        {
            _stagedItemDal = new StagedItemDAL();
            _itemDal = new ItemDAL();
        }

        public void ProcessStagedItems(List<StagedItemDTO> stagedItems)
        {
            foreach (var item in stagedItems)
            {
                if (ItemAlreadyExits(item))
                {
                    _itemDal.Update(DTOtoEntityMapper(item));
                }
                else if (StagedItemAlreadyExists(item))
                {
                    _stagedItemDal.Update(DTOtoEntityMapper(item));
                }
                else
                {
                    CreateStagedItems(item);
                }
            }
        }

        private bool StagedItemAlreadyExists(StagedItemDTO item)
        {
            return _stagedItemDal.Get().Any(x => x.UPC == item.UPC);
        }

        private void UpdateStagedItems(StagedItemDTO item)
        {
            _stagedItemDal.Update(DTOtoEntityMapper(item));
        }

        private bool ItemAlreadyExits(StagedItemDTO item)
        {
            return _itemDal.Get().Any(x => x.UPC == item.UPC);
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

        private string CleanName(string name)
        {
            return name.Split('/')[0];
        }
    }
}