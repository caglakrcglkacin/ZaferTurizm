using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Domain;

namespace ZaferTurizm.Dtos
{
    public class OtobusSeferiDto
    {
        public int Id { get; set; }
        public int RotaId { get; set; }
        public DateTime Tarih { get; set; }
        public int VehicleDefintionId { get; set; }
        public decimal Fiyat { get; set; }
        public Rota Rotas { get; set; }
        public VehicleDefintion VehicleDefintion { get; set; }
    }
}
