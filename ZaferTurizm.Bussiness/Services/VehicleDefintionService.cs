using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage;
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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ZaferTurizm.Bussiness.Services
{
    public class VehicleDefintionService : IVehicleDefintionService
    {
        TourDbContext _tourDbContext;
        public VehicleDefintionService(TourDbContext tourDbContext)
        {
            _tourDbContext = tourDbContext;
        }
        public CommadResult Create(VehicleDefintionDto model)
        {
            try
            {
                var entity = new VehicleDefintion()
                {
                    SeatCount = model.SeatCount,
                    Year = model.Year,
                    VehicleModelId = model.VehicleModelId,
                    HasTailet = model.HasTailet,
                    HasWifi = model.HasWifi
                };
                _tourDbContext.VehicleDefinitions.Add(entity);
                _tourDbContext.SaveChanges();
                return CommadResult.Success();
            }
            catch (Exception)
            {

                return CommadResult.Failure();
            }
        }

        public CommadResult Delete(VehicleDefintionDto model)
        {
            try
            {
                var entity = new VehicleDefintion()
                {
                    Id =model.Id,
                    SeatCount = model.SeatCount,
                    Year = model.Year,
                    VehicleModelId = model.VehicleModelId,
                    HasTailet = model.HasTailet,
                    HasWifi = model.HasWifi
                };
                _tourDbContext.VehicleDefinitions.Remove(entity);
                _tourDbContext.SaveChanges();
                return CommadResult.Success();
            }
            catch (Exception)
            {

                return CommadResult.Failure();
            }
        }

        public CommadResult Delete(int Id)
        {
            try
            {
                var entity = new VehicleDefintion()
                {
                   Id=Id
                };
                _tourDbContext.VehicleDefinitions.Remove(entity);
                _tourDbContext.SaveChanges();
                return CommadResult.Success();
            }
            catch (Exception)
            {

                return CommadResult.Failure();
            }
        }

        public IEnumerable<VehicleDefintionDto> GetAll()
        {
            return _tourDbContext.VehicleDefinitions.Select(model => new VehicleDefintionDto()
            {
                Id = model.Id,
                SeatCount = model.SeatCount,
                Year = model.Year,
                VehicleModelId = model.VehicleModelId,
                HasTailet = model.HasTailet,
                HasWifi = model.HasWifi
            }).ToList();
        }

        public VehicleDefintionDto GetById(int Id)
        {
            try
            {
           var model = _tourDbContext.VehicleDefinitions
            .Select(p => new VehicleDefintionDto()
            {
                Id = p.Id,
                VehicleMakeId = p.VehicleModel.VehicleMakeId,
                VehicleModelId = p.VehicleModelId,
                Year = p.Year,
                SeatCount = p.SeatCount,
                HasTailet = p.HasTailet,
                HasWifi = p.HasWifi
            }).SingleOrDefault(p => p.Id == Id);
                return model;
            }
            catch (Exception)
            {

               return null;
            }
            
      
        }

        public IEnumerable<VehicleDefinitionSummary> GetDefintId(int Id)
        {
            try
            {
                return _tourDbContext.VehicleDefinitions.Where(dto => dto.VehicleModelId == Id)
                    .Select(entity => new VehicleDefinitionSummary()
                    {
                        Id = entity.Id,
                        VehicleMakeName = entity.VehicleModel.VehicleMake.Name,
                        VehicleModelName= entity.VehicleModel.Name,
                        HasTailet = entity.HasTailet,
                        HasWifi=entity.HasWifi,
                        SeatCount = entity.SeatCount,
                        Year = entity.Year
                    }).ToList();

            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
                return new List<VehicleDefinitionSummary>();
            }
        }

        public IEnumerable<VehicleDefinitionSummary> GetSummary()
        {
            try
            {
                return _tourDbContext.VehicleDefinitions.Select(model => new VehicleDefinitionSummary()
                {
                    Id = model.Id,
                    SeatCount = model.SeatCount,
                    Year = model.Year,
                    VehicleModelName = model.VehicleModel.Name,
                    VehicleMakeName=model.VehicleModel.VehicleMake.Name,
                    HasTailet = model.HasTailet,
                    HasWifi = model.HasWifi
                }).ToList();
               
            }
            catch (Exception ex)
            {

                Trace.TraceError(ex.ToString());

                throw;
            }
        }

        public CommadResult Update(VehicleDefintionDto model)
        {
            try
            {
                var entity = new VehicleDefintion()
                {
                    Id = model.Id,
                    SeatCount = model.SeatCount,
                    Year = model.Year,
                    VehicleModelId = model.VehicleModelId,
                    HasTailet = model.HasTailet,
                    HasWifi = model.HasWifi
                };
                _tourDbContext.VehicleDefinitions.Update(entity);
                _tourDbContext.SaveChanges();
                return CommadResult.Success();
            }
            catch (Exception)
            {

                return CommadResult.Failure();
            }
        }
    }
}
