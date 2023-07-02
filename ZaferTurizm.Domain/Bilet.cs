using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ZaferTurizm.Domain
{
    public class Bilet : IEntity
    {
        public int Id { get; set; }
        public int HumanId { get; set; }
        public int SeferId { get; set; }
        public int KoltukNumarası { get; set; }
        public decimal Price { get; set; }
        public int SeferNumara { get; set; }
        public DateTime VerildigiTarihi { get; set; }
        public HumanInformation Kisi { get; set; }
        public OtobusSefer SeferBilgisi { get; set; }
    }
}
