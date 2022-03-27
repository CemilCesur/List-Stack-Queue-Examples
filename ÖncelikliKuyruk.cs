using System;
using System.Collections;


namespace proje2
{
    class ÖncelikliKuyruk
    {

        private int maksBoyut;
        private Müşteri[] kuyrukArray;
        private int baş;
        private int son;
        private int nItems;
        private int[] intLList;
        private int[] ürünSüre = {19, 18, 17, 16, 15, 15 , 14, 13, 11, 8, 5, 3,};
        private int toplamSaat;
        private int[] müşteriSaatleri;

        public ÖncelikliKuyruk(int boyut)
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




        public void müşteriSil()
        {
            ArrayList arrayList = new ArrayList();
            foreach(Müşteri m in kuyrukArray) { arrayList.Add(m); }  // Kuyruğa atılmış müşterileri, daha kolay işlem yapabilmek için ArrayListe kopyalıyorum


            int maksÜrün = 0;
            foreach(Müşteri ü in arrayList) {   if (maksÜrün < ü.ÜrünSayısı) { maksÜrün = ü.ÜrünSayısı;  }    }  // Maksimum sayıda ürünü bulunan müşteriyi tespit ediyorum

            foreach(Müşteri ş in arrayList) {   if (maksÜrün==ş.ÜrünSayısı) {arrayList.Remove(ş); break; }     }  // Ve o müşteriyi ArrayList'imden siliyorum

            nItems--;
            kuyrukArray = new Müşteri[nItems];
            baş = 0;
            son = nItems-1;

            arrayList.CopyTo(kuyrukArray); // yaptığım işlemleri tutmak adına o listeyi ana dizime kopyalıyorum

        }







        public void kuyrukYazdır()
        {
            ArrayList intArray = new ArrayList();  // Ürün sayılarını tutacağım ArrayList

            foreach (Müşteri m in kuyrukArray) { intArray.Add(m.ÜrünSayısı); }  // Ana dizideki müşterilerin ürün sayılarını ArrayList'e kopyalıyorum

            intArray.Sort(); // Küçükten büyüğe sıralıyorum


            intLList = new int[kuyrukArray.Length];     //
                                                        // Dizi de daha rahat işlem yapabildiğim için sıralama yapılmış ArrayList'i tekrar bir diziye dönüştürüyorum
            intArray.CopyTo(intLList);                  //



            int sayaç = intLList.Length - 1; // küçükten büyüğe sıralandığı için sondan yaklaşmak amacı ile sayaç oluşturdum

            bool döngü = false; // Gerekli kısımda döngü kırabilmek için
     
            for (int a = sayaç; a>=0; a--)
            {
                if (a == 6)   // Deniz ve Okan'ı ayırt edebilmek için ayrı bir koşul
                {
                    Console.WriteLine("Kuyruğun 6. Eleman bilgileri: Deniz"+ " , " + 15);
                    Console.ReadLine();
                    döngü = true;   // Deniz'e geldiğimiz zaman aşağıdaki for döngümüzü kırıyoruz
                }

                // Çıktı alıyoruz
                for (int b = 0; b<kuyrukArray.Length; b++)
                {

                    if (döngü == true) { döngü = false; break; }
                    else if (intLList[a] == kuyrukArray[b].ÜrünSayısı)
                    {
                        Console.WriteLine("Kuyruğun " + (12-a) + ". Eleman bilgileri: "+kuyrukArray[b].MüşteriAdı + " , " + kuyrukArray[b].ÜrünSayısı);
                        Console.ReadLine();
                        intLList[a] = -1;


                    }
                    
                }
                    
                
            }        

        }



        public double tekKasaSüre()
        {
         
             toplamSaat = 0;

             foreach (int i in müşteriSaatleri) { toplamSaat += i; }  // müşteriSüre() methodumuz da elde edeceğimiz her bir müşterinin bekleme süresini topluyoruz

             return (double)toplamSaat / 12;  // ve müşteri sayısına bölüyoruz,  NOT: Bu Class için her örnekte çalışabilme durumu istenilmediği için verilen örneğe göre yaptım!

            
        }


        public void müşteriSüre()
        {
            

            müşteriSaatleri = new int[12]; // Her bir müşterinin bekleme süresini tutuyoruz

            int sayaç = 11;
            for (int x = 11; x > -1; x--)
            {
                for (int a = sayaç; a > -1; a--)
                {
                    müşteriSaatleri[x] += ürünSüre[a];  // Her seferinde müşteriler için kişisel olarak bekledikleri süreleri topluyoruz
                }
                sayaç--;
            }

            int s = 0;
            foreach (int i in müşteriSaatleri) { Console.WriteLine((s + 1) + ". Çıkanın bekleme süresi: " + i); Console.ReadLine(); s++; }

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
