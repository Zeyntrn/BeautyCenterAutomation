using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuzellıkMerkezıOtomasyonu
{
    public class TaksitBilgisi
    {
        public int TaksitID { get; set; }
        public int TaksitNo { get; set; }
        public decimal Tutar { get; set; }
        public DateTime VadeTarihi { get; set; }
        public string Durum { get; set; }
    }
}
