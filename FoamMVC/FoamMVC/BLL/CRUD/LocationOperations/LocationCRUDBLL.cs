using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoamMVC.DAL.CRUD.LocationOperations;
using FoamMVC.Models;
using FoamMVC.ViewModels;

namespace FoamMVC.BLL.CRUD.LocationOperations
{
    public class LocationCRUDBLL
    {
        private LocationCRUD _locationCrud;

        public LocationCRUDBLL()
        {
            _locationCrud = new LocationCRUD();
        }

        public List<SelectListItem> GetDropDownDisplayForLocations()
        {
            var locations = _locationCrud.Get();
             return locations.Select(S => new SelectListItem()
            {
                Text = S.SecondaryLocation + ", "+ S.PrimaryLocation,
                Value = S.ID.ToString()
            }).ToList();
        }

        #region Create/Update
        public int CreateLocation(LocationViewModel viewModel)
        {
            return _locationCrud.Create(new Location
            {
                PrimaryLocation = viewModel.PrimaryLocation,
                SecondaryLocation = viewModel.SecondaryLocation
            });
        }
        #endregion
    }
}