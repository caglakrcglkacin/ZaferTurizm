using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaferTurizm.Domain
{
    public class VehicleDefintion:IEntity
    {
        public int Id { get; set; }
        public VehicleModel VehicleModel { get; set; }
        public int VehicleModelId { get; set; }
        public int Year { get; set; }
        public int SeatCount { get; set; }
        public bool HasTailet { get; set; }
        public bool HasWifi { get; set; }
    }
}
