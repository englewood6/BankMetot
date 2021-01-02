using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankMetot
{
    class Program
    {
        public static string sifre = "ab18";

        public static int bakiye = 250;
        static void Main(string[] args)
        {
            Console.WriteLine("Kartlı işlem\nŞifre giriniz: ");
            string sifre = Console.ReadLine();
            sifrekontrol(sifre);

            Console.ReadLine();
        }

        public static void sifrekontrol(string sifreKontrol)
        {

            if (sifreKontrol == sifre) { kartliislem(); }
            else { Console.WriteLine("Şifreniz yanlıştır."); }
        }
        public static void kartliislem()
        {
            Console.WriteLine("*******************Ana Menü\nPara Çekmek için    1\nPara yatırmak için  2\nPara Transferleri   3\nEğitim Ödemeleri    4\nÖdemeler            5\nBilgi Güncelleme    6");
            string secim = Console.ReadLine();
            switch (secim)
            {
                case "1":
                    Console.WriteLine("*********************PAra çekme bölümü************\nÇekilecek miktarı giriniz: ");
                    int paraCekme = Convert.ToInt32(Console.ReadLine());
                    paracekme(paraCekme);
                    break;
                case "2":
                    Console.WriteLine("*********************PAra yatırma bölümü************ ");
                    parayatırma();
                    break;
                case "3":
                    Console.WriteLine("*********************EFT bölümü************");
                    eft();
                    break;
                case "4":
                    Console.WriteLine("********************* ödemeleri bölümü************\n\nMenüye aktarılıyorsunuz. ");
                    odemeler();
                    break;
                case "5":
                    Console.WriteLine("*********************Eğitim Ödemeler bölümü************ ");
                    egitimödemeleri();
                    break;
                case "6":
                    Console.WriteLine("*********************Bilgi güncelleme bölümü************ ");
                    bilgiguncelleme();
                    break;
                default: Console.WriteLine("Programdan çıkılıyor"); break;
            }
        }
        public static void paracekme(int paracekme)
        {
            if (paracekme > bakiye) { Console.Clear(); Console.WriteLine("Bakiyeniz yetersizdir\nBAKİYE={0}", bakiye); kartliislem(); }
            else { bakiye -= paracekme; Console.Clear(); Console.WriteLine("Çekilen biktar{0}\nKalan Bakiye{1}", paracekme, bakiye); kartliislem(); }
        }
        public static void parayatırma()
        {
            Console.WriteLine("Kredi Kartına   1\nKendi Hesabınıza yatırmak için  2");
            string secim = Console.ReadLine();
            switch (secim)
            {
                case "1":
                    krediParaYatırma();
                    break;
                case "2":
                    bakiye += 1000; Console.WriteLine("Habınızda 1000 TL para yatırılmıştır.\nYeni bakiyeniz{0}=", bakiye);
                    break;
                default:
                    break;
            }

        }
        public static void eft()
        {
            Console.WriteLine("Başında TR olacak şekilde para gönderilecek IBAN numarasını giriniz\n(TR yazısı küçük büyük farketmeyecektir)");
            string TRBas = Console.ReadLine();
            double IBAN = double.Parse(TRBas.Substring(2));
            string TRkontrol = TRBas.Substring(0, 2).ToUpper();
            if (TRkontrol == "TR")
            {
                if (IBAN >= 100000000000 && IBAN <= 999999999999)
                {

                    try
                    {
                        Console.WriteLine("Transfer edilecek miktarı giriniz:");
                        int TRMiktard = Convert.ToInt32(Console.ReadLine());
                        if (bakiye >= TRMiktard)
                        {
                            if (TRMiktard <= 0) { Console.WriteLine("Eksik veya hatalı tuşlama."); }
                            else { 
                                bakiye -= TRMiktard;
                                Console.Clear(); 
                                Console.WriteLine("{0}Tl {1} Ibanına transfer edilmiştir.\nKalan bakiyeniz{2}", TRMiktard, IBAN, bakiye); 
                                kartliislem(); 
                            }
                        }
                        else if (bakiye < TRMiktard) { 
                            Console.WriteLine("Yetersiz Bakiye. Lütfen tekrar giriniz\t\nMevcut Bakiyeniz:{0}", bakiye); 
                        }
                        else { 
                            Console.WriteLine("Eksik veya hatalı tuşlama yaptınız"); 
                        }
                    }
                    catch (FormatException) {
                        Console.WriteLine("Eksik veya hatalı tuşlama yaptınız"); 
                    }
                }
                else { Console.WriteLine("Eksik veya hatalı tuşlama.\n 12 Iban numarası 12 haneli olmak zorundadır."); ; }
            }
            else
            {
                Console.WriteLine("Eksik veya hatalı girdiniz.");
                eft();
            }

        }
        public static void odemeler()
        {
            Console.WriteLine(" ");
            kartliislem();
        }
        public static void egitimödemeleri()
        {
            Console.WriteLine("Eğitim ödemeleri bölümü arızalıdır.");
        }
        public static void bilgiguncelleme()
        {
            Console.WriteLine("bilgi güncelleme");
        }



        public static void krediParaYatırma()
        {
            Console.WriteLine("Kredi kardı için en az 12 haneli kart numarasını giriniz:");
            long secim = Convert.ToInt64(Console.ReadLine());
            if (secim < 999999999999 && secim > 100000000000)
            {
                Console.WriteLine("Yatırılacak miktarı giriniz:");
                int KrediYatirma = Convert.ToInt32(Console.ReadLine());
                if (KrediYatirma > bakiye) { Console.WriteLine("Bakiyeniz Uygun değildir"); }
                else { bakiye -= KrediYatirma; Console.WriteLine("Kredi Kartına Yatırılan miktar={0}\nKalan Bakiye={1}", KrediYatirma, bakiye); }
            }
        }
    }
}

