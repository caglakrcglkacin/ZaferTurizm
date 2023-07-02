using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ZaferTurizm.Bussiness.Services;
using ZaferTurizm.DataAccess;
using ZaferTurizm.Domain;
using ZaferTurizm.Dtos;



namespace ZaferTurizm.WebApps.Controllers
{
    public class VehicleModelController : Controller
    {
        IVehicleModelService _vehicleModelService;
        IVehicleMakeService _vehicleMakeService;
        TourDbContext _tourDbContext;
        IMapper _mapper;
        public VehicleModelController(IVehicleModelService vehicleModelService,
              IVehicleMakeService vehicleMakeService,
              TourDbContext tourDbContext,
              IMapper mapper)
        {
            _vehicleModelService = vehicleModelService;
            _vehicleMakeService = vehicleMakeService;
            _tourDbContext = tourDbContext;
            _mapper = mapper;
        }
        public IActionResult Model()
        {
            var entity = _vehicleModelService.GetSummary();
            return View(entity);
        }
        public IActionResult ModelAdd()
        {
            ViewBag.VehicleMake = new SelectList(_tourDbContext.VehicleMakes, "Id", "Name");

            return View();
        }
        [HttpPost]
        public IActionResult ModelAdd(VehicleModelDto model)
        {
          

          var modelAdd =  _vehicleModelService.Create(model);
            if (modelAdd.IsSuccess)
            {
                return RedirectToAction("Model");
            }
            return View(modelAdd);
        }
        public IActionResult ModelUpdate(int Id)
        {
            var entity = _vehicleModelService.GetById(Id);
            if (entity == null)
            {
                return RedirectToAction("Model");
            }
            ViewBag.VehicleMake = new SelectList(_tourDbContext.VehicleMakes, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult ModelUpdate(VehicleModelDto model)
        {


            var modelAdd = _vehicleModelService.Update(model);
            if (modelAdd.IsSuccess)
            {
                return RedirectToAction("Model");
            }
            return View(modelAdd);
        }
        [HttpPost]
        public IActionResult Delete(int Id)
        {


            var modelAdd = _vehicleModelService.Delete(Id);
            if (modelAdd.IsSuccess)
            {
                return RedirectToAction("Model");
            }
            return View(modelAdd);
        }
        public IActionResult GetVehicleModelsByMakeId(int vehicleMakeId)
        {
            var all = _vehicleModelService.GetByMakeId(vehicleMakeId);
            

            return Json(all);
        }
    }
}
