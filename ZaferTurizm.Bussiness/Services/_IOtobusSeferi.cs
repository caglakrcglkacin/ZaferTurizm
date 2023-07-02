using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Dtos;
using ZaferTurizm.Summay;

namespace ZaferTurizm.Bussiness.Services
{
    public interface _IOtobusSeferi
    {
        CommadResult Create(OtobusSeferiDto model);
        CommadResult Creating(OtobusSeferiDto model,int Id);
        CommadResult Update(OtobusSeferiDto model);
        CommadResult Delete(OtobusSeferiDto model);
        CommadResult Delete(int Id);
        OtobusSeferiDto? GetById(int Id);
        IEnumerable<OtobusSeferiDto> GetAll();
        IEnumerable<OtobusSeferiSummary> GetDefintId(int Id);
        IEnumerable<OtobusSeferiSummary> GetSummary();
    }
}
