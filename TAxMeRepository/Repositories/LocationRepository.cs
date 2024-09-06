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

        public void AddLocation(Location location)
        {
            _context.Locations.Add(location);
            
        }

        public void UpdateLocation(Location location)
        {
            _context.Entry(location).State = EntityState.Modified;
           
        }

        public void DeleteLocation(int id)
        {
            var location = _context.Locations.Find(id);
            if (location != null)
            {
                _context.Locations.Remove(location);
               
            }
        }

        public Location GetLocationById(int? id)
        => _context.Locations.Find(id);
    }
}
