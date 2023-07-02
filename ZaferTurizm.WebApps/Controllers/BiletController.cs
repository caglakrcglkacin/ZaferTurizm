using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using ZaferTurizm.Bussiness.Services;
using ZaferTurizm.DataAccess;
using ZaferTurizm.Domain;
using ZaferTurizm.Dtos;

namespace ZaferTurizm.WebApps.Controllers
{
    public class BiletController : Controller
    {
        IBiletService _bilet;
        IBusTripService _sefer;
        IHumanService _human;
        TourDbContext _dbContext;
        public BiletController(IBusTripService sefer,
            IBiletService bilet,
            IHumanService human,
            TourDbContext dbContext)
        {
            _sefer = sefer;
            _bilet = bilet;
            _human = human; 
            _dbContext = dbContext;
        }
        public IActionResult BiletSatis(int Id,string KimlikId )
        {
            var koltuk = _dbContext.Bilets.Select(x => x.KoltukNumarası).ToList();
            ViewBag.Koltuk =koltuk;
          
            //ViewBag.Kisi = _human.GetAll();
            var seferBilgisi = _sefer.GetBusTripDetails(Id);
            if (seferBilgisi == null)
            {
                TempData["ErrorMessage"] = "Seyahat bulunamadı";
                return RedirectToAction("Sefer", "Humans");
            }
           
            if (KimlikId != null)
            {
                var defitions = _human.GetByIdent(KimlikId);
                if (defitions != null)
                {
                    ViewBag.Kisi = defitions.Name+" "+defitions.Surname;
                    ViewBag.KisiId = defitions.Id;
                }
                if (defitions == null)
                {
                    ViewBag.Hata =".";
                }
                
            }
            return View(seferBilgisi);

        }
        [HttpPost]
        public IActionResult Create(BiletDto ticket)
        {
            ticket.VerildigiTarihi = DateTime.Now;
            var model = ticket.SeferNumara;
            var zaman = ticket.VerildigiTarihi;
            var result = _bilet.Create(ticket);
            var models = _bilet.GetBilet(model, zaman);

            TempData["DegerId"] = models.BiletId;
            return Json(new { redirecturl = "SonucEkranı" });
        }
        [HttpGet]
        public IActionResult SonucEkranı()
        {
            if (TempData["DegerId"] != null)
            {
                var deger = TempData["DegerId"];
                var degisken = Convert.ToInt32(deger);
                var bul = _bilet.GetById(degisken);
                ViewBag.SeferNumber = bul.SeferNumara;
            }
            
            return View();
        }
        public IActionResult BiletBul()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult BiletBul(BiletDto biletDtos)
        {
            var models = biletDtos.SeferNumara;
            var zaman = biletDtos.VerildigiTarihi;
            var model = _bilet.GetBilet(models, zaman);
            if (model != null)
            {
                ViewBag.Adi = model.KisiBilgileri;
                ViewBag.Bilet = model.BiletBilgileri;
                
            }
            return View();
        }

    }
}
