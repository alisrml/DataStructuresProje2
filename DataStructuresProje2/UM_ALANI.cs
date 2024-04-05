using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresProje2
{
    internal class UM_ALANI
    {
        public string alanAdi;
        public List<string> ilAdlari;
        public string ilanYili;

        public UM_ALANI(string alanAdi, List<string> ilAdlari,string ilanYili) 
        {
            this.alanAdi = alanAdi;
            this.ilAdlari = ilAdlari;
            this.ilanYili = ilanYili;
        
        }
    }
}
