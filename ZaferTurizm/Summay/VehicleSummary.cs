using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Domain;

namespace ZaferTurizm.Summay
{
    public class VehicleSummary
    {
        public int Id { get; set; }
        public string VehicleMakeName { get; set; }
        public string VehicleModelName { get; set; }
      
        public string PlateNumber { get; set; }
    }
}
