using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxMeData.Models;
using TaxMeRepository.Interfaces;
using TaxMeRepository.Repositories;
using TaxMeService.interfaces;

namespace TaxMeService.Services.Locations
{
    public class LocationtService : ILocationService
    {
        private readonly IUnitOfwork _unitOfWork;

        public LocationtService(IUnitOfwork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddLocation(Location location)
        {
            var mappedLocation = new Location
            {
                Address = location.Address,
                Latitude = location.Latitude,
                Longitude = location.Longitude,
                Id = location.Id

            };
            
            _unitOfWork.LocationRepository.AddLocation(mappedLocation);
            _unitOfWork.complete();
            
        }

        public Location GetLocationById(int? id)
        {
            if (id is null)
                return null;
            var location = _unitOfWork.LocationRepository.GetLocationById(id.Value);

            if (location is null)
                return null;

            return location;
        }
       
        public void UpdateLocation(Location location)
        {

            //var locat = GetLocationById(location.Id);
            //if (locat.Address != location.Address)
            //{
            //    if (GetAllLocations().Any(X => X.Address == location.Address))
            //        throw new Exception("Duplicate Location Address");
            //}
            //locat.Address = location.Address;
            //locat.Id = location.Id;

            _unitOfWork.LocationRepository.UpdateLocation(location);
            _unitOfWork.complete();
        }

        public IEnumerable<Location> GetAllLocations()
        {
            var location = _unitOfWork.LocationRepository.GetAllLocations();
            return location;
        }

        //public void DeleteLocation(int id)
        //    {
        //    _locationService.DeleteLocation(id);
        //    }

            public void DeleteLocation(int id)
            {
            _unitOfWork.LocationRepository.DeleteLocation(id);
            _unitOfWork.complete();
            }
    }
    } 
