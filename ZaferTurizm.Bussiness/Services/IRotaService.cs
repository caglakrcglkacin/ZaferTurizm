using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Dtos;
using ZaferTurizm.Summay;

namespace ZaferTurizm.Bussiness.Services
{
    public interface IRotaService
    {
        CommadResult Create(RotaDto model);
        CommadResult Update(RotaDto model);
        CommadResult Delete(RotaDto model);
        CommadResult Delete(int Id);
        RotaDto? GetById(int Id);
        IEnumerable<RotaDto> GetAll();
        IEnumerable<RotaSummary> GetDefintId(int Id);
        IEnumerable<RotaSummary> GetSummary();
    }
}
