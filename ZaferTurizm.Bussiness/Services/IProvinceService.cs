using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Dtos;

namespace ZaferTurizm.Bussiness.Services
{
    public interface IProvinceService
    {
        CommadResult Create(ProvinceDto model);
        CommadResult Update(ProvinceDto model);
        CommadResult Delete(ProvinceDto model);
        CommadResult Delete(int Id);
        ProvinceDto GetById(int Id);
        IEnumerable<ProvinceDto> GetAll();
    }
}
