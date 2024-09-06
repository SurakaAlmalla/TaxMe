using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxMeData.Context;
using TaxMeRepository.Interfaces;


namespace TaxMeRepository.Repositories
{
    public class UnitOfwork : IUnitOfwork
    {
        private readonly TaxMeDbContext _context;

        public UnitOfwork(TaxMeDbContext context)
        { 
           _context = context;
            LocationRepository = new LocationRepository(context);
            rideRequestRepository = new RideRequestRepository(context);

        }
        public ILocationRepository LocationRepository { get; set; }
        public IRideRequestRepository rideRequestRepository { get; set; }

        public int complete()
        
            => _context.SaveChanges();
    }
}
