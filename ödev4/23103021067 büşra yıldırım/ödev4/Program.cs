using System;
using System.Collections.Generic;
using System.Linq;

namespace FilmAkisPlatformu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Kullanici kullanici = new Kullanici();

            while (true)
            {
                Console.WriteLine(" Film Akış Platformu");
                Console.WriteLine("1  İzleme Listesini Görüntüle");
                Console.WriteLine("2  Film Ekle");
                Console.WriteLine("3  Film Sil");
                Console.WriteLine("4 Listeyi Karıştır");
                Console.WriteLine("5  Listeyi Sırala");
                Console.WriteLine("6  Çıkış");
                Console.Write("Seçiminizi giriniz: ");

                int secim;
                if (!int.TryParse(Console.ReadLine(), out secim))
                {
                    Console.WriteLine("Hatalı giriş! Lütfen sayı giriniz.\n");
                    continue;
                }

                if (secim == 6)
                {
                    Console.WriteLine("Program sonlandırılıyor...");
                    break;
                }

                switch (secim)
                {
                    case 1:
                        kullanici.IzlemeListesiniGoster();
                        break;
                    case 2:
                        kullanici.FilmEkle();
                        break;
                    case 3:
                        kullanici.FilmSil();
                        break;
                    case 4:
                        kullanici.ListeyiKaristir();
                        break;
                    case 5:
                        kullanici.ListeyiSirala();
                        break;
                    default:
                        Console.WriteLine("Lütfen 1-6 arasında bir seçim yapınız.");
                        break;
                }

                Console.WriteLine("\nDevam etmek için Enter’a basın...");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }

    // ===== ÜST SINIF =====
    public class Film
    {
        public string Ad { get; set; }
        public string Yonetmen { get; set; }
        public int Sure { get; set; }
        public int YasSiniri { get; set; }
        public int Puan { get; set; }
        public string Tur { get; set; }
        public float Fiyat { get; set; }

        public Film(string ad, string yonetmen, int sure, int yas, int puan, string tur)
        {
            Ad = ad;
            Yonetmen = yonetmen;
            Sure = sure;
            YasSiniri = yas;
            Puan = puan;
            Tur = tur;
        }
    }

    // ===== ALT SINIFLAR =====

    public class Aksiyon : Film
    {
        public string Dublor { get; set; }
        public Aksiyon(string ad, string yonetmen, int sure, int yas, int puan, string tur, string dublor)
            : base(ad, yonetmen, sure, yas, puan, tur)
        {
            if (sure < 90)
                throw new ArgumentException("Aksiyon filmleri 90 dakikadan kısa olamaz!");
            if (string.IsNullOrWhiteSpace(dublor))
                throw new ArgumentException("Dublör bilgisi girilmelidir!");

            Fiyat = 2.0f;
            Dublor = dublor;
        }
    }

    public class Komedi : Film
    {
        public float MizahYogunlugu { get; set; }
        public Komedi(string ad, string yonetmen, int sure, int yas, int puan, string tur, float mizah)
            : base(ad, yonetmen, sure, yas, puan, tur)
        {
            if (sure > 120)
                throw new ArgumentException("Komedi filmleri 120 dakikadan uzun olamaz!");
            if (mizah < 1 || mizah > 5)
                throw new ArgumentException("Mizah yoğunluğu 1 ile 5 arasında olmalıdır!");

            Fiyat = 1.2f;
            MizahYogunlugu = mizah;
        }
    }

    public class Drama : Film
    {
        public Drama(string ad, string yonetmen, int sure, int yas, int puan, string tur)
            : base(ad, yonetmen, sure, yas, puan, tur)
        {
            if (sure < 90)
                throw new ArgumentException("Drama filmleri 90 dakikadan kısa olamaz!");
            if (yas < 13)
                throw new ArgumentException("Drama filmleri için yaş sınırı en az 13 olmalıdır!");

            Fiyat = 1.8f;
        }
    }

    public class Belgesel : Film
    {
        public string Anlatici { get; set; }
        public Belgesel(string ad, string yonetmen, int sure, int yas, int puan, string tur, string anlatici)
            : base(ad, yonetmen, sure, yas, puan, tur)
        {
            if (sure < 45 || sure > 180)
                throw new ArgumentException("Belgesel süresi 45–180 dakika arasında olmalıdır!");
            if (string.IsNullOrWhiteSpace(anlatici))
                throw new ArgumentException("Anlatıcı bilgisi boş olamaz!");

            Fiyat = 1.5f;
            Anlatici = anlatici;
        }
    }

    // ===== KULLANICI SINIFI =====
    public class Kullanici
    {
        private List<Film> izlemeListesi = new List<Film>();
        private float toplamMaliyet = 0;

        public void FilmEkle()
        {
            try
            {
                Console.Write("Film Adı: ");
                string ad = Console.ReadLine();
                Console.Write("Yönetmen: ");
                string yonetmen = Console.ReadLine();
                Console.Write("Süre (dk): ");
                int sure = Convert.ToInt32(Console.ReadLine());
                Console.Write("Yaş Sınırı: ");
                int yas = Convert.ToInt32(Console.ReadLine());
                Console.Write("Puan (1-10): ");
                int puan = Convert.ToInt32(Console.ReadLine());
                Console.Write("Tür (Aksiyon / Komedi / Drama / Belgesel): ");
                string tur = Console.ReadLine().ToLower();

                Film yeniFilm = null;

                if (tur == "aksiyon")
                {
                    Console.Write("Dublör bilgisi: ");
                    string dublor = Console.ReadLine();
                    yeniFilm = new Aksiyon(ad, yonetmen, sure, yas, puan, tur, dublor);
                }
                else if (tur == "komedi")
                {
                    Console.Write("Mizah yoğunluğu (1–5): ");
                    float mizah = Convert.ToSingle(Console.ReadLine());
                    yeniFilm = new Komedi(ad, yonetmen, sure, yas, puan, tur, mizah);
                }
                else if (tur == "drama")
                {
                    yeniFilm = new Drama(ad, yonetmen, sure, yas, puan, tur);
                }
                else if (tur == "belgesel")
                {
                    Console.Write("Anlatıcı adı: ");
                    string anlatici = Console.ReadLine();
                    yeniFilm = new Belgesel(ad, yonetmen, sure, yas, puan, tur, anlatici);
                }
                else
                {
                    Console.WriteLine("Geçersiz tür girişi!");
                    return;
                }

                izlemeListesi.Add(yeniFilm);
                toplamMaliyet += yeniFilm.Fiyat;

                Console.WriteLine($"\n'{yeniFilm.Ad}' başarıyla eklendi! Fiyat: {yeniFilm.Fiyat}$");
                Console.WriteLine($"Güncel toplam maliyet: {toplamMaliyet}$");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
            }
        }

        public void FilmSil()
        {
            Console.Write("Silmek istediğiniz filmin adını giriniz: ");
            string ad = Console.ReadLine();

            var film = izlemeListesi.FirstOrDefault(f => f.Ad.Equals(ad, StringComparison.OrdinalIgnoreCase));
            if (film != null)
            {
                izlemeListesi.Remove(film);
                toplamMaliyet -= film.Fiyat;
                Console.WriteLine($"'{ad}' listeden silindi. Yeni toplam maliyet: {toplamMaliyet}$");
            }
            else
            {
                Console.WriteLine("Bu isimde bir film listede bulunamadı.");
            }
        }

        public void IzlemeListesiniGoster()
        {
            Console.WriteLine("\n--- İzleme Listeniz ---");
            if (izlemeListesi.Count == 0)
            {
                Console.WriteLine("Listeniz şu an boş.");
                return;
            }

            int i = 1;
            foreach (var film in izlemeListesi)
            {
                Console.WriteLine($"{i}. {film.Ad} ({film.Tur}) - {film.Puan}/10 - {film.Sure}dk - {film.Yonetmen} - {film.Fiyat}$");
                i++;
            }

            Console.WriteLine($"\nToplam maliyet: {toplamMaliyet}$");
        }

        public void ListeyiKaristir()
        {
            if (izlemeListesi.Count == 0)
            {
                Console.WriteLine("Liste boş, karıştırılamaz.");
                return;
            }

            Random r = new Random();
            izlemeListesi = izlemeListesi.OrderBy(x => r.Next()).ToList();
            Console.WriteLine("Liste karıştırıldı!");
        }

        public void ListeyiSirala()
        {
            if (izlemeListesi.Count == 0)
            {
                Console.WriteLine("Liste boş, sıralanamaz.");
                return;
            }

            Console.WriteLine("Sıralama seçeneği: ");
            Console.WriteLine("1 - Ada göre");
            Console.WriteLine("2 - Puana göre");
            Console.WriteLine("3 - Süreye göre");
            Console.WriteLine("4 - Fiyata göre");
            Console.Write("Seçim: ");
            string secim = Console.ReadLine();

            switch (secim)
            {
                case "1":
                    izlemeListesi = izlemeListesi.OrderBy(f => f.Ad).ToList();
                    break;
                case "2":
                    izlemeListesi = izlemeListesi.OrderByDescending(f => f.Puan).ToList();
                    break;
                case "3":
                    izlemeListesi = izlemeListesi.OrderBy(f => f.Sure).ToList();
                    break;
                case "4":
                    izlemeListesi = izlemeListesi.OrderBy(f => f.Fiyat).ToList();
                    break;
                default:
                    Console.WriteLine("Geçersiz seçim!");
                    return;
            }

            Console.WriteLine("Liste sıralandı!");
        }
    }
}

