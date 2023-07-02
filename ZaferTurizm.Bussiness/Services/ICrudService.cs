using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Dtos;
using ZaferTurizm.Summay;

namespace ZaferTurizm.Bussiness.Services
{
    public interface ICrudService<TDto,TSummray>
    {
        CommadResult Create(TDto model);
        
        CommadResult Update(TDto model);
        CommadResult Delete(TDto model);
        CommadResult Delete(int Id);
        TDto? GetById(int Id);
        IEnumerable<TDto> GetAll();
        TSummray? GetSummaryById(int id);
        IEnumerable<TSummray> GetSummary();
    }
}
