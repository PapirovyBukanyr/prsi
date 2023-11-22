using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prsi
{
    internal class Hrac
    {
        public List<Karta> Karty_hrace { get; set; }
        public Hrac()
        {
            Karty_hrace = new List<Karta>();
        }
        public void Pridat_kartu(Karta karta)
        {
            if(karta != null)
            Karty_hrace.Add(karta);
        }

        public Karta Zahrat_kartu (Karta posledni_karta)
        {
            foreach(Karta karta in Karty_hrace)
            {
                if (karta.Barva == posledni_karta.Barva || karta.Hodnota == posledni_karta.Hodnota) 
                { 
                    Karty_hrace.Remove(karta);
                    return karta; 
                }
            }
            return null;
        }
        public Karta Zahrat_kartu_po_sedmicce()
        {
            foreach (Karta karta in Karty_hrace)
            {
                if (karta.Hodnota == Hodnoty_karet.Sedmička)
                {
                    Karty_hrace.Remove(karta);
                    return karta;
                }
                if (karta.Hodnota == Hodnoty_karet.Král && karta.Barva == Barvy_karet.Piky)
                {
                    Karty_hrace.Remove(karta);
                    return karta;
                }
            }
            return null;
        }
        public Karta Zahrat_kartu_po_esu()
        {
            foreach (Karta karta in Karty_hrace)
            {
                if (karta.Hodnota == Hodnoty_karet.Eso)
                {
                    Karty_hrace.Remove(karta);
                    return karta;
                }
            }
            return null;
        }

        internal Karta Zahrat_lepsi_kartu(Karta posledni_karta)
        {
            foreach (Karta karta in Karty_hrace)
            {
                if (
                    (
                        karta.Barva == posledni_karta.Barva 
                        || 
                        karta.Hodnota == posledni_karta.Hodnota
                    )
                    &&!
                    (
                        karta.Hodnota==Hodnoty_karet.Sedmička 
                        || 
                        (
                            karta.Hodnota == Hodnoty_karet.Král 
                            && 
                            karta.Barva == Barvy_karet.Piky
                        )
                    )
                )
                {
                    Karty_hrace.Remove(karta);
                    return karta;
                }
            }
            foreach (Karta karta in Karty_hrace)
            {
                if (karta.Barva == posledni_karta.Barva || karta.Hodnota == posledni_karta.Hodnota )
                {
                    Karty_hrace.Remove(karta);
                    return karta;
                }
            }
            return null;
        }
    }
}
