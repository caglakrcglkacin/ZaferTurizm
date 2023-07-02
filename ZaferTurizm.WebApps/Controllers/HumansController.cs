using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ZaferTurizm.Bussiness.Services;
using ZaferTurizm.DataAccess;
using ZaferTurizm.Domain;
using ZaferTurizm.Domain.Enum;
using ZaferTurizm.Dtos;

namespace ZaferTurizm.WebApps.Controllers
{
    public class HumansController : Controller
    {
        TourDbContext _tourDbContext;
        IHumanService _humanService;
        IBusTripService _sefer;
        IProvinceService _province;
        IVehicleDefintionService _vehicleDefintion;
        IRotaService _rotaService;
        public HumansController(IHumanService humanService
            ,IBusTripService sefer
            , IProvinceService province
            , IVehicleDefintionService vehicleDefintion,
            IRotaService rotaService,
            TourDbContext tourDbContext)
        {
            _humanService = humanService;
            _sefer = sefer;
            _province = province;
            _vehicleDefintion = vehicleDefintion;
            _rotaService = rotaService;
            _tourDbContext = tourDbContext; 
        }
        public IActionResult Sefer()
        {
            var sefer = _sefer.GetSummary();
            return View(sefer);
        }
       
        public IActionResult SeferAdd()
        {

            ViewBag.Rota = _rotaService.GetSummary();
            var defitions = _vehicleDefintion.GetSummary();
            ViewBag.vehicleDefintions = new SelectList(defitions, "Id", "Year");
            return View();
        }
        
        [HttpPost]
        public IActionResult SeferAdd(OtobusSeferiDto model)
        {
            var sonuc = _sefer.Create(model);
            if (sonuc.IsSuccess)
            {
                return RedirectToAction("Sefer");
               
            }

            return View();
        }


        public IActionResult HumanAdd()
        {
            var model = new HumanDto();
            model.CinsiyetList = Enum.GetValues(typeof(CinsiyetEnum)).Cast<CinsiyetEnum>().Select(v => new SelectListItem()
            {
                Text = v.ToString(),
                Value = Convert.ToString((int)v)
            }).ToList();

            
            return View(model);
        }

        [HttpPost]
        public IActionResult HumanAdd(HumanDto model)
        {
            var sonuc = _humanService.Create(model);
            if (sonuc.IsSuccess)
            {
                return RedirectToAction("Sefer");

            }

            return View(model);
        }







    }
}
