using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZaferTurizm.Domain;

namespace ZaferTurizm.Summay
{
    public class RotaSummary
    {
        public int Id { get; set; }
        public string GidisYonu { get; set; }
        public string VarisYonu { get; set; }
        public Province Province { get; set; }
    }
}
