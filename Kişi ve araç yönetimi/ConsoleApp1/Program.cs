using System;
using System.Collections.Generic;

// Kişi bilgilerini saklamak için Kişi sınıfı
class Kişi
{
    public string Adı { get; set; }
    public string Soyadı { get; set; }
    public int DoğumYılı { get; set; }
    public string TCKimlikNo { get; private set; }

    public Kişi(string adı, string soyadı, int doğumYılı, string tcKimlikNo)
    {
        this.Adı = adı;
        this.Soyadı = soyadı;
        this.DoğumYılı = doğumYılı;
        this.TCKimlikNo = tcKimlikNo;
    }

    public string KişiBilgileri()
    {
        return $"Adı: {Adı} Soyadı: {Soyadı} Doğum Yılı: {DoğumYılı} TCKimlik No: Gizli";
    }
}

// Araç bilgilerini saklamak için Araç sınıfı
class Araç
{
    public string ŞasiNo { get; private set; }
    public string Model { get; set; }
    public int Yıl { get; set; }
    public string Marka { get; set; }
    public DateTime EdinmeTarihi { get; set; }
    public decimal EdinmeFiyatı { get; set; }
    public Kişi Sahip { get; private set; }

    public Araç(string şasiNo, string model, int yıl, string marka, DateTime edinmeTarihi, decimal edinmeFiyatı)
    {
        this.ŞasiNo = GizliŞasiNo(şasiNo);
        this.Model = model;
        this.Yıl = yıl;
        this.Marka = marka;
        this.EdinmeTarihi = edinmeTarihi;
        this.EdinmeFiyatı = edinmeFiyatı;
        this.Sahip = null;
    }
    public string GizliŞasiNo(string şasiNo)
    {
        
        if (şasiNo.Length >= 6)
        {
            char[] gizliŞasi = şasiNo.ToCharArray();
            for (int i = 1; i < şasiNo.Length - 1; i++)
            {
                gizliŞasi[i] = '*';
            }
            return new string(gizliŞasi);
        }
        return şasiNo;
    }

    public void SahibiBelirle(Kişi kişi)
    {
        Sahip = kişi;
    }

    public string AraçBilgileri()
    {
        string sahibiBilgisi = Sahip != null ? $"Bir önceki sahibinin adı: {Sahip.Adı}" : "Sahibi bilinmiyor";
        return $"Araçın şasi numarası: {ŞasiNo}, Model: {Model}, Yıl: {Yıl}, Marka: {Marka}, Edinme Tarihi: {EdinmeTarihi:dd.MM.yyyy}, Edinme Fiyatı: {EdinmeFiyatı:C2}, {sahibiBilgisi}";
    }
}

class Program
{
    static void Main()
    {
        // Kişi ve araç nesneleri oluşturuyoruz
        Kişi kişi = new Kişi("Murat", "Taşyürek", 1985, "12345678901");
        Kişi kişi4 = new Kişi("hilmi", "Çayır", 2003, "22345678908");
        Kişi kişi1 = new Kişi("Tayyar", "Boz", 2004, "12345678902");
        Kişi kişi2 = new Kişi("Yasin", "Yıldırım", 2001, "12345678903");
        Kişi kişi3 = new Kişi("Remzi", "Dalabasanoğlu", 2000, "12345678904");

        Araç araç1 = new Araç("A12345", "Taksi", 2020, "Toyota", new DateTime(2020, 1, 1), 50000);
        Araç araç2 = new Araç("B67890", "Kamyon", 2018, "Ford", new DateTime(2019, 5, 15), 75000);
        Araç araç3 = new Araç("C54321", "Otobüs", 2019, "Mercedes", new DateTime(2020, 3, 10), 120000);
        Araç araç4 = new Araç("D24680", "Sedan", 2022, "Volkswagen", new DateTime(2022, 8, 20), 60000);

        // Araçların sahipleri belirleniyor
        araç1.SahibiBelirle(kişi4);
        araç2.SahibiBelirle(kişi1);
        araç3.SahibiBelirle(kişi2);
        araç4.SahibiBelirle(kişi3);

        // Kişinin sahip olduğu araçları listeliyoruz
        List<Araç> kişininAraçları = new List<Araç> { araç1, araç2, araç3, araç4};
        Console.WriteLine($"{kişi.KişiBilgileri()} sahip olduğu araçlar:");
        foreach (var araç in kişininAraçları)
        {
            Console.WriteLine(araç.AraçBilgileri());
        }
        Console.ReadKey();
    }
}
