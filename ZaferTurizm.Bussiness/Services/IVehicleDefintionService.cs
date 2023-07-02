using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Dtos;
using ZaferTurizm.Summay;

namespace ZaferTurizm.Bussiness.Services
{
    public interface IVehicleDefintionService
    {
        CommadResult Create(VehicleDefintionDto model);
        CommadResult Update(VehicleDefintionDto model);
        CommadResult Delete(VehicleDefintionDto model);
        CommadResult Delete(int Id);
        VehicleDefintionDto? GetById(int Id);
        IEnumerable<VehicleDefintionDto> GetAll();
        IEnumerable<VehicleDefinitionSummary> GetDefintId(int Id);
        IEnumerable<VehicleDefinitionSummary> GetSummary();
    }
}
