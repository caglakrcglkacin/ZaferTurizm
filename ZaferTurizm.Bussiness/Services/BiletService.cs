using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.DataAccess;
using ZaferTurizm.Domain;
using ZaferTurizm.Dtos;
using ZaferTurizm.Summay;

namespace ZaferTurizm.Bussiness.Services
{
    public class BiletService : CrudService<BiletDto, BiletSummary, Bilet>, IBiletService
    {
        public BiletService(TourDbContext tourDbContext):base(tourDbContext)
        {

        }
        protected override Expression<Func<Bilet, BiletDto>> DtoMapper => entity => new BiletDto()
        {
            SeferNumara =entity.SeferNumara,
            SeferId = entity.SeferId,
            HumanId = entity.HumanId,
            Price = entity.Price,
            KoltukNumarası= entity.KoltukNumarası,
            VerildigiTarihi = entity.VerildigiTarihi

        };

        protected override Expression<Func<Bilet, BiletSummary>> SummaryMapper => entit => new BiletSummary()
        {
            Price = entit.Price,
            KoltukNumarası = entit.KoltukNumarası,
            Fiyat =entit.SeferBilgisi.Fiyat,
            GidisYonu=entit.SeferBilgisi.rota.GidisProvince.Name,
            VarisYonu= entit.SeferBilgisi.rota.DonusProvince.Name,
            Tarih = entit.SeferBilgisi.Tarih,
            Surname = entit.Kisi.Surname,
            Cinsiyet = entit.Kisi.Cinsiyet.ToString(),
            KisiIsmi = entit.Kisi.Name,
            SeferNumber = entit.SeferNumara,
            VerildigiTarihi = entit.VerildigiTarihi



        };

        public BiletSummary? GetBilet(int id,DateTime date)
        {
            try
            {
               return _tourDbContext.Bilets.Where(x => x.SeferNumara == id ||
                                           x.VerildigiTarihi == date).Select(entit => new BiletSummary()
                                           {
                                               BiletId = entit.Id,
                                               Price = entit.Price,
                                               KoltukNumarası = entit.KoltukNumarası,
                                               Fiyat = entit.SeferBilgisi.Fiyat,
                                               GidisYonu = entit.SeferBilgisi.rota.GidisProvince.Name,
                                               VarisYonu = entit.SeferBilgisi.rota.DonusProvince.Name,
                                               Tarih = entit.SeferBilgisi.Tarih,
                                               Surname = entit.Kisi.Surname,
                                               Cinsiyet = entit.Kisi.Cinsiyet.ToString(),
                                               KisiIsmi = entit.Kisi.Name,
                                               SeferNumber = entit.SeferNumara,
                                               VerildigiTarihi = entit.VerildigiTarihi
                                           }).FirstOrDefault();
                
            }
            catch (Exception ex)
            {

                Trace.TraceError(ex.ToString());
                return default;
            }
        }

        protected override Bilet MapToEntity(BiletDto model)
        {
            return new Bilet()
            {
                SeferNumara = model.SeferNumara,
                SeferId = model.SeferId,
                HumanId = model.HumanId,
                Price = model.Price,
                KoltukNumarası = model.KoltukNumarası,
                VerildigiTarihi = model.VerildigiTarihi
            };
        }
    }
}
