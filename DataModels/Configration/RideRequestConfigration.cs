using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxMeData.Models;

namespace TaxMeData.Configration
{
    public class RideRequestConfigration : IEntityTypeConfiguration<RideRequest>
    {
        public void Configure(EntityTypeBuilder<RideRequest> builder)
        {
           
        }
    }
}
