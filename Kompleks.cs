using System;

namespace Kompleks
{
    class Kompleks
    {
        private double mGercek;
        private double mSanal;
        public double Gercek
        {
            get { return mGercek; }
            set { mGercek = value; }
        }
        public double Sanal
        {
            get { return mSanal; }
            set { mSanal = value; }
        }
        public Kompleks(double a, double b)
        {
            mGercek = a;
            mSanal = b;
        }
        public Kompleks()
        {
            mGercek = 0;
            mSanal = 0;
        }
        public Kompleks(Kompleks a)
        {
            mGercek = a.mGercek;
            mSanal = a.mSanal;
        }
        public void Yazdir()
        {
            if (mSanal > 0)
                Console.WriteLine("{0} + i{1}", mGercek, mSanal);
            else
                Console.WriteLine("{0} - i{1}", mGercek, -mSanal);
        }

        // Kompleks sayılarda toplana işlemi
        public static Kompleks operator +(Kompleks a, Kompleks b)
        {
            double GercekToplam = a.Gercek + b.Gercek;
            double SanalToplam = a.Sanal + b.Sanal;
            return new Kompleks(GercekToplam, SanalToplam);
        }
        public static Kompleks operator +(Kompleks a, double b)
        {
            double GercekToplam = a.Gercek + b;
            return new Kompleks(GercekToplam, a.Sanal);
        }
        public static Kompleks operator +(double b, Kompleks a)
        {
            double GercekToplam = a.Gercek + b;
            return new Kompleks(GercekToplam, a.Sanal);
        }
        // kompleks sayilarda çıkarma işlemi
        public static Kompleks operator -(Kompleks a, Kompleks b)
        {
            double GercekFark = a.Gercek - b.Gercek;
            double SanalFark = a.Sanal - b.Sanal;
            return new Kompleks(GercekFark, SanalFark);
        }
        // kompleks sayilarda çıkarma işlemi
        public static Kompleks operator -(Kompleks a, double b)
        {
            double GercekFark = a.Gercek - b;
            return new Kompleks(GercekFark, a.Sanal);
        }
        // kompleks sayilarda çıkarma işlemi
        public static Kompleks operator -(double b, Kompleks a)
        {
            double GercekFark = a.Gercek - b;
            return new Kompleks(GercekFark, a.Sanal);
        }

        // Kompleks sayılarda çarpma işlemi
        public static Kompleks operator *(Kompleks a, Kompleks b)
        {
            double Gercek1 = a.Gercek * b.Gercek;
            double Gercek2 = a.Sanal * b.Sanal;
            double GercekCarpim = Gercek1 - Gercek2;

            double Sanal1 = a.Gercek * b.Sanal;
            double Sanal2 = b.Gercek * a.Sanal;
            double SanalCarpim = Sanal1 + Sanal2;

            return new Kompleks(GercekCarpim, SanalCarpim);
        }
        // Kompleks sayılarda bölme işlemi
        public static Kompleks operator /(Kompleks a, Kompleks b)
        {
            Kompleks bEslenik = new Kompleks(b.Gercek, -b.Sanal);
            Kompleks pay = a * bEslenik;
            double payda = b.Gercek * b.Gercek + b.Sanal * b.Sanal;
            double GercekBolum = pay.Gercek / payda;
            double SanalBolum = pay.Sanal / payda;
            return new Kompleks(GercekBolum, SanalBolum);
        }
        // ilişkisel operatörlerin aşırı yüklenmesi (==) ve (!=)
        public static bool operator ==(Kompleks a, Kompleks b)
        {
            if (a.Gercek == b.Gercek && a.Sanal == b.Sanal)
                return true;
            else
                return false;
        }
        public static bool operator !=(Kompleks a, Kompleks b)
        {
            return !(a == b);
        }
        // True ve False değerlerinin yüklenmesi
        public static bool operator true(Kompleks a)
        {
            if (a.Gercek != 0 || a.Sanal != 0)
                return true;
            else
                return false;
        }
        public static bool operator false(Kompleks a)
        {
            if (a.Gercek == 0 && a.Sanal == 0)
                return true;
            else
                return false;

        }
        public static Kompleks operator &(Kompleks a, Kompleks b)
        {
            if ((a.Gercek == 0 && a.Sanal == 0) | (b.Gercek == 0 && b.Sanal == 0))
            {
                return new Kompleks(0, 0);
            }
            else
            {
                return new Kompleks(1, 1);
            }
        }
        public static Kompleks operator |(Kompleks a, Kompleks b)
        {
            if ((a.Gercek != 0 && a.Sanal != 0) | (b.Gercek != 0 && b.Sanal != 0))
            {
                return new Kompleks(1, 1);
            }
            else
            {
                return new Kompleks(0, 0);
            }
        }
        /// Dönüşüm operatörlerine aşırı yüklenme
        public static implicit operator double(Kompleks a)
        {
            return a.Gercek;
        }




    }
    class OperatorYukleme
    {
        static void Main()
        {
            Kompleks a = new Kompleks(-5, 9);
            Kompleks b = new Kompleks(-5, 9);
            Kompleks c = a + b;
            Kompleks d = a + 5; // aşağıda ki örnekle arasındaki fark parametrelerin yeri değişmesi
            Kompleks e = 5 + a; // yapıcı metotda parametrelerin yerini değiştirmek gerek
            Kompleks f = 5 + b;
            Kompleks g = a - b;
            Kompleks j = a - 3;
            Kompleks i = 3 - a;
            Kompleks k = a * b;
            Kompleks h = a / b;
            bool tf = a == b;
            bool tf1 = c != b;

            c.Yazdir();
            d.Yazdir();
            e.Yazdir();
            f.Yazdir();
            g.Yazdir();
            j.Yazdir();
            i.Yazdir();
            k.Yazdir();
            h.Yazdir();
            // İlişkisel oper. aşırı yüklenmesi
            Console.WriteLine(tf);
            Console.WriteLine(tf1);
            // True ve False oper. aşırı yüklenmesi
            if (a)
            {
                Console.WriteLine("a değeri true");
            }
            else
            {
                Console.WriteLine("a değeri false");
            }
            Kompleks komleks = new Kompleks(5, -1);
            double doub = komleks;
            Console.WriteLine(doub);

        }
    }
}
