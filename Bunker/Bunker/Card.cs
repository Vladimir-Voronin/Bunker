using System;
using System.Collections.Generic;
using System.Text;

namespace Bunker
{
    class Card
    {
        //Все 12 позиций с присвоением рандомного значения по умолчанию (в один момент сделал вместе со свойствами поля, 
        //возможно стоит убрать, стало слишком громоздко, но пока оставлю)
        private Position gender = new Position("gender.txt", 0);
        public Position Gender { get { return gender; } set { gender = value; } }

        private Position old = new Position("old.txt", 0);
        public Position Old { get { return old; } set { old = value; } }

        private Position profession = new Position("profession.txt", 0);
        public Position Profession { get { return profession; } set { profession = value; } }

        private Position childbearing = new Position("childbearing.txt", 1);
        public Position Сhildbearing { get { return childbearing; } set { childbearing = value; } }

        private Position health = new Position("health.txt", 0);
        public Position Health { get { return health; } set { health = value; } }

        private Position phobia = new Position("phobia.txt", 0);
        public Position Phobia { get { return phobia; } set { phobia = value; } }

        private Position hobby = new Position("hobby.txt", 0);
        public Position Hobby { get { return hobby; } set { hobby = value; } }

        private Position character = new Position("character.txt", 0);
        public Position Character { get { return character; } set { character = value; } }

        private Position additionally = new Position("additionally.txt", 0);
        public Position Additionally { get { return additionally; } set { additionally = value; } }

        private Position baggage = new Position("baggage.txt", 0);
        public Position Baggage { get { return baggage; } set { baggage = value; } }

        private Position card1 = new Position("card1.txt", 0);
        public Position Card1 { get { return card1; } set { card1 = value; } }

        private Position card2 = new Position("card2.txt", 0);
        public Position Card2 { get { return card2; } set { card2 = value; } }

        //Возможно список всех позиций будет полезным
        public List<Position> allpositions = new List<Position>(12) { };
      
        public Card()
        {
            allpositions.Add(Gender);
            allpositions.Add(Old);
            allpositions.Add(Profession);
            allpositions.Add(childbearing);
            allpositions.Add(Health);
            allpositions.Add(Phobia);
            allpositions.Add(Hobby);
            allpositions.Add(Character);
            allpositions.Add(Additionally);
            allpositions.Add(Baggage);
            allpositions.Add(Card1);
            allpositions.Add(Card2);
        }


    }
}
