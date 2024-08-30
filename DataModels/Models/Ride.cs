using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxMeData.Models
{
    public class Ride
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int DriverId { get; set; }

        public DateTime RideDate { get; set; } = DateTime.Now;

        [Required]
        public string PickupLocation { get; set; }

        [Required]
        public string DropoffLocation { get; set; }

        public decimal Fare { get; set; }

        [Required]
        public string Status { get; set; } // e.g., Pending, Completed, Cancelled  

        // Navigation properties  
        public virtual User User { get; set; }
        public virtual Driver Driver { get; set; }

        // Navigation property for payment  
        public virtual Payment Payment { get; set; }
    }
}
