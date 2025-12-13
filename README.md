# BasicRumiToGregorianConverter

This basic Rumi calender convert is a static Converter class
for converting Gregorian dates to Rumi dates.

# Usage
To use the Rumi calendar converter, you can utilize the 
`Converter` class provided in the code. 
This class includes a static method `ConvertToGregorian` that takes a 
Gregorian date as input and returns the corresponding Rumi date.

> 
	Converter.ConvertToGregorian(1322, 10,31); -> 1907-01-13

# Tirnavali.BasicRumiToGregorianConverter

[![NuGet Version](https://img.shields.io/nuget/v/Tirnavali.BasicRumiToGregorianConverter?style=for-the-badge)](https://www.nuget.org/packages/Tirnavali.BasicRumiToGregorianConverter/)

## 🌟 Genel Bakış

**.BasicRumiToGregorianConverter**, C# dilinde yazılmış hafif bir kütüphanedir. Osmanlı İmparatorluğu'nda 1840'tan (Rumi 1256) 1925'e (Rumi 1341) kadar resmi olarak kullanılan **Rumi (Mali) Takvimi** tarihlerini **Miladi (Gregoryen) Takvime** dönüştürmek için tasarlanmıştır.

Bu kütüphane, Rumi ve Miladi takvimler arasındaki farklılıkları ve tarihsel geçiş dönemlerini (özellikle 12 ve 13 günlük farkların uygulandığı zaman dilimlerini) hassasiyetle ele alır.

## 📦 Kurulum

Paketi projenize kurmanın en kolay yolu .NET CLI veya NuGet Paket Yöneticisi'ni kullanmaktır.

### .NET CLI ile

```bash
dotnet add package Tirnavali.BasicRumiToGregorianConverter
````

### NuGet Paket Yöneticisi (Package Manager Console) ile

```powershell
Install-Package Tirnavali.BasicRumiToGregorianConverter
```

## 🛠 Kullanım

Kütüphane, `Converter` adlı statik bir sınıf ve tüm dönüşüm mantığını içeren tek bir genel metot sunar: `ConvertToGregorian`.

### Basit Dönüşüm Örneği

```csharp
using Tirnavali.BasicRumiToGregorianConverter.Application;
using System;

public class DateConversionExample
{
    public static void Main()
    {
        // Örnek Rumi Tarih: 1295-12-29 (Rumi Yıl-Ay-Gün)
        int rumiYear = 1295;
        int rumiMonth = 12; 
        int rumiDay = 29;

        // Dönüşüm işlemini gerçekleştir
        DateOnly gregorianDate = Converter.ConvertToGregorian(rumiYear, rumiMonth, rumiDay);

        // Sonuç: 1880-03-12 (Miladi)
        Console.WriteLine($"Rumi Tarih: {rumiYear}-{rumiMonth:D2}-{rumiDay:D2}");
        Console.WriteLine($"Miladi Tarih: {gregorianDate}");
    }
}
```
### Özel İstisnalar (Exceptions)

Kütüphane, geçersiz veya desteklenmeyen tarihler için özel istisnalar fırlatır:

| İstisna Sınıfı | Fırlatıldığı Durum |
| :--- | :--- |
| `OutOfBeginRumiDayException` | Rumi yılın desteklenen başlangıç aralığının (1256) altında olması. |
| `LastRumiDayException` | Desteklenen bitiş aralığının (1341-12-26) üzerinde olması veya takvimde karşılığı olmayan geçersiz bir Rumi tarihi girilmesi. |
| `Rumi125LawException` | Takvimde karşılığı olmayan geçersiz bir Rumi tarihi girilmesi. |

## 🤝 Katkıda Bulunma

Hata bildirimleri, özellik önerileri veya kod katkıları her zaman memnuniyetle karşılanır. Lütfen bir Pull Request göndermeden önce mevcut [Sorunlar (Issues)](https://www.google.com/search?q=https://github.com/tirnavali/Tirnavali.BasicRumiToGregorianCoverter/issues) bölümünü kontrol edin.

## 📄 Lisans

Bu proje [MIT Lisansı](https://www.google.com/url?sa=E&source=gmail&q=https://github.com/tirnavali/Tirnavali.BasicRumiToGregorianCoverter/blob/main/LICENSE) altında lisanslanmıştır.

-----

**[tirnavali](https://github.com/tirnavali)** tarafından sevgiyle geliştirilmiştir.

```
