using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prsi
{
    internal class Balicek_karet
    {
        public Queue<Karta> Karty {  get; set; }
        public Karta? Posledni_karta { get; set; }
        public Balicek_karet()
        {
            Karty = new Queue<Karta>();
            foreach (Barvy_karet barva in Enum.GetValues(typeof(Barvy_karet)))
            {
                foreach (Hodnoty_karet hodnota in Enum.GetValues(typeof(Hodnoty_karet)))
                {
                    Karty.Enqueue(new Karta (hodnota: hodnota, barva: barva));
                }
            }
            Posledni_karta = null;
        }
        public void Zamichat()
        {
            Random random = new Random();
            List<Karta> seznam_karet = Karty.ToList();
            seznam_karet = seznam_karet.OrderBy(Karta => random.Next()).ToList();
            foreach(Karta karta in seznam_karet)
            {
                Karty.Dequeue();
                Karty.Enqueue(karta);
            }
        }
        public override string ToString()
        {
            string vypis = "";
            foreach (Karta karta in Karty)
            {
                vypis += karta.Barva.ToString() + " " + karta.Hodnota.ToString() + "\n";
            }
            return vypis;
        }
        
        public Karta Liznout_si()
        {
            if (Karty.Count > 0)
                return Karty.Dequeue();
            else
                return null;
        }

        public void Pridat_kartu(Karta karta)
        {
            Karty.Enqueue(karta);
        }
    }
}
