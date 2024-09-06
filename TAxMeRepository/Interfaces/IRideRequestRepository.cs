using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxMeData.Models;

namespace TaxMeRepository.Interfaces
{
    public interface IRideRequestRepository
    {
        IEnumerable<RideRequest> GetAllRideRequests(); 
        RideRequest GetRideRequestById(int id);
        void AddRideRequest(RideRequest rideRequest);   
        void UpdateRideRequest(RideRequest rideRequest);   
        void DeleteRideRequest(int id);
        IEnumerable<RideRequest> GetRideRequestByUserId(int userId);
    }
}
