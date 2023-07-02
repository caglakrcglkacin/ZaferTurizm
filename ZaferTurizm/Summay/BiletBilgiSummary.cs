using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaferTurizm.Summay
{
    public class BiletBilgiSummary
    {
        public int busTripId { get; set; }
        public string GidisYonu { get; set; }
        public string KisiId { get; set; }
        public string VarisYonu { get; set; }
        public int KoltukNumarasi { get; set; }
        public DateTime Tarih { get; set; }
        public bool HasWifi { get; set; }
        public bool HasTaiet { get; set; }
        public string VehicleBilgiler => $"{MarkaName} {ModelName} {Year} ";
        public string RotaBilgisi => $"{GidisYonu} {VarisYonu}";
        public string HasWifiString => HasWifi ? "Var" : "Yok";
        public string HasTaietString => HasWifi ? "Var" : "Yok";
        public int Year { get; set; }
        public int SeferNumber { get; set; }
        public string MarkaName { get; set; }
        public string ModelName { get; set; }
        public decimal Fiyat { get; set; }
    }
}
