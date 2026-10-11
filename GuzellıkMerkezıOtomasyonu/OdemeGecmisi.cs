using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuzellıkMerkezıOtomasyonu
{
    public class OdemeGecmisi
    {
        public string OdemeTipi { get; set; }        // "Peşin" veya "Taksit"
        public decimal Tutar { get; set; }
        public DateTime OdemeTarihi { get; set; }
        public string Aciklama { get; set; }         // ✅ Eklendi
    }
}
