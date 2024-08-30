using Microsoft.AspNetCore.Mvc;
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

        // GET: RideRequest  
        public ActionResult Index()
        {
            var rideRequests = _rideRequestRepository.GetAllRideRequests();
            return View(rideRequests);
        }

        // GET: RideRequest/Details/5  
        public ActionResult Details(int id)
        {
            var rideRequest = _rideRequestRepository.GetRideRequestById(id);
            if (rideRequest == null)
            {
                return RedirectToAction("NotFound", "Error");
            }
            return View(rideRequest);
        }

        // GET: RideRequest/Create  
        public ActionResult Create()
        {
            return View();
        }

        // POST: RideRequest/Create  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RideRequest rideRequest)
        {
            if (ModelState.IsValid)
            {
                _rideRequestRepository.AddRideRequest(rideRequest);
                return RedirectToAction("Index");
            }
            return View(rideRequest);
        }

        // GET: RideRequest/Edit/5  
        public ActionResult Edit(int id)
        {
            var rideRequest = _rideRequestRepository.GetRideRequestById(id);
            if (rideRequest == null)
            {
                return RedirectToAction("NotFound", "Error");
            }
            return View(rideRequest);
        }

        // POST: RideRequest/Edit/5  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RideRequest rideRequest)
        {
            if (ModelState.IsValid)
            {
                _rideRequestRepository.UpdateRideRequest(rideRequest);
                return RedirectToAction("Index");
            }
            return View(rideRequest);
        }

        // GET: RideRequest/Delete/5  
        public ActionResult Delete(int id)
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
        public ActionResult DeleteConfirmed(int id)
        {
            _rideRequestRepository.DeleteRideRequest(id);
            return RedirectToAction("Index");
        }
    }
}
