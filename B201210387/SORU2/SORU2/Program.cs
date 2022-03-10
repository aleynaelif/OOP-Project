/****************************************************************************
**					SAKARYA ÜNİVERSİTESİ
**			   BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
**				    BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
**				   NESNEYE DAYALI PROGRAMLAMA DERSİ
**					  2020-2021 BAHAR DÖNEMİ
**	
**				ÖDEV NUMARASI..........: 1. ÖDEV SORU 2
**				ÖĞRENCİ ADI............: ALEYNA ELİF ÖZKAN
**				ÖĞRENCİ NUMARASI.......: B201210387
**              DERSİN ALINDIĞI GRUP...: 1-C
****************************************************************************/


using System;
using System.Text.RegularExpressions;

namespace SORU2
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice = 0;

            Console.WriteLine("\t\t\tMenü\n1. String bir değikende, string değeri substring kullanmadan ara");
            Console.WriteLine("2. String bir değişkende, string değeri substring kullanarak ara\n3. Alfabenin karakterlerini bir stringde ara kaç adet geçiyor bul ve çiz\n\nSeçiminiz: ");

            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)             //kullanıcıdan alınan inputa göre çalıştırılan fonksiyonlar için switch case
            {
                case 1:
                    part1();
                    break;

                case 2:
                    part2();
                    break;

                case 3:
                    part3();
                    break;

                default:
                    Console.WriteLine("Yanlış Seçim!");
                    break;
            }
        }

        static void part1()
        {

            string aranan = null, S = null;
            int i = -1;

            Console.WriteLine("Aranılacak Kelime: ");
            aranan = Console.ReadLine();
            aranan = aranan.ToUpper().ToLower();            //büyük küçük harf farkını kaldırmak için 

            Console.WriteLine("Karakter Dizini: ");
            S = Console.ReadLine();
            S = S.ToUpper().ToLower();

            while (true)
            {
                i = S.IndexOf(aranan, i + 1);           //aranan karakterin indisi

                if (i == -1)
                    break;

                Console.WriteLine("Kelime " + aranan + " indisi: {0}", i);
            }
        }

        static void part2()
        {

            string aranan = null, S = null;
            int i = 0, index = 0, flag = 0;

            Console.WriteLine("Aranılacak Kelime: ");
            aranan = Console.ReadLine();
            aranan = aranan.ToUpper().ToLower();

            Console.WriteLine("Karakter Dizini: ");
            S = Console.ReadLine();
            S = S.ToUpper().ToLower();

            int[] num = new int[S.Length];      

            if (S.Contains(aranan) == true)
            {

                while (index != -1)
                {

                    index = S.IndexOf(aranan);
                    S = S.Substring(index + 1);         //karakter bulundukça kalan kısmı ayırıp tekrar aramak için substring 

                    if (flag == 0)                  // ilk durum için (flag=0) döngü
                    {

                        num[i] = index;
                        flag = 1;

                        Console.WriteLine("\nKelime " + aranan + " indisi: {0}", num[i]);
                        i++;
                    }

                    else if (index != -1 && flag != 0)      //diğer durumlar için döngü
                    {

                        num[i] = index + num[i - 1] + 1;    //index ayrılan stringe göre değişiyor

                        Console.WriteLine("Kelime " + aranan + " indisi: {0}", num[i]);
                        i++;
                    }
                }
            }
        }

        static void part3()
        {
            char[] kucuk = { 'a', 'b', 'c', 'ç', 'd', 'e', 'f', 'g', 'ğ', 'h', 'ı', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'ö', 'p', 'r', 's', 'ş', 't', 'u', 'ü', 'v', 'y', 'z' };
            char[] buyuk = { 'A', 'B', 'C', 'Ç', 'D', 'E', 'F', 'G', 'Ğ', 'H', 'I', 'İ', 'J', 'K', 'L', 'M', 'N', 'O', 'Ö', 'P', 'R', 'S', 'Ş', 'T', 'U', 'Ü', 'V', 'Y', 'Z' };
            string S = null;
            int num = 0, i = 0, j = 0, alphabet = 29;


            Console.WriteLine("Karakter Dizini: ");
            S = Console.ReadLine();

            Console.WriteLine("\n");
            Console.WriteLine("karakter sayısı\tgrafik gösterimi");

            for (i = 0; i < alphabet; i++)      //ekrana şekili bastırmak için döngü
            {

                Console.Write(buyuk[i] + " , sayısı:  ");

                num = check(S, kucuk[i]) + check(S, buyuk[i]); // büyük küçük harf ayrımını kaldırmak için sayılarını topluyor

                Console.Write(num + " ");

                for (j = 0; j < num; j++)
                    Console.Write("* ");            //grafiği basıyor

                Console.Write("\n");
            }
        }


        static int check(string S, char c)      // harflerin kaç kere geçtiğini bulan yardımcı fonksiyon
        {
            int i, count = 0;

            for (i = 0; i < S.Length; i++)
            {

                if (S[i] == c)
                {
                    count++;
                }
            }
            return count;
        }

    }
}