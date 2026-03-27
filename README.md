# 🎬 Film Kütüphanesi ve İzleme Listesi Sistemi

Bu proje, bir film akış platformu mantığıyla çalışan, kullanıcıların kendi izleme listelerini oluşturmasına ve yönetmesine olanak tanıyan bir C# uygulamasıdır. Proje, **Inheritance (Kalıtım)** ve **Polimorfizm** prensiplerini derinlemesine uygulamaktadır.

## 🏗️ Nesne Yönelimli Mimari

Sistem, bir ana sınıf ve ondan türeyen alt sınıflar üzerine kurulmuştur:

### 1. Film Sınıfı (Ana Sınıf)
Tüm filmler için ortak olan `ad`, `yönetmen`, `süre`, `yaş sınırı`, `puan`, `tür` ve `fiyat` özelliklerini barındırır.

### 2. Film Türlerine Göre Alt Sınıflar ve Kurallar
Her film türü kendi özel kısıtlamalarına ve fiyatlandırmasına sahiptir:
- **Aksiyon:** Minimum 90 dakika süre ve dublör bilgisi zorunluluğu. ($2.0)
- **Komedi:** Mizah yoğunluğu (1-5 arası) sınırlaması ve maksimum 120 dakika süre. ($1.2)
- **Drama:** Minimum 13 yaş sınırı ve en az 90 dakika süre gereksinimi. ($1.8)
- **Belgesel:** 45-180 dakika arası süre kısıtlaması ve anlatıcı bilgisi zorunluluğu. ($1.5)

### 3. Kullanıcı Sınıfı (Yönetim Merkezi)
İzleme listesi üzerindeki tüm operasyonel işlemler bu sınıfta gerçekleştirilir:
- **FilmEkle():** Kullanıcıdan alınan verileri uygun alt sınıfa göre nesneleştirir.
- **FilmSil():** İsme göre listeden kaldırma işlemi yapar.
- **ListeyiGoster():** Mevcut listeyi ve toplam maliyeti hesaplayıp ekrana yazar.
- **ListeyiKaristir() & ListeyiSirala():** Dinamik liste manipülasyonu sağlar.

## 🛠️ Teknik Özellikler
- **Dil:** C#
- **Konsept:** OOP (Kalıtım, Polimorfizm, Encapsulation)
