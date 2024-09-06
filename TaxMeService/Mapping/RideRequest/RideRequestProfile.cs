using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxMeData.Models;
using TaxMeService.interfaces.Dto;

namespace TaxMeService.Mapping
{
    public class RideRequestProfile : Profile
    {
        public RideRequestProfile()
        {
            CreateMap<RideRequest, RideRequestDto>().ReverseMap();
           
        }
    }
}
