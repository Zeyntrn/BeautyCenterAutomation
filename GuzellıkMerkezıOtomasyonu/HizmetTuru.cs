using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuzellıkMerkezıOtomasyonu
{
    public class HizmetTuru
    {
        public int TurID { get; set; }
        public string TurAdi { get; set; }

        public HizmetTuru(int turID, string turAdi)
        {
            TurID = turID;
            TurAdi = turAdi;
        }

        public override string ToString()
        {
            return TurAdi;
        }


    }


}
