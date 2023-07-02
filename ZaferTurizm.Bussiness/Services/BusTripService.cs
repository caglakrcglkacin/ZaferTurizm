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
    public class BusTripService : CrudService<OtobusSeferiDto, OtobusSeferiSummary, OtobusSefer>, IBusTripService
    {
        public BusTripService(TourDbContext tourDbContext):base(tourDbContext)
        {

        }
        protected override Expression<Func<OtobusSefer, OtobusSeferiDto>> DtoMapper => entit => new OtobusSeferiDto()
        {
            Id = entit.Id,
            RotaId = entit.RotaId,
            Tarih = entit.Tarih,
            VehicleDefintionId = entit.VehicleDefintionId,
            Fiyat = entit.Fiyat
        };

        protected override Expression<Func<OtobusSefer, OtobusSeferiSummary>> SummaryMapper => entit => new OtobusSeferiSummary() { 
         Id = entit.Id,
         GidisYonu = entit.rota.GidisProvince.Name,
         VarisYonu = entit.rota.DonusProvince.Name,
         KoltukNumarasi = entit.vehicleDefintion.SeatCount,
         Tarih = entit.Tarih,
          HasWifi = entit.vehicleDefintion.HasWifi,
          HasTaiet = entit.vehicleDefintion.HasTailet,
          Year = entit.vehicleDefintion.Year,
          MarkaName = entit.vehicleDefintion.VehicleModel.VehicleMake.Name,
          ModelName = entit.vehicleDefintion.VehicleModel.Name,
          Fiyat = entit.Fiyat


        };

        public BiletBilgiSummary? GetBusTripDetails(int id)
        {
            try
            {
                    var listele = _tourDbContext.OtobusSefers
                    .Where(entit => entit.Id == id)
                    .Select(entit => new BiletBilgiSummary()
                    {
                        busTripId = entit.Id,
                        GidisYonu = entit.rota.GidisProvince.Name,
                        VarisYonu = entit.rota.DonusProvince.Name,
                        KoltukNumarasi = entit.vehicleDefintion.SeatCount,
                        Tarih = entit.Tarih,
                        HasWifi = entit.vehicleDefintion.HasWifi,
                        HasTaiet = entit.vehicleDefintion.HasTailet,
                        Year = entit.vehicleDefintion.Year,
                        MarkaName = entit.vehicleDefintion.VehicleModel.VehicleMake.Name,
                        ModelName = entit.vehicleDefintion.VehicleModel.Name,
                        Fiyat = entit.Fiyat
                    }).SingleOrDefault();
                return listele;
            }
            catch (Exception ex)
            {

                Trace.TraceError(ex.ToString());
                return default;
            }
        }

        public IEnumerable<BiletBilgiSummary> GetTripsWithRouteId(int id)
        {
            try
            {
                return _tourDbContext.OtobusSefers
                    .Where(x => x.RotaId == id)
                    .Select(entit => new BiletBilgiSummary()
                    {
                        busTripId = entit.Id,
                        GidisYonu = entit.rota.GidisProvince.Name,
                        VarisYonu = entit.rota.DonusProvince.Name,
                        KoltukNumarasi = entit.vehicleDefintion.SeatCount,
                        Tarih = entit.Tarih,
                        HasWifi = entit.vehicleDefintion.HasWifi,
                        HasTaiet = entit.vehicleDefintion.HasTailet,
                        Year = entit.vehicleDefintion.Year,
                        MarkaName = entit.vehicleDefintion.VehicleModel.VehicleMake.Name,
                        ModelName = entit.vehicleDefintion.VehicleModel.Name,
                        Fiyat = entit.Fiyat
                    }).ToList() ;
            }
            catch (Exception ex)
            {

                Trace.TraceError(ex.ToString());
                return Enumerable.Empty<BiletBilgiSummary>();
            }
        }

        protected override OtobusSefer MapToEntity(OtobusSeferiDto model)
        {
            return new OtobusSefer()
            {
                Id = model.Id,
                RotaId = model.RotaId,
                Tarih = model.Tarih,
                VehicleDefintionId = model.VehicleDefintionId,
                Fiyat = model.Fiyat
            };
        }
    }
}
