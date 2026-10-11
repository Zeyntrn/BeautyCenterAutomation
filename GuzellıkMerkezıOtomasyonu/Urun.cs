using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuzellıkMerkezıOtomasyonu
{
    public class Urun
    {
        public int UrunID { get; set; }
        public string UrunAdi { get; set; }
        public decimal BirimFiyat { get; set; }

        public Urun(int urunID, string urunAdi, decimal birimFiyat)
        {
            UrunID = urunID;
            UrunAdi = urunAdi;
            BirimFiyat = birimFiyat;
        }
    }
}
