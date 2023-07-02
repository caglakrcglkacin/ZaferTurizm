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
    public class VehicleService : IVehicleService
    {
        TourDbContext _tourDbContext;
        public VehicleService(TourDbContext tourDbContext)
        {
            _tourDbContext = tourDbContext;
        }
        public CommadResult Create(VehicleDto model)
        {
            try
            {
                //Mapping

                var VehicleMakes = new Vehicle()
                {
                    VehicleDefintionId = model.VehicleDefintionId,
                    PlateNumber= model.PlateNumber
                };
                _tourDbContext.Vehicles.Add(VehicleMakes);
                _tourDbContext.SaveChanges();
                return CommadResult.Success();


            }
            catch (Exception ex)
            {

                return CommadResult.Failure();
            }
        }

        public CommadResult Delete(VehicleDto model)
        {
            try
            {
                //Mapping

                var VehicleMakes = new Vehicle()
                {
                    Id = model.Id,
                    VehicleDefintionId = model.VehicleDefintionId,
                    PlateNumber = model.PlateNumber
                };
                _tourDbContext.Vehicles.Remove(VehicleMakes);
                _tourDbContext.SaveChanges();
                return CommadResult.Success();


            }
            catch (Exception ex)
            {

                return CommadResult.Failure();
            }
        }

        public CommadResult Delete(int Id)
        {
            try
            {
                //Mapping

                var VehicleMakes = new Vehicle()
                {
                  Id = Id
                };
                _tourDbContext.Vehicles.Remove(VehicleMakes);
                _tourDbContext.SaveChanges();
                return CommadResult.Success();


            }
            catch (Exception ex)
            {

                return CommadResult.Failure();
            }
        }

        public IEnumerable<VehicleDto> GetAll()
        {
            return _tourDbContext.Vehicles.Select(model => new VehicleDto()
            {
                Id = model.Id,
                VehicleDefintionId = model.VehicleDefintionId,
                PlateNumber = model.PlateNumber
            }).ToList();
        }

        public VehicleDto GetById(int Id)
        {
            var model = _tourDbContext.Vehicles.Find(Id);
            if (model == null)
            {
                return null;
            }
            var entity = new VehicleDto()
            {

                Id = model.Id,
                VehicleDefintionId = model.VehicleDefintionId,
                PlateNumber = model.PlateNumber
            };
            return entity;
        }

        public IEnumerable<VehicleSummary> GetSummary()
        {
            try
            {
                return _tourDbContext.Vehicles.Select(model => new VehicleSummary()
                {
                    Id = model.Id,
               
                    PlateNumber = model.PlateNumber
                }).ToList();

            }
            catch (Exception ex)
            {

                Trace.TraceError(ex.ToString());

                throw;
            }
        }

        public CommadResult Update(VehicleDto model)
        {
            try
            {
                //Mapping

                var VehicleMakes = new Vehicle()
                {
                    Id=model.Id,
                    VehicleDefintionId = model.VehicleDefintionId,
                    PlateNumber = model.PlateNumber
                };
                _tourDbContext.Vehicles.Update(VehicleMakes);
                _tourDbContext.SaveChanges();
                return CommadResult.Success();


            }
            catch (Exception ex)
            {

                return CommadResult.Failure();
            }
        }
    }
}
