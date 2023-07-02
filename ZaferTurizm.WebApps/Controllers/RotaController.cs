using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ZaferTurizm.Bussiness.Services;
using ZaferTurizm.Dtos;

namespace ZaferTurizm.WebApps.Controllers
{
    public class RotaController : Controller
    {
        private readonly IRotaService _rotaServis;
        private readonly IProvinceService _provinceService;
        public RotaController(IRotaService rotaService, IProvinceService provinceService)
        {
            _rotaServis = rotaService;
            _provinceService = provinceService; 
        }
        public IActionResult Rota()
        {
            var rotaList = _rotaServis.GetSummary();
            return View(rotaList);
        }
        public IActionResult AddRota()
        {
            var citys = _provinceService.GetAll();
            ViewBag.cityList = new SelectList(citys, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult AddRota(RotaDto model)
        {
            var rotaAdd =_rotaServis.Create(model);
            if (rotaAdd.IsSuccess)
            {
                return RedirectToAction("Rota");
            }
            
            return View(model);
        }
    }
}
