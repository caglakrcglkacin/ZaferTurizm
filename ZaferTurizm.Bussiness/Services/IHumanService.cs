using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Dtos;

namespace ZaferTurizm.Bussiness.Services
{
    public interface IHumanService
    {
        CommadResult Create(HumanDto model);
        CommadResult Update(HumanDto model);
        CommadResult Delete(HumanDto model);
        CommadResult Delete(int Id);
        HumanDto GetById(int Id);
        HumanDto? GetByIdent(string KimlikId);
        IEnumerable<HumanDto> GetAll();
    }
}
