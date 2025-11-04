using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubricaUtils
{
    public struct Indirizzo
    {
        public string Via {  get; set; }
        public int NumeroCivico { get; set; }
        public Citta Citta { get; set; }
        public Provincia Provincia { get; set; }
        public Indirizzo(string via, int numciv, Citta citta, Provincia provincia)
        {
            Via = via;
            NumeroCivico = numciv;
            Citta = citta;
            Provincia = provincia;
        }
        public override string ToString()
        {
            return $"{Via}, {NumeroCivico}, {Citta} ({Provincia})";
        }
    }
}
