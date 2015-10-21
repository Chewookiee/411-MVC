using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoamMVC.Models;

namespace FoamMVC.DAL.CRUD.StagedItemOperations
{
    public interface IStagedItemCRUD
    {
        void Create(StagedItem stagedItems);
        void Update(StagedItem stagedItem);
        StagedItem Get(StagedItem item);
        List<StagedItem> Get();
    }
}
