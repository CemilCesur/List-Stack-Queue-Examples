

namespace proje2
{
    class Yığıt
    {
        private int maksBoyut; 
        private Müşteri[] yığıtArray;
        private int üst; 
       
        
        
        public Yığıt(int boyut) 
        {
            maksBoyut = boyut;
            yığıtArray = new Müşteri[maksBoyut];
            üst = -1;
        }



        public void üsteEkle(Müşteri j) 
        {
            yığıtArray[++üst] = j; 
        }


        public Müşteri üsttenÇıkarDöndür()
        {
            return yığıtArray[üst--]; 
        }



        public Müşteri üsttenDöndür()
        {
            return yığıtArray[üst];
        }



        public bool yığıtBoşMu() 
        {
            if (üst == -1) { return true; }
            else { return false; }


        }



        public bool yığıtDoluMu() 
        {
            if (üst == maksBoyut - 1) { return true; }
            else { return false; }
        }



    }
}
