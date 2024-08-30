using Microsoft.AspNetCore.Mvc;
using TaxMeData.Models;
using TaxMeRepository.Interfaces;

namespace TaxMe.Controllers
{
    public class LocationController : Controller
    {
        private readonly ILocationRepository _locationRepository;

        public LocationController(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        // GET: Location  
        public ActionResult Index()
        {
            var locations = _locationRepository.GetAllLocations();
            return View(locations);
        }

        // GET: Location/Details/5  
        public ActionResult Details(int id)
        {
            var location = _locationRepository.GetLocationById(id);
            if (location == null)
            {
                return RedirectToAction("NotFound", "Error");
            }
            return View(location);
        }

        // GET: Location/Create  
        public ActionResult Create()
        {
            return View();
        }

        // POST: Location/Create  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Location location)
        {
            if (ModelState.IsValid)
            {
                _locationRepository.AddLocation(location);
                return RedirectToAction("Index");
            }
            return View(location);
        }

        // GET: Location/Edit/5  
        public ActionResult Edit(int id)
        {
            var location = _locationRepository.GetLocationById(id);
            if (location == null)
            {
                return RedirectToAction("NotFound", "Error");
            }
            return View(location);
        }

        // POST: Location/Edit/5  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Location location)
        {
            if (ModelState.IsValid)
            {
                _locationRepository.UpdateLocation(location);
                return RedirectToAction("Index");
            }
            return View(location);
        }

        // GET: Location/Delete/5  
        public ActionResult Delete(int id)
        {
            var location = _locationRepository.GetLocationById(id);
            if (location == null)
            {
                return RedirectToAction("NotFound", "Error");
            }
            return View(location);
        }

        // POST: Location/Delete/5  
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _locationRepository.DeleteLocation(id);
            return RedirectToAction("Index");
        }
    }
}
