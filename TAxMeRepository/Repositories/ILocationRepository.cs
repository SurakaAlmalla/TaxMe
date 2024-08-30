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
    public class LocationRepository : ILocationRepository
    {
        private readonly TaxMeDbContext _context;

        public LocationRepository(TaxMeDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Location> GetAllLocations()
        
            => _context.Locations.ToList();

        public Location GetLocationById(int id)
       
            => _context.Locations.Find(id);

        public void AddLocation(Location location)
        {
            _context.Locations.Add(location);
            _context.SaveChanges();
        }

        public void UpdateLocation(Location location)
        {
            _context.Entry(location).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteLocation(int id)
        {
            var location = _context.Locations.Find(id);
            if (location != null)
            {
                _context.Locations.Remove(location);
                _context.SaveChanges();
            }
        }
    }
}
