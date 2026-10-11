using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuzellıkMerkezıOtomasyonu
{
    public class Calisan
    {
        public int CalisanID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public string KullaniciTuru { get; set; }
        public List<int> UzmanlikAlanlari { get; set; }

        public List<int> Uzmanliklar { get; set; }

        public Calisan(string ad, string soyad, string telefon, string email, string kullaniciAdi, string sifre, string kullaniciTuru, List<int> uzmanlikAlanlari)
        {
            Ad = ad;
            Soyad = soyad;
            Telefon = telefon;
            Email = email;
            KullaniciAdi = kullaniciAdi;
            Sifre = sifre;
            KullaniciTuru = kullaniciTuru;
            UzmanlikAlanlari = uzmanlikAlanlari;
        }

        public Calisan(int calisanID, string ad, string soyad, string telefon, string email, string kullaniciAdi, string sifre, string kullaniciTuru, List<int> uzmanlikAlanlari)
        {
            CalisanID = calisanID;
            Ad = ad;
            Soyad = soyad;
            Telefon = telefon;
            Email = email;
            KullaniciAdi = kullaniciAdi;
            Sifre = sifre;
            KullaniciTuru = kullaniciTuru;
            UzmanlikAlanlari = uzmanlikAlanlari;
        }
    }
}
