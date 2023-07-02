using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Domain;

namespace ZaferTurizm.Dtos
{
    public class VehicleDto
    {
        public int Id { get; set; }
        public int VehicleDefintionId { get; set; }
        public int VehicleMakeId { get; set; }
        public int VehicleModelId { get; set; }
      
        public string PlateNumber { get; set; }
    }
}
