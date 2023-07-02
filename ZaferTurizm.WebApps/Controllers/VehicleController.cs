using Microsoft.AspNetCore.Mvc;
using ZaferTurizm.Bussiness.Services;
using ZaferTurizm.Domain;
using ZaferTurizm.Dtos;


namespace ZaferTurizm.WebApps.Controllers
{
    public class VehicleController : Controller
    {
        IVehicleMakeService _vehiceleMake;
        public VehicleController(IVehicleMakeService vehiceleMake)
        {
            _vehiceleMake = vehiceleMake;
        }
        public IActionResult Index()
        {
            var entity = _vehiceleMake.GetAll();

            return View(entity);
        }
        public IActionResult Creating()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Creating(VehicleMakeDto model)
        {
            
          var entity = _vehiceleMake.Create(model);
            if (entity.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Update(int Id)
        {
            var update = _vehiceleMake.GetById(Id);
            if (update == null)
            {
                return RedirectToAction("Index");
            }

            return View(update);
        }
        [HttpPost]
        public IActionResult Update(VehicleMakeDto Model)
        {

            var entity = _vehiceleMake.Update(Model);
            if (entity.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View(Model);
        }
        [HttpPost]
        public IActionResult Delete(int Id)
        {

            var entity = _vehiceleMake.Delete(Id);
            if (entity.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
