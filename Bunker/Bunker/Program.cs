using System;

namespace Bunker
{
    class Program
    {
        static void Main(string[] args)
        {
          
            Card card1 = new Card();
            Console.WriteLine(card1.Gender.Data);
            Player player1 = new Player();
            Console.WriteLine(player1.Name);
            Player player2 = new Player();
            Console.WriteLine(player2.Name);

            Catastrophe cata1 = new Catastrophe();
            Console.WriteLine(cata1.Data);
            Console.WriteLine(cata1.Description);
        }
    }
}
