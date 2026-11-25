# YMH219-FlappyBird

Nesne Tabanlı Programlama (YMH219) dersi kapsamında geliştirilen, Windows Forms ile yazılmış Flappy Bird benzeri masaüstü oyunu.

## Kullanılan Teknolojiler
- C# / .NET 10
- Windows Forms
- Visual Studio 2026

## Kurulum ve Çalıştırma
1. Depoyu klonlayın: `git clone https://github.com/Aylin-akagndz/YMH219-FlappyBird.git`
2. `YMH219-FlappyBird.slnx` dosyasını Visual Studio ile açın.
3. Yeşil ▶ (Başlat) düğmesi ile çalıştırın.

## Temel Özellikler
- Space tuşu ile kuş zıplar, yer çekimi ile düşer
- Üç engel sağdan sola hareket eder, ekran dışına çıkanlar yeniden konumlandırılır
- Engele, zemine veya tavana çarpınca oyun biter (Game Over)
- Engel geçildikçe skor artar, her 5 skorda hız artar
- R tuşu ile oyun yeniden başlatılır
- Skor, en yüksek skor ve hız bilgisi ekranda gösterilir

## Sınıf Yapısı
- `GameState`: skor, hız ve oyun durumu
- `Bird`: kuşun hareketi ve zıplaması
- `PipePair`: üst/alt engel çifti, hareket ve çarpışma kontrolü
- `Form1`: oyun döngüsü (Timer) ve klavye olayları

## Ekran Görüntüleri
![Başlangıç](YMH219-FlappyBird/screenshots/oyun1.png)
![Oyun](YMH219-FlappyBird/screenshots/oyun2.png)
![Game Over](YMH219-FlappyBird/screenshots/gameover.png)

## Bilinen Sınırlamalar
- En yüksek skor dosyada saklanmıyor, program kapanınca sıfırlanır.
- Görseller yerine düz renkli kutular kullanıldı.

## Öğrenci
Aylin Akagündüz — 250541011
