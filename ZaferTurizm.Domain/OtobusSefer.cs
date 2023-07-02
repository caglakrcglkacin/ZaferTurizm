using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaferTurizm.Domain
{
    public class OtobusSefer:IEntity
    {
        public int Id { get; set; }
        public int RotaId { get; set; }
        public Rota rota { get; set; }
        public DateTime Tarih { get; set; }
        public int VehicleDefintionId { get; set; }
        public VehicleDefintion vehicleDefintion { get; set; }
        public decimal Fiyat { get; set; }
    }
}
