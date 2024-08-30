using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxMeData.Models
{
    public class Payment
    {
        public int Id { get; set; }

        [Required]
        public int RideId { get; set; }

        [Required]
        public decimal Amount { get; set; }

        public DateTime PaymentDate { get; set; } = DateTime.Now;

        [Required]
        public string PaymentMethod { get; set; } // e.g., Credit Card, PayPal  

        public bool IsSuccessful { get; set; } = true;

        // Navigation property  
        public virtual Ride Ride { get; set; }
    }
}
