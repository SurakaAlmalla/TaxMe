using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxMeData.Models;

namespace TaxMeRepository.Interfaces
{
    public interface ILocationRepository
    {
        IEnumerable<Location> GetAllLocations(); // Retrieve all locations  
        Location GetLocationById(int id); // Retrieve a specific location by ID  
        void AddLocation(Location location); // Add a new location  
        void UpdateLocation(Location location); // Update an existing location  
        void DeleteLocation(int id); // Delete a location by ID  
    }
}
