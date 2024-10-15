using System;
using System.Collections.Generic;

namespace KutuphaneYonetimSistemi
{
    class Kitap
    {
        public string KitapAdi { get; set; }
        public string YazarAdi { get; set; }
        public string ISBN { get; set; }
        public int YayinYili { get; set; }

        public Kitap(string kitapAdi, string yazarAdi, string isbn, int yayinYili)
        {
            KitapAdi = kitapAdi;
            YazarAdi = yazarAdi;
            ISBN = isbn;
            YayinYili = yayinYili;
        }

        public override string ToString()
        {
            return $"Kitap Adı: {KitapAdi}, Yazar: {YazarAdi}, ISBN: {ISBN}, Yayın Yılı: {YayinYili}";
        }
    }

    class Kutuphane
    {
        private List<Kitap> kitaplar = new List<Kitap>();

        public void KitapEkle(Kitap yeniKitap)
        {
            kitaplar.Add(yeniKitap);
            Console.WriteLine("Kitap başarıyla eklendi!");
        }

        public void KitaplariListele()
        {
            if (kitaplar.Count == 0)
            {
                Console.WriteLine("Kütüphanede kitap yok.");
                return;
            }

            foreach (var kitap in kitaplar)
            {
                Console.WriteLine(kitap.ToString());
            }
        }

        public void KitapAra(string kitapAdi)
        {
            var bulunanKitaplar = kitaplar.FindAll(k => k.KitapAdi.ToLower().Contains(kitapAdi.ToLower()));

            if (bulunanKitaplar.Count == 0)
            {
                Console.WriteLine("Kitap bulunamadı.");
                return;
            }

            foreach (var kitap in bulunanKitaplar)
            {
                Console.WriteLine(kitap.ToString());
            }
        }

        public void KitapSil(string isbn)
        {
            Kitap silinecekKitap = kitaplar.Find(k => k.ISBN == isbn);

            if (silinecekKitap != null)
            {
                kitaplar.Remove(silinecekKitap);
                Console.WriteLine("Kitap başarıyla silindi.");
            }
            else
            {
                Console.WriteLine("Kitap bulunamadı.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Kutuphane kutuphane = new Kutuphane();
            bool cikis = false;

            while (!cikis)
            {
                Console.WriteLine("\n--- Kütüphane Yönetim Sistemi ---");
                Console.WriteLine("1. Kitap Ekle");
                Console.WriteLine("2. Kitapları Listele");
                Console.WriteLine("3. Kitap Ara");
                Console.WriteLine("4. Kitap Sil");
                Console.WriteLine("5. Çıkış");
                Console.Write("Seçiminizi yapın: ");
                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        Console.Write("Kitap Adı: ");
                        string kitapAdi = Console.ReadLine();
                        Console.Write("Yazar Adı: ");
                        string yazarAdi = Console.ReadLine();
                        Console.Write("ISBN: ");
                        string isbn = Console.ReadLine();
                        Console.Write("Yayın Yılı: ");
                        int yayinYili = int.Parse(Console.ReadLine());

                        Kitap yeniKitap = new Kitap(kitapAdi, yazarAdi, isbn, yayinYili);
                        kutuphane.KitapEkle(yeniKitap);
                        break;

                    case "2":
                        kutuphane.KitaplariListele();
                        break;

                    case "3":
                        Console.Write("Aramak istediğiniz kitap adını girin: ");
                        string aranacakKitap = Console.ReadLine();
                        kutuphane.KitapAra(aranacakKitap);
                        break;

                    case "4":
                        Console.Write("Silmek istediğiniz kitabın ISBN numarasını girin: ");
                        string silinecekIsbn = Console.ReadLine();
                        kutuphane.KitapSil(silinecekIsbn);
                        break;

                    case "5":
                        cikis = true;
                        Console.WriteLine("Çıkış yapılıyor...");
                        break;

                    default:
                        Console.WriteLine("Geçersiz seçim! Lütfen tekrar deneyin.");
                        break;
                }
            }
        }
    }
}
