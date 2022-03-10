/****************************************************************************
**					SAKARYA ÜNİVERSİTESİ
**			   BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
**				    BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
**				   NESNEYE DAYALI PROGRAMLAMA DERSİ
**					  2020-2021 BAHAR DÖNEMİ
**	
**				ÖDEV NUMARASI..........: 1. ÖDEV SORU 1
**				ÖĞRENCİ ADI............: ALEYNA ELİF ÖZKAN
**				ÖĞRENCİ NUMARASI.......: B201210387
**              DERSİN ALINDIĞI GRUP...: 1-C
****************************************************************************/

using System;

namespace SORU1
{
    class Program
    {
        static void Main(string[] args)
        {
            int max = 8, i = 0, satir = 0, sutun = 0, j = 0;
            int[] tahta = new int[max * max];
            int[] helperSatir = new int[max];
            int[] helperSutun = new int[max];

            tahta = sifirla(tahta, max * max);              //arraylere başlangıç değeri atama
            helperSutun = sifirla(helperSutun, max);
            helperSatir = sifirla(helperSatir, max);

            Random rnd = new Random();

            for (i = 0; i < max; i++)                       //satir numaraları için random değer atama
            {
                while (true)
                {
                    satir = rnd.Next(max);
                    if (!Contains(helperSatir, satir)) break;   // fonksiyon bu satırda kale olup olmadığını kontrol ediyor
                }
                helperSatir[i] = satir;                 //eğer satır boşsa random değer arraye yerleştiriliyor
            }

            for (i = 0; i < max; i++)           //sütun numaraları için random değer atama
            {
                while (true)
                {
                    sutun = rnd.Next(max);
                    if (!Contains(helperSutun, sutun)) break;   //fonksiyon bu sütunda kale olup olmadığını kontrol ediyor
                }

                helperSutun[i] = sutun;     //eğer sütun boşsa random değer arraye yerleştiriliyor
            }

            i = 0;

            while (j < max)             //toplam 8 kale için döngü
            {
                tahta[helperSutun[i] * max + helperSatir[i]] = 1;   // kale random değerlere yerleştiriliyor
                Console.WriteLine(" {0}. Kale\n", j + 1);
                bastir(tahta, max);
                j++;
                i++;
            }

        }

        static bool Contains(int[] arr, int deger)          //2 random değerin aynı olmaması için yardımcı fonksiyon
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == deger) return true;
            }

            return false;
        }


        static int[] sifirla(int[] arr, int max)        // arraylerin içine başlangıç değeri atamak için yardımcı fonksiyon
        {
            int i = 0;

            for (i = 0; i < max; i++)
            {
                arr[i] = -1;

            }
            return arr;

        }

        static void bastir(int[] arr, int max)  // santranç tahtasını bastrımak için yardımcı fonksiyon
        {
            int i = 0;

            for (i = 0; i < max * max; i++)
            {

                if (arr[i] == -1)
                    Console.Write(" 0 ");
                else
                    Console.Write(" K ");

                if (i % max == 7)
                    Console.Write("\n\n");
            }
            Console.Write("\n\n");
        }
    }
}
