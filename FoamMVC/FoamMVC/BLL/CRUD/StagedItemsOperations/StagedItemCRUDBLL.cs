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
    public class StagedItemCRUDBLL
    {

        private StagedItemCRUD _stagedItemCrud;
        private ItemCRUD _itemCrud;

        public StagedItemCRUDBLL()
        {
            _stagedItemCrud = new StagedItemCRUD();
            _itemCrud = new ItemCRUD();
        }

        public void ProcessStagedItems(List<StagedItemDTO> stagedItems)
        {
            foreach (var item in stagedItems)
            {
                if (ItemAlreadyExits(item))
                {
                    _itemCrud.Update(DTOtoEntityMapper(item));
                }
                else if (StagedItemAlreadyExists(item))
                {
                    _stagedItemCrud.Update(DTOtoEntityMapper(item));
                }
                else
                {
                    CreateStagedItems(item);
                }
            }
        }

        private bool StagedItemAlreadyExists(StagedItemDTO item)
        {
            return _stagedItemCrud.Get().Any(x => x.UPC == item.UPC);
        }

        private void UpdateStagedItems(StagedItemDTO item)
        {
            _stagedItemCrud.Update(DTOtoEntityMapper(item));
        }

        private bool ItemAlreadyExits(StagedItemDTO item)
        {
            return _itemCrud.Get().Any(x => x.UPC == item.UPC);
        }

        private void CreateStagedItems(StagedItemDTO stagedItemDTO)
        {
            _stagedItemCrud.Create(DTOtoEntityMapper(stagedItemDTO));
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