using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ZaferTurizm.Bussiness.Services;
using ZaferTurizm.Domain;
using ZaferTurizm.Dtos;

namespace ZaferTurizm.WebApps.Controllers
{
    public class VehiclesController : Controller
    {
        IVehicleService _vehicleService;
        IVehicleMakeService _vehicleMakeService;
        IVehicleModelService _vehicleModelService;
        public VehiclesController(IVehicleService vehicleService,
            IVehicleMakeService vehicleMakeService,
            IVehicleModelService vehicleModelService)
        {
            _vehicleService = vehicleService;
            _vehicleMakeService = vehicleMakeService;   
            _vehicleModelService = vehicleModelService;
        }
        public IActionResult Vehicle()
        {
            var vehicles = _vehicleService.GetSummary();
            return View(vehicles);
        }
        public IActionResult VehicleAdd()
        {
            var veriMake = _vehicleMakeService.GetAll();
            ViewBag.VehicleMake = new SelectList(veriMake, "Id", "Name");
            var veriModel = _vehicleModelService.GetAll();
            ViewBag.VehicleModel = new SelectList(veriModel, "Id", "Name");

            return View();
        }
        [HttpPost]
        public IActionResult VehicleAdd(VehicleDto model)
        {
            var deneme = _vehicleService.Create(model);
            if (deneme.IsSuccess)
            {
                return RedirectToAction("Vehicle");
            }
            return View(model);
        }
    }
}
