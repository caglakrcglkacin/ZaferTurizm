using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ZaferTurizm.Bussiness.Services;
using ZaferTurizm.DataAccess;
using ZaferTurizm.Dtos;

namespace ZaferTurizm.WebApps.Controllers
{
    public class VehicleDefintionController : Controller
    {
        TourDbContext _context;
        IVehicleDefintionService _vehicleDefintion;
        IVehicleMakeService _vehicleMakeService;
        IVehicleModelService _vehicleModelService;
        public VehicleDefintionController(IVehicleDefintionService vehicleDefintion, 
            TourDbContext context, 
            IVehicleMakeService vehicleMakeService,
            IVehicleModelService vehicleModelService)
        {
            _vehicleDefintion = vehicleDefintion;
            _context = context;
            _vehicleMakeService = vehicleMakeService;  
            _vehicleModelService = vehicleModelService; 
        }
        public IActionResult VehicleDefintion()
        {
            var entity = _vehicleDefintion.GetSummary();
            return View(entity);
        }
        public IActionResult VehicleDefintionAdd()
        {
            var veriMake = _vehicleMakeService.GetAll();
            ViewBag.VehicleMake = new SelectList(veriMake, "Id", "Name");
            var veriModel = _vehicleModelService.GetAll();
            ViewBag.VehicleModel = new SelectList(veriModel, "Id", "Name");

            return View();
        }
        [HttpPost]
        public IActionResult VehicleDefintionAdd(VehicleDefintionDto model)
        {
          var deneme =  _vehicleDefintion.Create(model);
            if (deneme.IsSuccess)
            {
                return RedirectToAction("VehicleDefintion");
            }
            return View(model);
        }
        public IActionResult VehicleDefintionUpdate(int Id)
        {
           
           
             var vehicleDefintion = _vehicleDefintion.GetById(Id);
            if (vehicleDefintion == null)
            {
                return NotFound();
            }
            var allvehicleMakes = _vehicleMakeService.GetAll();
            ViewBag.vehicleMakeSelectList= new SelectList(allvehicleMakes, "Id", "Name");
            var vehicleModel = _vehicleModelService.GetByMakeId(vehicleDefintion.VehicleMakeId);
            ViewBag.VehicleModelSeletList = new SelectList(vehicleModel, "Id", "Name");
            return View(vehicleDefintion);
        }
        [HttpPost]
        public IActionResult VehicleDefintionUpdate(VehicleDefintionDto model)
        {
            var deneme = _vehicleDefintion.Update(model);
            if (deneme.IsSuccess)
            {
                return RedirectToAction("VehicleDefintion");
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult Delete(int Id)
        {
            var deneme = _vehicleDefintion.Delete(Id);
            if (deneme.IsSuccess)
            {
                return RedirectToAction("VehicleDefintion");
            }
            return View();
        }
        public IActionResult VehicleDefintedId(int Id)
        {
            var deneme = _vehicleDefintion.GetDefintId(Id);
           
            return Json(deneme);
        }
    }
}
