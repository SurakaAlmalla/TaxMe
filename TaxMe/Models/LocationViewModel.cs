using System.ComponentModel.DataAnnotations;

namespace TaxMe.Models
{
    public class LocationViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Address { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}

