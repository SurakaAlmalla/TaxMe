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
        IEnumerable<RideRequest> GetAllRideRequests(); // Retrieve all ride requests  
        RideRequest GetRideRequestById(int id); // Retrieve a specific ride request by ID  
        void AddRideRequest(RideRequest rideRequest); // Add a new ride request  
        void UpdateRideRequest(RideRequest rideRequest); // Update an existing ride request  
        void DeleteRideRequest(int id); // Delete a ride request by ID  
    }
}
