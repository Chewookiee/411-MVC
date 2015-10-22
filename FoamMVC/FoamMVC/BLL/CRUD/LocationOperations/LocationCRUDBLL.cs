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
        public int CreateLocation(LocationCreateViewModel viewModel)
        {
            return _locationCrud.Create(new Location
            {
                PrimaryLocation = viewModel.PrimaryLocation,
                SecondaryLocation = viewModel.SecondaryLocation
            });
        }

        public int UpdateLocation(LocationUpdateViewModel viewModel)
        {
            return _locationCrud.Update(new Location
            {
                ID = viewModel.ID,
                PrimaryLocation = viewModel.PrimaryLocation,
                SecondaryLocation = viewModel.SecondaryLocation
            });
        }
        #endregion

        #region Get
        public IList<LocationDisplayViewModel> GetAllLocationsForDisplay()
        {
            return _locationCrud.Get().Select(x => new LocationDisplayViewModel
            {
                ID = x.ID,
                PrimaryLocation = x.PrimaryLocation,
                SecondaryLocation = x.SecondaryLocation,
                DateAdded = x.DateAdded,
                DateUpdated = x.DateUpdated
            }).ToList();
        }

        public LocationDisplayViewModel GetSingleLocationForDisplayByID(int id)
        {
            return ConvertEntityToLocationDisplayViewModel(_locationCrud.Get(id));
        }

        public LocationUpdateViewModel GetSingleLocationForUpdateByID(int id)
        {
            return ConvertEntityToLocationUpdateViewModel(_locationCrud.Get(id));
        }

        public LocationDeleteViewModel GetSingleLocationForDeleteByID(int id)
        {
            return ConvertEntityToLocationDeleteViewModel(_locationCrud.Get(id));
        }
        #endregion

        #region Delete
        public void DeleteLocation(LocationDeleteViewModel viewModel)
        {
            _locationCrud.Delete(_locationCrud.Get(viewModel.ID));
        }
        #endregion

        #region Utils
        private LocationDisplayViewModel ConvertEntityToLocationDisplayViewModel(Location model)
        {
            return new LocationDisplayViewModel
            {
                ID = model.ID,
                PrimaryLocation = model.PrimaryLocation,
                SecondaryLocation = model.SecondaryLocation,
                DateAdded = model.DateAdded,
                DateUpdated = model.DateUpdated
            };
        }

        private LocationUpdateViewModel ConvertEntityToLocationUpdateViewModel(Location model)
        {
            return new LocationUpdateViewModel
            {
                ID = model.ID,
                PrimaryLocation = model.PrimaryLocation,
                SecondaryLocation = model.SecondaryLocation,
            };
        }

        private LocationDeleteViewModel ConvertEntityToLocationDeleteViewModel(Location model)
        {
            return new LocationDeleteViewModel
            {
                ID = model.ID,
                PrimaryLocation = model.PrimaryLocation,
                SecondaryLocation = model.SecondaryLocation,
            };
        }
        #endregion
    }
}