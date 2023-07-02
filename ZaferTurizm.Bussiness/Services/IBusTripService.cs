using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Dtos;
using ZaferTurizm.Summay;

namespace ZaferTurizm.Bussiness.Services
{
    public interface IBusTripService: ICrudService<OtobusSeferiDto, OtobusSeferiSummary>
    {
        IEnumerable<BiletBilgiSummary> GetTripsWithRouteId(int id);
        BiletBilgiSummary? GetBusTripDetails(int id);
    }
}
