using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Bunker
{
    //Статичный класс, содержащий в себе методы для обработки различных позиций
    static class Handler
    {
        //Метод возвращает рандомную строчку из текстового файла
        public static string RandomStrFile(string file)
        {
            Random rand = new Random();
            string[] strs = File.ReadAllLines(@$"D:\C# Bunker\Bunker\data\{file}" , Encoding.UTF8);
            string s = strs[rand.Next(strs.Length)];
            return s;
        }


    }

}
