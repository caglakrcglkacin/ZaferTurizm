using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.DataAccess;
using ZaferTurizm.Domain;
using ZaferTurizm.Dtos;
using ZaferTurizm.Summay;

namespace ZaferTurizm.Bussiness.Services
{
    public class _OtobusService : _IOtobusSeferi
    {
        TourDbContext _tourDbContext;
        public _OtobusService(TourDbContext tourDbContext)
        {
            _tourDbContext = tourDbContext;
        }
        public CommadResult Create(OtobusSeferiDto model)
        {
            try
            {
                var sefer = new OtobusSefer()
                {
                    RotaId =model.RotaId,
                    VehicleDefintionId = model.VehicleDefintionId,
                    Tarih = model.Tarih,
                    Fiyat = model.Fiyat
                };
                _tourDbContext.Add(sefer);
                _tourDbContext.SaveChanges();
                return CommadResult.Success();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.Message.ToString());
                return CommadResult.Failure();
            }
        }

        public CommadResult Creating(OtobusSeferiDto model, int Id)
        {
            try
            {
                var sefer = new OtobusSefer()
                {
                    RotaId=Id,
                    VehicleDefintionId = model.VehicleDefintionId,
                    Tarih = model.Tarih,
                    Fiyat = model.Fiyat
                };
                _tourDbContext.Add(sefer);
                _tourDbContext.SaveChanges();
                return CommadResult.Success();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.Message.ToString());
                return CommadResult.Failure();
            }
        }

        public CommadResult Delete(OtobusSeferiDto model)
        {
            try
            {
                var sefer = new OtobusSefer()
                {
                    Id = model.Id,
                    RotaId = model.RotaId,
                    VehicleDefintionId = model.VehicleDefintionId,
                    Tarih = model.Tarih,
                    Fiyat = model.Fiyat
                };
                _tourDbContext.Remove(sefer);
                _tourDbContext.SaveChanges();
                return CommadResult.Success();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.Message.ToString());
                return CommadResult.Failure();
            }
        }

        public CommadResult Delete(int Id)
        {
            try
            {
                var sefer = new OtobusSefer()
                {
                  Id=Id
                };
                _tourDbContext.Remove(sefer);
                _tourDbContext.SaveChanges();
                return CommadResult.Success();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.Message.ToString());
                return CommadResult.Failure();
            }
        }

        public IEnumerable<OtobusSeferiDto> GetAll()
        {
            try
            {
              return  _tourDbContext.OtobusSefers.Select(model => new OtobusSeferiDto()
                {
                    Id = model.Id,
                    RotaId = model.RotaId,
                    VehicleDefintionId = model.VehicleDefintionId,
                    Tarih = model.Tarih,
                    Fiyat = model.Fiyat

                }).ToList();
               
            }
            catch (Exception ex)
            {

                Trace.TraceError(ex.Message.ToString());
                return new List<OtobusSeferiDto>(); 
            }
        }

        public OtobusSeferiDto? GetById(int Id)
        {
            try
            {
              var sefer =  _tourDbContext.OtobusSefers.Find(Id);
                if (sefer == null)
                {
                    return null;
                }
                var otobusSeferi = new OtobusSeferiDto()
                {
                    Id = sefer.Id,
                    RotaId= sefer.RotaId,
                    VehicleDefintionId = sefer.VehicleDefintionId,
                    Tarih = sefer.Tarih,
                    Fiyat = sefer.Fiyat

                };
                return otobusSeferi;

            }
            catch (Exception ex)
            {

                Trace.TraceError(ex.Message.ToString());
                return new OtobusSeferiDto();
            }
        }

        public IEnumerable<OtobusSeferiSummary> GetDefintId(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OtobusSeferiSummary> GetSummary()
        {
            try
            {
                return _tourDbContext.OtobusSefers.Select(model => new OtobusSeferiSummary()
                {
                    Id = model.Id,
                    VarisYonu = model.rota.DonusProvince.Name,
                    GidisYonu = model.rota.GidisProvince.Name,
                    HasWifi = model.vehicleDefintion.HasWifi,
                    HasTaiet = model.vehicleDefintion.HasTailet,
                    Year = model.vehicleDefintion.Year,
                     Tarih = model.Tarih,
                    Fiyat = model.Fiyat



                }).ToList() ;
            }
            catch (Exception ex)
            {

                Trace.TraceError(ex.Message.ToString());
                return new List<OtobusSeferiSummary>();
            }
            
        }

        public CommadResult Update(OtobusSeferiDto model)
        {
            try
            {
                var sefer = new OtobusSefer()
                {
                    Id = model.Id,
                  RotaId = model.RotaId,
                    VehicleDefintionId = model.VehicleDefintionId,
                    Tarih = model.Tarih,
                    Fiyat = model.Fiyat
                };
                _tourDbContext.Update(sefer);
                _tourDbContext.SaveChanges();
                return CommadResult.Success();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.Message.ToString());
                return CommadResult.Failure();
            }
        }
    }
}
