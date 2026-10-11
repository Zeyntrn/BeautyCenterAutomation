using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuzellıkMerkezıOtomasyonu
{
    public class StokHareketi
    {
        public int HareketID { get; set; }
        public int UrunID { get; set; }
        public string HareketTuru { get; set; }  // "Giriş", "Satış", "Seans"
        public int Miktar { get; set; }
        public DateTime HareketTarihi { get; set; }
        public string Aciklama { get; set; }
        public int CalisanID { get; set; }

        public string CalisanAdi { get; set; }


        // Ekranda ürün adı göstermek istenirse:
        public string UrunAdi { get; set; }

        public StokHareketi(int urunID, string hareketTuru, int miktar, DateTime tarih, string aciklama, int calisanID)
        {
            UrunID = urunID;
            HareketTuru = hareketTuru;
            Miktar = miktar;
            HareketTarihi = tarih;
            Aciklama = aciklama;
            CalisanID = calisanID;

        }
    }
}
