using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuzellıkMerkezıOtomasyonu
{
    public class Hizmet
    {
        public int HizmetID { get; set; }
        public string HizmetAdi { get; set; }
        public int TurID { get; set; }
        public string TurAdi { get; set; } 
        public decimal Fiyat { get; set; }
        public int Sure { get; set; }
        public int ToplamSeans { get; set; }

        public Hizmet() { }

        public Hizmet(int hizmetID, string hizmetAdi, int turID, string turAdi, decimal fiyat, int sure, int toplamSeans)
        {
            HizmetID = hizmetID;
            HizmetAdi = hizmetAdi;
            TurID = turID;
            TurAdi = turAdi;
            Fiyat = fiyat;
            Sure = sure;
            ToplamSeans = toplamSeans;
        }
    }
}
