using System;
using System.Collections.Generic;
using System.Text;

namespace Bunker
{
    class Card
    {
        //Все 12 позиций с присвоением значения по умолчанию
        public Position Gender { get; set; } = Handler.RandomStrFile("gender.txt");
        public Position Old { get; set; } = Handler.RandomStrFile("old.txt");
        public Position Profession { get; set; } = Handler.RandomStrFile("profession.txt");
        public Position Сhildbearing { get; set; } = Handler.RandomStrFile("childbearing.txt");
        public Position Health { get; set; } = Handler.RandomStrFile("health.txt");
        public Position Phobia { get; set; } = Handler.RandomStrFile("phobia.txt");
        public Position Hobby { get; set; } = Handler.RandomStrFile("hobby.txt");
        public Position Character { get; set; } = Handler.RandomStrFile("character.txt");
        public Position Additionally { get; set; } = Handler.RandomStrFile("additionally.txt");
        public Position Baggage { get; set; } = Handler.RandomStrFile("baggage.txt");
        public Position Card1 { get; set; } = Handler.RandomStrFile("card1.txt");
        public Position Card2 { get; set; } = Handler.RandomStrFile("card2.txt");

        //Возможно список всех позиций будет полезным
        //public List<Position> allpositions = new List<Position>(12) { };
      
        public Card()
        {

        }


    }
}
