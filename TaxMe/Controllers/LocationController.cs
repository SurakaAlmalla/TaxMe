using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using TaxMeData.Models;
using TaxMeRepository.Interfaces;
using TaxMeService.interfaces;

namespace TaxMe.Controllers
{
    public class LocationController : Controller
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var locations = _locationService.GetAllLocations();
            return View(locations);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Location location)
        {
            if (ModelState.IsValid)
            {
                _locationService.AddLocation(location);
                return RedirectToAction(nameof(Index));
            }
            ModelState.AddModelError("LocationError", "valoidationError");
            return View(location);
        }
        [HttpGet]
        public IActionResult Details(int? id, string viewName = "Details")
        {
            var location = _locationService.GetLocationById(id);
            if (location is null)
            {
                return RedirectToAction("NotFoundPage", null, "Home");
            }
            return View(viewName, location);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            //var location = _locationService.GetLocationById(id);

            return Details(id, "Edit");
        }

        // POST: 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, Location location)
        {
            if (location.Id != id.Value)
                return RedirectToAction("NotFoundPage", null, "Home");

            _locationService.UpdateLocation(location);

            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        //[HttpDelete] //this for hard delete
        public IActionResult Delete(int id)
        {
            var location = _locationService.GetLocationById(id);
            if (location is null)
            {
                return RedirectToAction("NotFound", "Error");
            }
            _locationService.DeleteLocation(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
