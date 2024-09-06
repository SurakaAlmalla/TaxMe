using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxMeData.Models;

namespace TaxMeService.interfaces.Dto
{
    public class RideRequestDto
    {
        [Key]
        public int IdReq { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public string PickupLocation { get; set; }

        [Required]
        public string DropoffLocation { get; set; }

        public DateTime RequestTime { get; set; } = DateTime.Now;

        [Required]
        public string Status_request { get; set; } = "Accepted";

        public virtual User User { get; set; }
    }
}
