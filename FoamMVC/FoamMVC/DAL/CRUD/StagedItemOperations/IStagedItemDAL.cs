using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoamMVC.Models;

namespace FoamMVC.DAL.CRUD.StagedItemOperations
{
    public interface IStagedItemDAL
    {
        void Create(StagedItem stagedItems);
        void Update(StagedItem stagedItem);
        void Destroy(StagedItem stagedItem);
        StagedItem Get(StagedItem item);
        StagedItem Get(string UPC);
        List<StagedItem> Get();
    }
}
