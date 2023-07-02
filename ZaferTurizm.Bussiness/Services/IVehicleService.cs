using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Dtos;
using ZaferTurizm.Summay;

namespace ZaferTurizm.Bussiness.Services
{
    public interface IVehicleService
    {
        CommadResult Create(VehicleDto model);
        CommadResult Update(VehicleDto model);
        CommadResult Delete(VehicleDto model);
        CommadResult Delete(int Id);
        VehicleDto GetById(int Id);
        IEnumerable<VehicleDto> GetAll();
        IEnumerable<VehicleSummary> GetSummary();
    }
}
