using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Domain;

namespace ZaferTurizm.Dtos
{
    public class VehicleDefintionDto
    {
        public int Id { get; set; }
        public int VehicleMakeId { get; set; }
        public int VehicleModelId { get; set; }
        public int Year { get; set; }
        public int SeatCount { get; set; }
        public bool HasTailet { get; set; }
        public bool HasWifi { get; set; }
        
    }
}
