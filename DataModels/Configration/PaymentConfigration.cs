﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxMeData.Models;

namespace TaxMeData.Configration
{
    public class PaymentConfigration : IEntityTypeConfiguration<pall>
    {
        public void Configure(EntityTypeBuilder<pall> builder)
        {
           
        }
    }
}
