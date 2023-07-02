using Microsoft.AspNetCore.Mvc;
using ZaferTurizm.Bussiness.Services;
using ZaferTurizm.Domain;
using ZaferTurizm.Dtos;

namespace ZaferTurizm.WebApp.Controllers
{
    public class VehileMakeController : Controller
    {
        IVehicleMakeService _vehicleMakeService;
        public VehileMakeController(IVehicleMakeService vehicleMakeService)
        {
            _vehicleMakeService = vehicleMakeService;
        }
        public IActionResult Index()
        {

            return View();
        }
        public IActionResult Creat()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Creat(VehicleMakeDto model)
        {

           var entity = _vehicleMakeService.Create(model);

           return View(entity);
        }

    }
}
