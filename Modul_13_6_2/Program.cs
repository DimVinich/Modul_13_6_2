using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Modul_13_6_2
{
    class Program
    {
        static void Main(string[] args)
        {

            // Считываем файл  в строку
            string nFile = @"D:\\Text1.txt";
            string lsOriginalText;
            try
            {
                lsOriginalText = File.ReadAllText(nFile);
            }
            catch (Exception ex)
            {
                Console.WriteLine("При считывании файла случились проблемы \n" + ex.Message);
                Console.ReadKey();
                return;
            }

            // Зачищаем строку от знаков препинания
            string noPunctuationText = new string(lsOriginalText.Where(c => !char.IsPunctuation(c)).ToArray());

            // Формируем массив слов
            string[] arrText = noPunctuationText.Split(new char[] { ' ' });

            //  Размещаем в словаре, с подсчётом повторов
            Dictionary<string, int> ldicText = new Dictionary<string, int>();
            foreach (string lsh in arrText)
            {
                if (ldicText.ContainsKey(lsh)) ldicText[lsh]++;
                else ldicText.Add(lsh, 1);
            }

            // Отбираем 10 наиболее часто втречаемых
            int i = 0;
            foreach (KeyValuePair<string, int> lKVP in ldicText.OrderByDescending(x => x.Value))
            {
                i++;
                if (i > 10) break;
                Console.WriteLine($" Слово {lKVP.Key}  встретилось {lKVP.Value}  раз") ;
            }

            Console.ReadKey();
        }
    }
}
