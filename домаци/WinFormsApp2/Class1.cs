using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp2
{
    internal class Vrsta
    {
        public string latinskiNaziv, lokalniNaziv,
                      lokacija, vrsta;

        public Vrsta(string latn, string lokn, string lok, string vrst) {
            latinskiNaziv = latn;
            lokalniNaziv = lokn;
            lokacija = lok;
            vrsta = vrst;
        }

        public override string ToString()
        {
            return latinskiNaziv + ", "  + lokalniNaziv + ", " + lokacija 
                + ", " + vrsta.ToString();
        }
    }
}
