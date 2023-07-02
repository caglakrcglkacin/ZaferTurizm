using Microsoft.AspNetCore.Mvc;
using ZaferTurizm.Bussiness.Services;
using ZaferTurizm.DataAccess;
using ZaferTurizm.Dtos;

namespace ZaferTurizm.WebApps.Controllers
{
    public class ProvinceController : Controller
    {
        IProvinceService _province;
        TourDbContext _tourDbContext;
        public ProvinceController(IProvinceService province,
        TourDbContext tourDbContext)
        {
            _province = province;
            _tourDbContext = tourDbContext;
        }
        public IActionResult Province()
        {
          var entity =   _province.GetAll();
            return View(entity);
        }
        public IActionResult PropAdd()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult PropAdd(ProvinceDto model)
        {
           var props =  _province.Create(model);
            if (props.IsSuccess)
            {
                return RedirectToAction("Province");
            }
            return View();
        }
     
        public IActionResult PropUpdate(int Id)
        {
            var bul = _province.GetById(Id);
            if (bul== null)
            {
                return RedirectToAction("Province");
            }

            return View(bul);
        }
        [HttpPost]
        public IActionResult PropUpdate(ProvinceDto model)
        {
            var props = _province.Update(model);
            if (props.IsSuccess)
            {
                return RedirectToAction("Province");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Delete(int Id)
        {
            var props = _province.Delete(Id);
            if (props.IsSuccess)
            {
                return RedirectToAction("Province");
            }
            return View();
        }
    }
}
