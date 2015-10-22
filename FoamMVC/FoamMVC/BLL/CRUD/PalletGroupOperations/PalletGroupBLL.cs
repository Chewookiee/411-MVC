using FoamMVC.DAL.CRUD.PalletGroupOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoamMVC.BLL.CRUD.PalletGroupOperations
{
    public class PalletGroupBLL
    {
        private IPalletGroupDAL _palletGroupDAL;

        public PalletGroupBLL()
        {
            _palletGroupDAL = new PalletGroupDAL();
        }


    }
}