using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.DataAccess;

using ZaferTurizm.Domain;
using ZaferTurizm.Dtos;
using ZaferTurizm.Summay;
using VehicleMake = ZaferTurizm.Domain.VehicleMake;

namespace ZaferTurizm.Bussiness.Services
{
    public class VehicleMakeService:CrudService<VehicleMakeDto,VehicleMakeSummray,VehicleMake>,IVehicleMakeService
    {
        public VehicleMakeService(TourDbContext tourDbContext): base(tourDbContext)
        {

        }
        protected override Expression<Func<VehicleMake, VehicleMakeDto>> DtoMapper => 
            entitys => new VehicleMakeDto()
            {
                Id = entitys.Id,
                Name = entitys.Name
            };

        protected override Expression<Func<VehicleMake, VehicleMakeSummray>> SummaryMapper => 
            entity => new VehicleMakeSummray()
            {
                Id = entity.Id,
                Name = entity.Name
            };

        protected override VehicleMake MapToEntity(VehicleMakeDto model)
        {
            return new VehicleMake()
            {
                Id = model.Id,
                Name = model.Name
            };
        }
    }
}
