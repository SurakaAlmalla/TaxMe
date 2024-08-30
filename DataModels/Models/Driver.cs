using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxMeData.Models
{
    public class Driver
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        [Required]
        [StringLength(50)]
        public string LicenseNumber { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        public string VehicleDetails { get; set; }

        public DateTime JoinedAt { get; set; } = DateTime.UtcNow;

        public bool IsActive { get; set; } = true;

        // Navigation property for rides  
        public virtual ICollection<Ride> Rides { get; set; }
    }
}
