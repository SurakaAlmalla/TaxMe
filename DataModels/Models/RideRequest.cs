using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxMeData.Models
{
    public class RideRequest
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public string PickupLocation { get; set; }

        [Required]
        public string DropoffLocation { get; set; }

        public DateTime RequestTime { get; set; } = DateTime.UtcNow;

        [Required]
        public string Status { get; set; } // e.g., Requested, Accepted, Completed  

        // Navigation property  
        public virtual User User { get; set; }
    }
}
