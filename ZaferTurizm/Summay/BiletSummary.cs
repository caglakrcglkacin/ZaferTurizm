using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZaferTurizm.Summay
{
    public class BiletSummary
    {
        public int BiletId { get; set; }
        public string KisiBilgileri => $"{KisiIsmi} {Surname} {Cinsiyet}";
        public string BiletBilgileri => $"{GidisYonu} {VarisYonu} {Tarih} {Fiyat}";
        public int KoltukNumarası { get; set; }
        public int SeferNumber { get; set; }
        public decimal Price { get; set; }
        public string KisiIsmi { get; set; }
        public string Surname { get; set; }
        public string Cinsiyet { get; set; }
        public string GidisYonu { get; set; }
        public string VarisYonu { get; set; }
        public DateTime Tarih { get; set; }
        public DateTime VerildigiTarihi { get; set; }
        public decimal Fiyat { get; set; }
    }
}
