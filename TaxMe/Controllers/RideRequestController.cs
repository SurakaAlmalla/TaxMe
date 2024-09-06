using Microsoft.AspNetCore.Mvc;
using TaxMe.Models;
using TaxMeData.Models;
using TaxMeRepository.Interfaces;

namespace TaxMe.Controllers
{
    public class RideRequestController : Controller
    {
        private readonly IRideRequestRepository _rideRequestRepository;

        public RideRequestController(IRideRequestRepository rideRequestRepository)
        {
            _rideRequestRepository = rideRequestRepository;
        }

        // GET:   
        public IActionResult Index(int userId)
        {
            IEnumerable<RideRequest> rideRequest = new List<RideRequest>();

            if (string.IsNullOrEmpty(Convert.ToString(userId)))
           
                rideRequest = _rideRequestRepository.GetAllRideRequests();
            else 
                rideRequest = _rideRequestRepository.GetRideRequestByUserId(userId);

                return View(rideRequest);
           
            
        }

        // GET:  
        public IActionResult Details(int id)
        {
            var rideRequest = _rideRequestRepository.GetRideRequestById(id);
            if (rideRequest == null)
            {
                return RedirectToAction("NotFound", "Error");
            }
            return View(rideRequest);
        }

        // GET:  
        public IActionResult Create()
        {

            return View();
        }
 
        // POST:  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TaxMeData.Models.RideRequest rideRequest)
        {
            if (ModelState.IsValid)
            {
                _rideRequestRepository.AddRideRequest(rideRequest);
                return RedirectToAction("Index");
            }
            return View(rideRequest);
        }

        // GET: 
        public IActionResult Edit(int id)
        {
            var rideRequest = _rideRequestRepository.GetRideRequestById(id);
            if (rideRequest == null)
            {
                return RedirectToAction("NotFound", "Error");
            }
            return View(rideRequest);
        }

        // POST:  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TaxMeData.Models.RideRequest rideRequest)
        {
            if (ModelState.IsValid)
            {
                _rideRequestRepository.UpdateRideRequest(rideRequest);
                return RedirectToAction("Index");
            }
            return View(rideRequest);
        }

        // GET: 
        public IActionResult Delete(int id)
        {
            var rideRequest = _rideRequestRepository.GetRideRequestById(id);
            if (rideRequest == null)
            {
                return RedirectToAction("NotFound", "Error");
            }
            return View(rideRequest);
        }

        // POST: RideRequest/Delete/5  
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _rideRequestRepository.DeleteRideRequest(id);
            return RedirectToAction("Index");
        }

    }
}
