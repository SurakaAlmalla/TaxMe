using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxMeData.Models;
using TaxMeRepository.Interfaces;
using TaxMeService.interfaces;
using TaxMeService.interfaces.Dto;

namespace TaxMeService.Services.Servic
{
    public class RideRequestService : IRideRequestService
    {

        private readonly IUnitOfwork _unitOfWork;
        private readonly IMapper _mapper;
        
        public RideRequestService(IUnitOfwork unitOfWork ,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public void AddRideRequest(RideRequestDto rideRequestDto)
        {
        //    RideRequest rideRequest = new RideRequest()
        //    {UserId= rideRequestDto.UserId,
        //        PickupLocation =rideRequestDto.PickupLocation,
        //        DropoffLocation =rideRequestDto.DropoffLocation,
        //        RequestTime =rideRequestDto.RequestTime,    
        //        Status_request=rideRequestDto.Status_request,
        //        User= rideRequestDto.User

        //    };
         RideRequest rideRequest = _mapper.Map<RideRequest>(rideRequestDto);
            _unitOfWork.rideRequestRepository.AddRideRequest(rideRequest);
            _unitOfWork.complete();
        }

        public void DeleteRideRequest(RideRequestDto rideRequestDto)
        {
            //RideRequest rideRequest = new RideRequest()
            //{
            //    UserId = rideRequestDto.UserId,
            //    PickupLocation = rideRequestDto.PickupLocation,
            //    DropoffLocation = rideRequestDto.DropoffLocation,
            //    RequestTime = rideRequestDto.RequestTime,
            //    Status_request = rideRequestDto.Status_request,
            //    User = rideRequestDto.User

            //};
            RideRequest rideRequest = _mapper.Map<RideRequest>(rideRequestDto);
            _unitOfWork.rideRequestRepository.DeleteRideRequest(rideRequest);
            _unitOfWork.complete();
        }

        public IEnumerable<RideRequestDto> GetAllRideRequests()
        {
           var ride =_unitOfWork.rideRequestRepository.GetAllRideRequests();

            //var mappRideRequest = ride.Select(X => new RideRequestDto
            //{   UserId = X.UserId,
            //    PickupLocation=X.PickupLocation, DropoffLocation=X.DropoffLocation,RequestTime=X.RequestTime,
            //    Status_request = X.Status_request,User = X.User
            //}); 

            IEnumerable<RideRequestDto> mappRideRequest = _mapper.Map<IEnumerable<RideRequestDto>>(ride);
            return mappRideRequest; 
        }


        public RideRequestDto GetRideRequestById(int? IdReq)
        {
            if (IdReq == null)
                return null;
            var rideRequest = _unitOfWork.rideRequestRepository.GetRideRequestById(IdReq.Value);

            if (rideRequest is null)
                return null;

            //RideRequestDto rideRequestDto  = new RideRequestDto()
            //{
            //    UserId = rideRequest.UserId,
            //    PickupLocation = rideRequest.PickupLocation,
            //    DropoffLocation = rideRequest.DropoffLocation,
            //    RequestTime = rideRequest.RequestTime,
            //    Status_request = rideRequest.Status_request,
            //    User = rideRequest.User

            //};
            RideRequestDto rideRequestDto = _mapper.Map<RideRequestDto>(rideRequest);

            return rideRequestDto;
        }



        public IEnumerable<RideRequestDto> GetRideRequestByUserId(int userId)
        {
            var riderequest = _unitOfWork.rideRequestRepository.GetRideRequestByUserId(userId);
            //var mappRideRequest = riderequest.Select(X => new RideRequestDto
            //{
            //    UserId = X.UserId,
            //    PickupLocation = X.PickupLocation,
            //    DropoffLocation = X.DropoffLocation,
            //    RequestTime = X.RequestTime,
            //    Status_request = X.Status_request,
            //    User = X.User
            //});
            IEnumerable<RideRequestDto> mappRideRequest = _mapper.Map<IEnumerable<RideRequestDto>>(riderequest);
            return mappRideRequest;
        }

       

        public void UpdateRideRequest(RideRequestDto rideRequestDto)
        {
            //RideRequest rideRequest = new RideRequest()
            //{
            //    UserId = rideRequestDto.UserId,
            //    PickupLocation = rideRequestDto.PickupLocation,
            //    DropoffLocation = rideRequestDto.DropoffLocation,
            //    RequestTime = rideRequestDto.RequestTime,
            //    Status_request = rideRequestDto.Status_request,
            //    User = rideRequestDto.User

            //};
            RideRequest rideRequest = _mapper.Map<RideRequest>(rideRequestDto);
            _unitOfWork.rideRequestRepository.UpdateRideRequest(rideRequest);
           _unitOfWork.complete();
        }
    }
}
