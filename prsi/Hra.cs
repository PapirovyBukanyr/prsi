using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace prsi
{
    internal class Hra
    {
        byte PocetHracu {  get; init; }
        byte PocetKaretProHrace { get; init; }
        public Hra(byte pocetHracu, byte pocetKaretProHrace) 
        {
            PocetHracu = pocetHracu;
            PocetKaretProHrace = pocetKaretProHrace;
        }
        public int Hrat()
        {
            Balicek_karet balicek = new Balicek_karet();
            balicek.Zamichat();
            List<Hrac> hraci = new List<Hrac> { };
            for (int j = 0; j < PocetHracu; j++)
            {
                hraci.Add(new Hrac());
                for (int i = 0; i < PocetKaretProHrace; i++)
                {
                    hraci[j].Pridat_kartu(balicek.Liznout_si());
                }
            }
            int hrac_na_tahu = 0;
            balicek.Posledni_karta = balicek.Liznout_si();
            balicek.Pridat_kartu(balicek.Posledni_karta);
            bool sedmicka = false;
            bool eso = false;
            byte pocetSedmicek = 0;
            int cislo_tahu = 0;
            while (true)
            {
                cislo_tahu += 1;
                hrac_na_tahu++;
                hrac_na_tahu = hrac_na_tahu % PocetHracu;
                if (sedmicka)
                {
                    sedmicka = Tah_po_sedmicce(hraci[hrac_na_tahu], balicek, pocetSedmicek);
                    if (balicek.Posledni_karta.Hodnota == Hodnoty_karet.Král)
                    {
                        pocetSedmicek += 2;
                    }
                    else
                    {
                        pocetSedmicek++;
                    }
                }
                else
                {
                    if (eso)
                    {
                        eso = Tah_po_esu(balicek: balicek, hrac: hraci[hrac_na_tahu]) ;
                    }
                    else
                    {
                        if (Tah(balicek, hraci[hrac_na_tahu]))
                        {
                            if (balicek.Posledni_karta.Hodnota == Hodnoty_karet.Sedmička)
                            {
                                sedmicka = true;
                                pocetSedmicek = 1;
                            }
                            if (balicek.Posledni_karta.Hodnota == Hodnoty_karet.Eso)
                            {
                                eso = true;
                            }
                        }
                    }
                }

                if (hraci[hrac_na_tahu].Karty_hrace.Count <= 0) 
                {
                    return cislo_tahu / PocetHracu; 
                }
            }
        }

        public int HratLepe()
        {
            Balicek_karet balicek = new Balicek_karet();
            balicek.Zamichat();
            List<Hrac> hraci = new List<Hrac> { };
            for (int j = 0; j < PocetHracu; j++)
            {
                hraci.Add(new Hrac());
                for (int i = 0; i < PocetKaretProHrace; i++)
                {
                    hraci[j].Pridat_kartu(balicek.Liznout_si());
                }
            }
            int hrac_na_tahu = 0;
            balicek.Posledni_karta = balicek.Liznout_si();
            balicek.Pridat_kartu(balicek.Posledni_karta);
            bool sedmicka = false;
            bool eso = false;
            byte pocetSedmicek = 0;
            int cislo_tahu = 0;
            while (true)
            {
                cislo_tahu += 1;
                hrac_na_tahu++;
                hrac_na_tahu = hrac_na_tahu % PocetHracu;
                if (sedmicka)
                {
                    sedmicka = Tah_po_sedmicce(hraci[hrac_na_tahu], balicek, pocetSedmicek);
                    if (balicek.Posledni_karta.Hodnota == Hodnoty_karet.Král)
                    {
                        pocetSedmicek += 2;
                    }
                    else
                    {
                        pocetSedmicek++;
                    }
                }
                else
                {
                    if (eso)
                    {
                        eso = Tah_po_esu(balicek: balicek, hrac: hraci[hrac_na_tahu]);
                    }
                    else
                    {
                        if (LepsiTah(balicek, hraci[hrac_na_tahu]))
                        {
                            if (balicek.Posledni_karta.Hodnota == Hodnoty_karet.Sedmička)
                            {
                                sedmicka = true;
                                pocetSedmicek = 1;
                            }
                            if (balicek.Posledni_karta.Hodnota == Hodnoty_karet.Eso)
                            {
                                eso = true;
                            }
                        }
                    }
                }

                if (hraci[hrac_na_tahu].Karty_hrace.Count <= 0)
                {
                    return cislo_tahu / PocetHracu;
                }
            }
        }

        private bool Tah_po_esu(Hrac hrac, Balicek_karet balicek)
        {
            Karta zahrana_karta = hrac.Zahrat_kartu_po_esu();
            if (zahrana_karta != null)
            {
                balicek.Posledni_karta = zahrana_karta;
                balicek.Pridat_kartu(zahrana_karta);
                return true;
            }
            return false;
        }

        private bool Tah_po_sedmicce(Hrac hrac, Balicek_karet balicek, int pocet)
        {
            Karta zahrana_karta = hrac.Zahrat_kartu_po_sedmicce();
            if (zahrana_karta == null)
            {
                for (int i = 0; i < 2*pocet;i++)
                hrac.Pridat_kartu(balicek.Liznout_si());
                return false;
            }
            else
            {
                balicek.Posledni_karta = zahrana_karta;
                balicek.Pridat_kartu(zahrana_karta);
                return true;
            }
        }
        private bool Tah(Balicek_karet balicek, Hrac hrac)
        {
            Karta zahrana_karta = hrac.Zahrat_kartu(balicek.Posledni_karta);
            if (zahrana_karta == null)
            {
                hrac.Pridat_kartu(balicek.Liznout_si());
                return false;    
            }
            else
            {
                balicek.Posledni_karta = zahrana_karta;
                balicek.Pridat_kartu(zahrana_karta);
                return true;
            }
        }
        private bool LepsiTah(Balicek_karet balicek, Hrac hrac)
        {
            Karta zahrana_karta = hrac.Zahrat_lepsi_kartu(balicek.Posledni_karta);
            if (zahrana_karta == null)
            {
                hrac.Pridat_kartu(balicek.Liznout_si());
                return false;
            }
            else
            {
                balicek.Posledni_karta = zahrana_karta;
                balicek.Pridat_kartu(zahrana_karta);
                return true;
            }
        }
    }
}
