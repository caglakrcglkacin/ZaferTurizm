using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Domain;

namespace ZaferTurizm.Dtos
{
    public class RotaDto
    {
        public int Id { get; set; }
        public int GidisId { get; set; }
        public int VarisYonuId { get; set; }
        public Province Province { get; set; }
    }
}
