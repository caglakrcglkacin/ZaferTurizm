using Microsoft.AspNetCore.Mvc;
using System.Data.SqlTypes;
using ZaferTurizm.Bussiness.Services;

namespace ZaferTurizm.WebApps.Controllers
{
    public class SharedController : Controller
    {
        IHumanService _humanService;
        IBusTripService _sefer;
        IProvinceService _province;
        IVehicleDefintionService _vehicleDefintion;
        IRotaService _rotaService;
        public SharedController(IHumanService humanService
            , IBusTripService sefer
            , IProvinceService province
            , IVehicleDefintionService vehicleDefintion,
            IRotaService rotaService)
        {
            _humanService = humanService;
            _sefer = sefer;
            _province = province;
            _vehicleDefintion = vehicleDefintion;
            _rotaService = rotaService;
        }
        public IActionResult RotaModal()
        {
          var deneme =  _rotaService.GetSummary();
            return View(deneme);
        }
    }
}
