using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Dtos;
using ZaferTurizm.Summay;

namespace ZaferTurizm.Bussiness.Services
{
    public interface IVehicleModelService
    {
        CommadResult Create(VehicleModelDto model);
        CommadResult Update(VehicleModelDto model);
        CommadResult Delete(VehicleModelDto model);
        CommadResult Delete(int Id);
        VehicleModelDto GetById(int Id);
        IEnumerable<VehicleModelDto> GetAll();
        IEnumerable<VehicleModelDto> GetByMakeId(int vehicleMakeId);
        IEnumerable<VehicleModelSummay> GetSummary();
    }
}
