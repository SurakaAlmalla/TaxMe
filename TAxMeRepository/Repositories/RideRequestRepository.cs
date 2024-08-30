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

        public RideRequest GetRideRequestById(int id)

            => _context.RideRequests.Find(id);

        public void AddRideRequest(RideRequest rideRequest)
        {
            _context.RideRequests.Add(rideRequest);
            _context.SaveChanges();
        }

        public void UpdateRideRequest(RideRequest rideRequest)
        {
            _context.Entry(rideRequest).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteRideRequest(int id)
        {
            var rideRequest = _context.RideRequests.Find(id);
            if (rideRequest != null)
            {
                _context.RideRequests.Remove(rideRequest);
                _context.SaveChanges();
            }
        }
    }
}
