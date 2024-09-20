using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxMeData.Context;
using TaxMeData.Models;
using TaxMeRepository.Interfaces;

namespace TaxMeRepository.Repositories
{
    public class RideRequestRepository : IRideRequestRepository
    {
        private readonly TaxMeDbContext _context;

        public RideRequestRepository(TaxMeDbContext context)
        {
            _context = context;
        }

        public IEnumerable<RideRequest> GetAllRideRequests()

            => _context.RideRequests.ToList();


        RideRequest IRideRequestRepository.GetRideRequestById(int id)
         => _context.RideRequests.Find(id);

        public IEnumerable<RideRequest> GetRideRequestByUserId(int userId)
       => _context.RideRequests.Where(X => X.UserId == userId).ToList();

        public void AddRideRequest(RideRequest rideRequest)
        {
            _context.RideRequests.Add(rideRequest);
            
        }

        public void UpdateRideRequest(RideRequest rideRequest)
        {
            _context.Entry(rideRequest).State = EntityState.Modified;
            
        }

        public void DeleteRideRequest(RideRequest rideRequest)
        { 
            if (rideRequest != null)
            {
                _context.RideRequests.Remove(rideRequest);
               
            }
        }

        
    }
}
