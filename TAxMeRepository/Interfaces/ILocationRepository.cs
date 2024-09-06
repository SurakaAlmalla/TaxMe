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
        IEnumerable<Location> GetAllLocations(); 
        Location GetLocationById(int? id);  
        void AddLocation(Location location); 
        void UpdateLocation(Location location);   
        void DeleteLocation(int id); 
    }
}
