using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tesztverseny
{
    class diak
    {
        string azonosito;
        string valaszok;

        public diak(string azonosito, string valaszok)
        {
            this.Azonosito = azonosito;
            this.Valaszok = valaszok;
        }

        public string Azonosito { get => azonosito; set => azonosito = value; }
        public string Valaszok { get => valaszok; set => valaszok = value; }
    }
}
