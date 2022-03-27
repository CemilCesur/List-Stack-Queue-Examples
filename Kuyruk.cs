

using System;
using System.Collections;

namespace proje2
{
    class Kuyruk
    {

        private int maksBoyut;
        private Müşteri[] kuyrukArray;
        private int baş;
        private int son;
        private int nItems;
        private ArrayList beklemeSaati = new ArrayList();
        private double toplamSaat;
        int[] müşteriSaatleri;

        public Kuyruk(int boyut)
        {
            maksBoyut = boyut;
            kuyrukArray = new Müşteri[maksBoyut];
            baş = 0;
            son = -1;
            nItems = 0;
        }



        public void müşteriEkle(Müşteri müşteri) 
        {
            if (son == maksBoyut - 1)
                son = -1;
            kuyrukArray[++son] = müşteri; 
            nItems++; 
        }




        public Müşteri müşteriSilDöndür() 
        {
            beklemeSaati.Add(kuyrukArray[baş].ÜrünSayısı); // Bekleme sürelerini hesaplamak için müşterileri silerken elde ettiğimiz ArrayList
            Müşteri temp = kuyrukArray[baş++];
            if (baş == maksBoyut)
                baş = 0;
            nItems--; 
            return temp;
        }



        public double ortalamaBekleme()
        {
            toplamSaat = 0;

            foreach (int i in müşteriSaatleri) { toplamSaat += (double)i; } // müşteriBekleme() methodunda oluşturulan, her müşterinin beklediği saatleri içeren Array

            return toplamSaat/12;
        }


        public void müşteriBekleme()
        {
            int[] saatler = new int[12];
            beklemeSaati.CopyTo(saatler); // Bekleme saatlerini, daha kolay işlem yapabildiğim için Array'e atıyorum

            müşteriSaatleri = new int[12]; // Her bir müşterinin bekleyeceği saati tutuyor

            int sayaç = 11; // tersten gelebilmek için sayaç tanımladım
            for (int x = 11; x > -1; x--)
            {
                for (int a = sayaç; a > -1; a--)
                {
                    müşteriSaatleri[x] += saatler[a];
                }
                sayaç--; // Müşteri ile işim bittiğinde onun dışında kalan müşteriler ile işlem yapıyorum
            }

            int s = 0;
            foreach (int i in müşteriSaatleri) { Console.WriteLine( (s+1) + ". Eleman bekleme süresi: "+i ); Console.ReadLine(); s++; }
            
        }



        public Müşteri kuyrukBaşı()
        {
        return kuyrukArray[baş];
        }




        public bool kuyrukBoşMu()
        {
            return (nItems == 0);
        }




        public bool kuyrukDoluMu() 
        {
            return (nItems == maksBoyut);
        }




        public int kuyrukBoyutu()
        {
            return nItems;
        }




    }
}
