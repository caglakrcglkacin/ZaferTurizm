using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaferTurizm.Summay
{
    public class VehicleDefinitionSummary
    {
        public int Id { get; set; }
        public string VehicleMakeName { get; set; }
        public string VehicleModelName { get; set; }
        public int Year { get; set; }
        public int SeatCount { get; set; }
        public bool HasTailet { get; set; }
        public string HasTailetString {
            get
            {
                return HasTailet ? "Var" : "Yok";
            }
        }
        public bool HasWifi { get; set; }
        public string HasWifiString => HasWifi ? "Var" : "Yok";
    }
}
