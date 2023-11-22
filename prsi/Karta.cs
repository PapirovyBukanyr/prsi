using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prsi
{
    internal class Karta
    {
        public Hodnoty_karet Hodnota {  get; init; }
        public Barvy_karet Barva { get; init; }
        public Karta(Hodnoty_karet hodnota,Barvy_karet barva)
        {
            Hodnota = hodnota;
            Barva = barva;
        }
        public override string ToString()
        {
            return Barva.ToString()+" "+Hodnota.ToString();
        }
    }
}
