using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaferTurizm.Domain
{
    public class Rota:IEntity
    {
        public int Id{ get; set; }

        public int GidisId { get; set; }
        public int DonusId { get; set; }
        public Province GidisProvince{ get; set; }
        public Province DonusProvince { get; set; }
       
    }
}
