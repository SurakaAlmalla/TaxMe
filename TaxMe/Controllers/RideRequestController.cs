using Microsoft.AspNetCore.Mvc;
using TaxMe.Models;
using TaxMeData.Models;
using TaxMeRepository.Interfaces;
using TaxMeService.interfaces;
using TaxMeService.interfaces.Dto;
using TaxMeService.Services.Servic;

namespace TaxMe.Controllers
{
    public class RideRequestController : Controller
    {
        private readonly IRideRequestService _rideRequestService;

        public RideRequestController(IRideRequestService rideRequestService)
        {
            _rideRequestService = rideRequestService;
        }

        // GET:   
        public IActionResult Index(int userId)
        {
            IEnumerable<RideRequestDto> rideRequests = new List<RideRequestDto>();

            if (string.IsNullOrEmpty(Convert.ToString(userId)))
           
                rideRequests = _rideRequestService.GetAllRideRequests();
            else 
                rideRequests = _rideRequestService.GetRideRequestByUserId(userId);

                return View(rideRequests);
    
        }

        // GET:  
        public IActionResult Details(int id)
        {
            var rideRequest = _rideRequestService.GetRideRequestById(id);
            if (rideRequest == null)
            {
                return RedirectToAction("NotFound", "Error");
            }
            return View(rideRequest);
        }

        // GET:  
        public IActionResult Create()
        {
            ViewBag.RideRequest =_rideRequestService.GetAllRideRequests();
            return View();
        }
 
        // POST:  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RideRequestDto rideRequest)
        {
            if (ModelState.IsValid)
            {
                _rideRequestService.AddRideRequest(rideRequest);
                return RedirectToAction("Index");
            }
            return View(rideRequest);
        }

        // GET: 
        public IActionResult Edit(int id)
        {
            var rideRequest = _rideRequestService.GetRideRequestById(id);
            if (rideRequest == null)
            {
                return RedirectToAction("NotFound", "Error");
            }
            return View(rideRequest);
        }

        // POST:  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(RideRequestDto rideRequest)
        {
            if (ModelState.IsValid)
            {
                _rideRequestService.UpdateRideRequest(rideRequest);
                return RedirectToAction("Index");
            }
            return View(rideRequest);
        }

        // GET: 
        public IActionResult Delete(int id)
        {
            var rideRequest = _rideRequestService.GetRideRequestById(id);
            if (rideRequest == null)
            {
                return RedirectToAction("NotFound", "Error");
            }
            return View(rideRequest);
        }

        // POST: RideRequest/Delete/5  
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(RideRequestDto rideRequest)
        {
            _rideRequestService.DeleteRideRequest(rideRequest);
            return RedirectToAction("Index");
        }

    }
}
