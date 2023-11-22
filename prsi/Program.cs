namespace prsi
{
    class Program
    {
        static void Main()
        {
            Hra hra = new Hra(pocetHracu: 4, pocetKaretProHrace: 4);
            Hra hra_s_vice_hraci = new Hra(pocetHracu: 6, pocetKaretProHrace: 4);
            Hra hra_s_vice_kartami = new Hra(pocetHracu: 4, pocetKaretProHrace: 6);
            int pocet_opakovani = 100000;
            Console.WriteLine("\nPrůměrná délka hry s normálním počtem hráčů:");
            double prumer_kol = 0;
            for (int i = 0; i < pocet_opakovani; i++)
                prumer_kol += ((double)hra.Hrat() / (double)pocet_opakovani);
            Console.WriteLine("  " + Math.Round(prumer_kol, 3));
            prumer_kol = 0;
            Console.WriteLine("\nPrůměrná délka hry s normálním počtem hráčů, kteří taktizují:");
            for (int i = 0; i < pocet_opakovani; i++)
                prumer_kol += ((double)hra.HratLepe() / (double)pocet_opakovani);
            Console.WriteLine("  " + Math.Round(prumer_kol, 3));
            prumer_kol = 0;
            Console.WriteLine("\nPrůměrná délka hry s vyšším počtem hráčů:");
            for (int i = 0; i < pocet_opakovani; i++)
                prumer_kol += ((double)hra_s_vice_hraci.Hrat() / (double)pocet_opakovani);
            Console.WriteLine("  " + Math.Round(prumer_kol, 3));
            prumer_kol = 0;
            Console.WriteLine("\nPrůměrná délka hry s vyšším počtem hráčů, kteří taktizují:");
            for (int i = 0; i < pocet_opakovani; i++)
                prumer_kol += ((double)hra_s_vice_hraci.HratLepe() / (double)pocet_opakovani);
            Console.WriteLine("  " + Math.Round(prumer_kol, 3));
            prumer_kol = 0;
            Console.WriteLine("\nPrůměrná délka hry s vyšším počtem karet:");
            for (int i = 0; i < pocet_opakovani; i++)
                prumer_kol += ((double)hra_s_vice_kartami.Hrat() / (double)pocet_opakovani);
            Console.WriteLine("  " + Math.Round(prumer_kol, 3));
            prumer_kol = 0;
            Console.WriteLine("\nPrůměrná délka hry s vyšším počtem karet, hráči taktizují:");
            for (int i = 0; i < pocet_opakovani; i++)
                prumer_kol += ((double)hra_s_vice_kartami.HratLepe() / (double)pocet_opakovani);
            Console.WriteLine("  "+Math.Round(prumer_kol, 3));
        }
    }
}