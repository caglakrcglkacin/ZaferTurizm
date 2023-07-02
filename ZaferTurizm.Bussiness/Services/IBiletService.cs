using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Dtos;
using ZaferTurizm.Summay;

namespace ZaferTurizm.Bussiness.Services
{
    public interface IBiletService: ICrudService<BiletDto, BiletSummary>
    {
        BiletSummary? GetBilet(int id,DateTime date);
    }
}
