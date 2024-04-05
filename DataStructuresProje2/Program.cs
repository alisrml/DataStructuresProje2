using DataStructuresProje2;
using System;
using System.Collections;
using System.Diagnostics.Metrics;

List<UM_ALANI> VeriOkumaListeAtama()
{
    List<UM_ALANI> Alanlar = new List<UM_ALANI>();

    String veriler = "1. Divriği Ulu Camii ve Darüşşifası (Sivas) 1985 \r\n\r\n2. İstanbul'un Tarihi Alanları (İstanbul) 1985 \r\n\r\n3. Göreme Millî Parkı ve Kapadokya (Nevşehir) 1985 (Karma Miras Alanı) \r\n\r\n4. Hattuşa: Hitit Başkenti (Çorum) 1986 \r\n\r\n5. Nemrut Dağı (Adıyaman) 1987 \r\n\r\n6. Hieropolis-Pamukkale (Denizli) 1988 (Karma Miras Alanı) \r\n\r\n7. Xanthos-Letoon (Antalya-Muğla) 1988 \r\n\r\n8. Safranbolu Şehri (Karabük) 1994 \r\n\r\n9. Truva Arkeolojik Alanı (Çanakkale) 1998 \r\n\r\n10. Edirne Selimiye Camii ve Külliyesi (Edirne) 2011 \r\n\r\n11. Çatalhöyük Neolitik Alanı (Konya) 2012 \r\n\r\n12. Bursa ve Cumalıkızık: Osmanlı İmparatorluğunun Doğuşu (Bursa) 2014 \r\n\r\n13. Bergama Çok Katmanlı Kültürel Peyzaj Alanı (İzmir) 2014 \r\n\r\n14. Diyarbakır Kalesi ve Hevsel Bahçeleri Kültürel Peyzajı (Diyarbakır) 2015 \r\n\r\n15. Efes (İzmir) 2015 \r\n\r\n16. Ani Arkeolojik Alanı (Kars) 2016 \r\n\r\n17. Aphrodisias (Aydın) 2017 \r\n\r\n18. Göbekli Tepe (Şanlıurfa) 2018\r\n\r\n19. Arslantepe Höyüğü (Malatya) 2021\r\n\r\n20. Gordion (Ankara) 2023\r\n\r\n21. Anadolu’nun Ortaçağ Dönemi Ahşap Hipostil Camiileri (Konya-Eşrefoğlu Camii, Kastamonu-Mahmut Bey Camii, Eskişehir-Sivrihisar Camii, Afyon-Afyon Ulu Camii, Ankara-Arslanhane Camii) 2023";
    String[] satirVeriler = veriler.Split("\r\n\r", StringSplitOptions.RemoveEmptyEntries);

    int donguNo = 1;
    foreach (string veri in satirVeriler)
    {
        string alanAdi;
        List<string> ilAdlari = new List<string>();
        string ilanYili;

        string[] parcalanmisVeri = veri.Split(new char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
        if (donguNo < 10) { alanAdi = parcalanmisVeri[0].Substring(3).Trim(); }
        else
        {
            alanAdi = parcalanmisVeri[0].Substring(4).Trim();//metin teimleme tam dogru calısmıyor.
        }

        ilanYili = parcalanmisVeri[2].Trim();

        string iller = parcalanmisVeri[1].Trim();
        if (donguNo != 21 & donguNo != 7) { ilAdlari.Add(iller); }

        if (donguNo == 7)
        {
            string[] elemanlar = iller.Split('-');
            ilAdlari.Add(elemanlar[0]);
            ilAdlari.Add(elemanlar[1]);
        }
        if (donguNo == 21)
        {
            //burada özel bir algoritma ile il sayısı birden fazla olan mirasın il verilerini ayıklatıyorum.
            string[] elemanlar = iller.Split(", ");

            foreach (string e in elemanlar)
            {
                string[] parca = e.Split('-');
                if (parca.Length > 1)
                {
                    string sehir = parca[0];
                    ilAdlari.Add(sehir);
                }
            }
        }
        UM_ALANI alan = new UM_ALANI(alanAdi, ilAdlari, ilanYili);
        Alanlar.Add(alan);
        donguNo++;
    }
    return Alanlar;
}

List<List<UM_ALANI>> GenericListOlusturma()
{
    List<List<UM_ALANI>> bolgeAlanListesi = new List<List<UM_ALANI>>();

    List<UM_ALANI> Akdeniz = new List<UM_ALANI>();
    List<UM_ALANI> DoguAnadolu = new List<UM_ALANI>();
    List<UM_ALANI> Ege = new List<UM_ALANI>();
    List<UM_ALANI> GuneyDoguAnadolu = new List<UM_ALANI>();
    List<UM_ALANI> IcAnadolu = new List<UM_ALANI>();
    List<UM_ALANI> Karadeniz = new List<UM_ALANI>();
    List<UM_ALANI> Marmara = new List<UM_ALANI>();

    bolgeAlanListesi.Add(Akdeniz);
    bolgeAlanListesi.Add(DoguAnadolu); 
    bolgeAlanListesi.Add(Ege);
    bolgeAlanListesi.Add(GuneyDoguAnadolu);
    bolgeAlanListesi.Add(IcAnadolu);
    bolgeAlanListesi.Add (Karadeniz);
    bolgeAlanListesi.Add(Marmara);


    List<string[]> bolgeler = new List<string[]>
    {
        new string[] { "Antalya" }, //akdeniz
        new string[] { "Kars", "Malatya" }, //doguanadolu
        new string[] { "Denizli", "Muğla", "İzmir", "Aydın", "Afyon" }, //ege
        new string[] { "Adıyaman", "Şanlıurfa" }, //guneydogu
        new string[] { "Sivas", "Nevşehir", "Konya", "Ankara", "Eskişehir" }, //icanadolu
        new string[] { "Çorum", "Karabük", "Kastamonu" }, //karadeniz
        new string[] { "İstanbul", "Çanakkale", "Edirne", "Bursa" } //marmara
    };  

    //her sehir üzerinde döngüyle gezilecek. eğer bölgede yer alıyorsa ve eklenmemisse bölgeye klenecek.
    List<UM_ALANI> umAlanlar = VeriOkumaListeAtama();

    foreach(UM_ALANI umAlani in umAlanlar)
    {
        
        foreach(string ilAdi in umAlani.ilAdlari)
        {

            for (int i = 0; i < bolgeler.Count; i++)
            {
                if (bolgeler[i].Contains(ilAdi))
                {
                    bolgeAlanListesi[i].Add(umAlani);
                    break;
                }
            }
        }
    }
    return bolgeAlanListesi;
}

void bolgeAlanYazdirma(List<List<UM_ALANI>> bolgeAlanlarListesi)
{   
    string[] bolgeAdlari = { "Akdeniz", "Doğu Anadolu", "Ege", "Güney Doğu Anadolu", "İç Anadolu", "Karadeniz", "Marmara" };
    
    for(int i = 0; i < bolgeAlanlarListesi.Count; i++) 
    { 
        List<UM_ALANI> bolge = bolgeAlanlarListesi[i];
        Console.WriteLine(bolgeAdlari[i]+" Bölgesi ");
        List<string> yazdirilmislar = new List<string>();
        int sayac = 0;
        foreach(UM_ALANI alan in bolge)
        {
            if (yazdirilmislar.Contains(alan.alanAdi))
            {
                continue;
            }
            
            string iller = "";
            foreach(string il in alan.ilAdlari) { iller += il + " "; }
            Console.WriteLine(alan.alanAdi+" "+iller+alan.ilanYili);
            yazdirilmislar.Add(alan.alanAdi);
            sayac++;
        }
        Console.WriteLine(bolgeAdlari[i]+" bölgesi toplam: " + sayac + " UM alanı\n");
    }
}

void alanlariStackteDepolamaYazdirma(List<List<UM_ALANI>> bolgeAlanlarListesi)
{
    string[] bolgeAdlari = { "Akdeniz", "Doğu Anadolu", "Ege", "Güney Doğu Anadolu", "İç Anadolu", "Karadeniz", "Marmara" };
    Stack<Stack<UM_ALANI>> bolgeAlan = new Stack<Stack<UM_ALANI>>();
    foreach(List<UM_ALANI> alanList in bolgeAlanlarListesi)
    {   
        Stack<UM_ALANI> yeniStack = new Stack<UM_ALANI>();
        foreach(UM_ALANI alan in alanList)
        {
            yeniStack.Push(alan);
        }
        bolgeAlan.Push(yeniStack);
    }

    //burada daha dikkatli bir yazdırma gerekiyor.
    int donguNo = 6;
    while(bolgeAlan.Count > 0)
    {
        Stack<UM_ALANI> alanlar = bolgeAlan.Pop();

        List<string> yazdirilmislar = new List<string>();
        int sayac = 0;
        Console.WriteLine(bolgeAdlari[donguNo] + " Bölgesi ");
        while (alanlar.Count > 0)
        {
            
            UM_ALANI alan = alanlar.Pop();
            if (yazdirilmislar.Contains(alan.alanAdi))
            {
                continue;
            }
            else
            {
                string iller = "";
                foreach (string il in alan.ilAdlari) { iller += il + " "; }
                Console.WriteLine(alan.alanAdi + " " + iller + alan.ilanYili);
                yazdirilmislar.Add(alan.alanAdi);
                sayac++;
            }
            
        }
        Console.WriteLine(bolgeAdlari[donguNo] + " bölgesi toplam: " + sayac + " UM alanı\n");
        donguNo--;
    }
}

void alanlariQueuedaDepolamaYazdirma(List<List<UM_ALANI>> bolgeAlanlarListesi)
{
    string[] bolgeAdlari = { "Akdeniz", "Doğu Anadolu", "Ege", "Güney Doğu Anadolu", "İç Anadolu", "Karadeniz", "Marmara" };
    Queue<Queue<UM_ALANI>> bolgeAlan = new Queue<Queue<UM_ALANI>>();
    foreach (List<UM_ALANI> alanList in bolgeAlanlarListesi)
    {
        Queue<UM_ALANI> yeniQueue = new Queue<UM_ALANI>();
        foreach (UM_ALANI alan in alanList)
        {
            yeniQueue.Enqueue(alan);
        }
        bolgeAlan.Enqueue(yeniQueue);
    }

    //burada daha dikkatli bir yazdırma gerekiyor.
    int donguNo = 0;
    while (bolgeAlan.Count > 0)
    {
        Queue<UM_ALANI> alanlar = bolgeAlan.Dequeue();

        List<string> yazdirilmislar = new List<string>();
        int sayac = 0;
        Console.WriteLine(bolgeAdlari[donguNo] + " Bölgesi ");
        while (alanlar.Count > 0)
        {

            UM_ALANI alan = alanlar.Dequeue();
            if (yazdirilmislar.Contains(alan.alanAdi))
            {
                continue;
            }
            else
            {
                string iller = "";
                foreach (string il in alan.ilAdlari) { iller += il + " "; }
                Console.WriteLine(alan.alanAdi + " " + iller + alan.ilanYili);
                yazdirilmislar.Add(alan.alanAdi);
                sayac++;
            }

        }
        Console.WriteLine(bolgeAdlari[donguNo] + " bölgesi toplam: " + sayac + " UM alanı\n");
        donguNo++;
    }
}

string devam = "e";
while (devam == "e" || devam == "E")
{   
    Console.WriteLine("1-Generic List oluşturarak alanları sınıflandıran ve bölge bölge alanları yazdırma seçeneği\n" +
        "2-Stack kullanarak Alanları depolayıp yazdırma seçeneği\n" +
        "3-Queue kullanarak Alanları depolayıp yazdırma seçeneği\n" +
        "4-Priorityqueue kullanarak elemanları sırayla yazdırma seçeneği\n" +
        "5-Markette kasada sıra bekleyen müsteriler sorusu\n" +
        "6-Markette PriorityQueueya göre islem sorusu\n");
    Console.Write("Seçiminiz:");
    string input = Console.ReadLine();
    int secim = Convert.ToInt32(input);
    if(secim == 1)
    {
        List<List<UM_ALANI>> bolgeAlanlarListesi = GenericListOlusturma();
        bolgeAlanYazdirma(bolgeAlanlarListesi);
    }else if(secim == 2)
    {
        List<List<UM_ALANI>> bolgeAlanlarListesi = GenericListOlusturma();
        alanlariStackteDepolamaYazdirma(bolgeAlanlarListesi);
    }else if (secim == 3)
    {
        List<List<UM_ALANI>> bolgeAlanlarListesi = GenericListOlusturma();
        alanlariQueuedaDepolamaYazdirma(bolgeAlanlarListesi);
    }else if(secim == 4)
    {
        List<UM_ALANI> alanlar = VeriOkumaListeAtama();
        PriorityQueue priorityQueue = new PriorityQueue();
        foreach(UM_ALANI alan in alanlar)
        {
            priorityQueue.enque(alan);
        }
        while (!priorityQueue.bosMu())
        {
            UM_ALANI silinenAlan = priorityQueue.deque();

            string iller = "";
            foreach (string il in silinenAlan.ilAdlari) { iller += il + " "; }
            Console.WriteLine(silinenAlan.alanAdi + " " + iller + silinenAlan.ilanYili);
        }
    }
    else if (secim == 5)
    {
        Queue<int> kasaKuyrugu = new Queue<int>();
        kasaKuyrugu.Enqueue(10);
        kasaKuyrugu.Enqueue(4);
        kasaKuyrugu.Enqueue(8);
        kasaKuyrugu.Enqueue(6);
        kasaKuyrugu.Enqueue(7);
        kasaKuyrugu.Enqueue(1);
        kasaKuyrugu.Enqueue(15);
        kasaKuyrugu.Enqueue(9);
        kasaKuyrugu.Enqueue(3);
        kasaKuyrugu.Enqueue(2);

        double toplamSure = 0;
        int kuyrukBoyutu = kasaKuyrugu.Count;
        double herkesinToplamSuresi = 0;

        while (kasaKuyrugu.Count > 0)
        {
            int urunAdedi = kasaKuyrugu.Dequeue();
            double islemSuresi = urunAdedi * 2.5;

            Console.WriteLine($"Müşterinin işlem süresi: {islemSuresi} saniye");
            toplamSure += islemSuresi;
            Console.WriteLine($"Müşterinin toplam bekleme süresi: {toplamSure} saniye\n");
            herkesinToplamSuresi += toplamSure;
        }

        double ortalamaSure = herkesinToplamSuresi / kuyrukBoyutu;
        Console.WriteLine($"Müşterilerin ortalama işlem süresi: {ortalamaSure} saniye");
    }
    else if(secim == 6)
    {
        PriorityQueue2 kasaKuyrugu = new PriorityQueue2();
        kasaKuyrugu.Enqueue(10);
        kasaKuyrugu.Enqueue(4);
        kasaKuyrugu.Enqueue(8);
        kasaKuyrugu.Enqueue(6);
        kasaKuyrugu.Enqueue(7);
        kasaKuyrugu.Enqueue(1);
        kasaKuyrugu.Enqueue(15);
        kasaKuyrugu.Enqueue(9);
        kasaKuyrugu.Enqueue(3);
        kasaKuyrugu.Enqueue(2);

        double toplamSure = 0;
        int kuyrukBoyutu = 0;
        double herkesinToplamSuresi = 0;

        while (!kasaKuyrugu.IsEmpty())
        {
            int urunAdedi = kasaKuyrugu.Dequeue();
            double islemSuresi = urunAdedi * 2.5;

            Console.WriteLine($"Müşterinin işlem süresi: {islemSuresi} saniye");
            toplamSure += islemSuresi;
            Console.WriteLine($"Müşterinin toplam bekleme süresi: {toplamSure} saniye\n");
            herkesinToplamSuresi += toplamSure;
            kuyrukBoyutu++;
        }

        double ortalamaSure = herkesinToplamSuresi / kuyrukBoyutu;
        Console.WriteLine($"Müşterilerin ortalama işlem süresi: {ortalamaSure} saniye");
    }


    Console.Write("Devam mı(e/E):");
    devam = Console.ReadLine();
}