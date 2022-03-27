using System;
using System.Collections;
using System.Collections.Generic;


namespace proje2
{
    class Program
    {


        static void Main(string[] args)
        {

            String[] müşteriAdListesi = { "Ali", "Merve", "Veli", "Gülay", "Okan", "Zekiye", "Kemal", "Banu", "İlker", "Songül", "Nuri", "Deniz" };
            int[] ürünSayıListesi = { 8, 11, 16, 5, 15, 14, 19, 3, 18, 17, 13, 15 };


            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;

            bileşikListe(müşteriAdListesi, ürünSayıListesi);


            yığıtStack(müşteriAdListesi, ürünSayıListesi);


            kuyrukQueue(müşteriAdListesi, ürünSayıListesi);


            öncelikliKuyruk(müşteriAdListesi, ürünSayıListesi);

            Console.WriteLine("\n--------------------------------------------------------------------------");
            Console.WriteLine("                                  KISIM IV                                 ");
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.ReadLine();
            öncelikliKuyrukSüreler(müşteriAdListesi, ürünSayıListesi);

        }










        public static void bileşikListe(String[] strList, int[] intList)
        {
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("                                  KISIM I                                 ");
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.ReadLine();

            Müşteri[] müşteriListesi = new Müşteri[strList.Length]; // Müşterileri tutacağım dizi

            for (int i = 0; i < strList.Length; i++) // Müşterileri for döngüsü ile oluşturuyorum
            {
                Müşteri müşteri = new Müşteri(strList[i], intList[i]);
                müşteriListesi[i] = müşteri;
            }


            ArrayList arrayList = new ArrayList(); // ArrayList'i oluşturdum
            int sayaç = 0; // Döngü kırma koşuluna yardımcı olacak
            Random random = new Random();
            bool bitti = false; // Döngü kıracak

            while (true)
            {
                int kapasite = random.Next(1, 6);


                List<Müşteri> genericList = new List<Müşteri>(kapasite); // Gelen kapasiteye göre oluşturulan Generic List
                int sayaç3 = sayaç;
                for (int i = sayaç; i < kapasite + sayaç3; i++) // tekrar for döngüsü açmamak için müşteri ekleme ve çıktımı bu for da alıyorum (Ödev içeriğinde şart koyulmamış!)
                {
                    genericList.Add(müşteriListesi[i]);
                    Console.WriteLine((i + 1) + ".Müşteri: " + müşteriListesi[i].MüşteriAdı);
                    Console.ReadLine();
                    Console.WriteLine(müşteriListesi[i].MüşteriAdı + " müşterisinin ürün sayısı: " + müşteriListesi[i].ÜrünSayısı);
                    Console.ReadLine();
                    Console.WriteLine("--------------------------------------------------------------------------");
                    Console.ReadLine();

                    if (sayaç >= müşteriListesi.Length - 1) { bitti = true; break; }

                    sayaç++;
                }

                arrayList.Add(genericList);  // ArrayList'e oluşan GenericList'i atıyorum

                if (bitti == true) { break; }

            }

            // Gerekli istatistiklerin çıktıları ve işlemleri
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.ReadLine();
            Console.WriteLine("Dinamik Dizideki Eleman(Liste) Sayısı: " + arrayList.Count);
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.ReadLine();
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.ReadLine();
            Console.WriteLine("Listelerdeki Ortalama Eleman(Müşteri) Sayısı: " + ((double)müşteriListesi.Length / arrayList.Count));
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.ReadLine();

            Console.WriteLine("\n");
            Console.ReadLine();

        }



        public static void yığıtStack(String[] strList, int[] intList)
        {

            // Aynı şekilde Müşterileri oluşturduğum ve dizime koyduğum kısım
            Müşteri[] müşteriListesi = new Müşteri[strList.Length];

            for (int d = 0; d < strList.Length; d++)
            {
                Müşteri müşteri = new Müşteri(strList[d], intList[d]);
                müşteriListesi[d] = müşteri;
            }


            Yığıt yığıt = new Yığıt(müşteriListesi.Length); // yığıt nesnem

            // Müşteri ekleme
            int i = 0;
            while (!yığıt.yığıtDoluMu())
            {
                yığıt.üsteEkle(müşteriListesi[i]);
                i++;
            }

            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("                             KISIM II - A                                 ");
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.ReadLine();

            // Müşteri çıkarıp - yazdırma
            int j = 1;
            while (!yığıt.yığıtBoşMu())
            {
                Müşteri obj = yığıt.üsttenÇıkarDöndür();

                Console.WriteLine("Yığıtın " + j + ". Eleman bilgileri: " + obj.MüşteriAdı + " , " + obj.ÜrünSayısı);
                Console.ReadLine();
                j++;
            }


            Console.WriteLine("\n");
            Console.ReadLine();
        }



        public static void kuyrukQueue(String[] strList, int[] intList)
        {

            // Aynı şekilde Müşterileri oluşturduğum ve dizime koyduğum kısım
            Müşteri[] müşteriListesi = new Müşteri[strList.Length];

            for (int d = 0; d < strList.Length; d++)
            {
                Müşteri müşteri = new Müşteri(strList[d], intList[d]);
                müşteriListesi[d] = müşteri;
            }


            Kuyruk kuyruk = new Kuyruk(müşteriListesi.Length); // kuyruk nesnem

            // Müşteri ekleme
            int i = 0;
            while (!kuyruk.kuyrukDoluMu())
            {
                kuyruk.müşteriEkle(müşteriListesi[i]);
                i++;
            }

            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("                             KISIM II - B                                 ");
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.ReadLine();
            Console.WriteLine("--------------------------------------------------------------------------");


            //Müşteri çıkarma - yazdırma
            int j = 1;
            while (!kuyruk.kuyrukBoşMu())
            {
                Müşteri obj = kuyruk.müşteriSilDöndür();

                Console.WriteLine("Kuyruğun " + j + ". Eleman bilgileri: " + obj.MüşteriAdı + " , " + obj.ÜrünSayısı);
                Console.ReadLine();
                j++;
            }

            Console.WriteLine("\n--------------------------------------------------------------------------");
            Console.WriteLine("\n");


            //Bekleme sürelerini ve ortalama bekleme süresini elde ettiğim kısım
            kuyruk.müşteriBekleme();
            Console.WriteLine("\n__________________________________________________\n" +
                                "ORTALAMA BEKLEME SÜRESİ: " + kuyruk.ortalamaBekleme());
            Console.WriteLine("\n");
            Console.ReadLine();

            


            Console.WriteLine("\n");
            Console.ReadLine();


        }



        public static void öncelikliKuyruk(String[] strList, int[] intList)
        {

            // Aynı şekilde Müşterileri oluşturduğum ve dizime koyduğum kısım
            Müşteri[] müşteriListesi = new Müşteri[strList.Length];

            for (int d = 0; d < strList.Length; d++)
            {
                Müşteri müşteri = new Müşteri(strList[d], intList[d]);
                müşteriListesi[d] = müşteri;
            }


            ÖncelikliKuyruk kuyruk = new ÖncelikliKuyruk(müşteriListesi.Length); // Öncelikli kuyruk nesnem


            // Müşteri ekliyoruz
            int i = 0;
            while (!kuyruk.kuyrukDoluMu())
            {
                kuyruk.müşteriEkle(müşteriListesi[i]);
                i++;
            }


            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("                              KISIM III                                   ");
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.ReadLine();


            // Kuyruk yazdırıyoruz
            kuyruk.kuyrukYazdır();

            for (int x = 0; x < 11; x++)
            {
                Console.WriteLine("----------------------------\n" +
                                  "Kuyruktan müşteri çıkarıldı!\n" +
                                  "----------------------------");
                Console.ReadLine();
                kuyruk.müşteriSil();

                kuyruk.kuyrukYazdır();
            }

            // Kuyrukta ki elemanların bittiğini gösteren kısım
            Console.WriteLine("----------------------------\n" +
                              "Kuyruktan müşteri çıkarıldı!\n" +
                              "----------------------------");
            Console.WriteLine("KUYRUKTA ELEMAN KALMADI!");
            Console.ReadLine();


        }


       



        public static void öncelikliKuyrukSüreler(String[] strList, int[] intList)
        {

            // Aynı şekilde Müşterileri oluşturduğum ve dizime koyduğum kısım
            Müşteri[] müşteriListesi = new Müşteri[strList.Length];

            for (int d = 0; d < strList.Length; d++)
            {
                Müşteri müşteri = new Müşteri(strList[d], intList[d]);
                müşteriListesi[d] = müşteri;
            }

            // Nesnelerimizi oluşturuyoruz
            ÖncelikliKuyruk kuyrukAzalan = new ÖncelikliKuyruk(müşteriListesi.Length);
            ÖncelikliKuyrukArtan kuyrukArtan = new ÖncelikliKuyrukArtan(müşteriListesi.Length);

            


            // NOT: Hem Azalanı hem de Artanın farkını da görmek istedim bu yüzden bu şekilde yaptım, saygılarımla
            //
            // Süre hesaplama methotlarının bulunduğu ve düzenli çıktı olarak verildiği kısım 
            Console.WriteLine("\nArtan Öncelikli Kuyruk Müşteri Süreleri\n" +
                              "________________________________________");
            Console.ReadLine();
            kuyrukArtan.müşteriSüre();
            Console.WriteLine("\n--------------------------------------------------------------------------");
            Console.WriteLine("\nArtan Öncelikli Kuyruk Ortalama Süre: " + kuyrukArtan.tekKasaSüre() + "\n");
            Console.WriteLine("--------------------------------------------------------------------------");

            Console.WriteLine("\nAzalan Öncelikli Kuyruk Müşteri Süreleri\n" +
                              "________________________________________");
            Console.ReadLine();
            kuyrukAzalan.müşteriSüre();
            Console.WriteLine("\n--------------------------------------------------------------------------");
            Console.WriteLine("\nAzalan Öncelikli Kuyruk Ortalama Süre: " + kuyrukAzalan.tekKasaSüre() + "\n");
            Console.WriteLine("--------------------------------------------------------------------------");


            Console.WriteLine("\n\nProgram Sonlandırıldı\n");
            Console.ReadLine();

        }






    }
}
