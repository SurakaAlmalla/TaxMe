using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxMeData.Models;
using TaxMeService.interfaces.Dto;

namespace TaxMeService.interfaces
{
    public interface IRideRequestService
    {
        IEnumerable<RideRequestDto> GetAllRideRequests();
        RideRequestDto GetRideRequestById(int? id);
        void AddRideRequest(RideRequestDto rideRequest);
        void UpdateRideRequest(RideRequestDto rideRequest);
        void DeleteRideRequest(RideRequestDto rideRequest);   
        IEnumerable<RideRequestDto> GetRideRequestByUserId(int userId);
    }
}
