using System;
using System.Collections.Generic;
using System.Text;

namespace Bunker
{
    //Хранит в себе один показатель, который может быть скрытым или
    //открытым. Агрегация с классами Card и Game(?)
    class Position
    {
        //Позиция может быть открытой и закрытой (закрыта по умолчанию)
        public bool Open { get; set; } = false;
        //Хранит в себе значение (главное свойство в классе)
        public string Data { get; set; }

        //Перегрузка операции преобразования, чтобы можно было явно
        //присваивать позиции значение
        public static implicit operator Position(string data)
        {
            return new Position { Data = data };
        }

        //
        public void Refresh(string file)
        {
            Handler.RandomStrFile(@"D:\C# Bunker\Bunker\data\{file}");
        }
    }
}
