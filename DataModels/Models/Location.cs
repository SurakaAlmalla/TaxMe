using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxMeData.Models
{
    public class Location
    {
        public int Id { get; set; }

        [Required]
        public string Address { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}
