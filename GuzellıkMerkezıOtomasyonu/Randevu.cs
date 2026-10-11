using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuzellıkMerkezıOtomasyonu
{
    public class Randevu
    {
        public int RandevuID { get; set; }
        public int MusteriID { get; set; }
        public int CalisanID { get; set; }
        public int HizmetID { get; set; }
        public DateTime RandevuTarihi { get; set; }
        public string RandevuSaati { get; set; }
        public int ToplamSeans { get; set; }
        public int KalanSeans { get; set; }
        public string Durum { get; set; }
    }

    public class RandevuSaat
    {
        public TimeSpan Saat { get; set; }
        public int Sure { get; set; }
    }
}
