using System;
using System.Threading;
namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            var Control = new Controller(20, "Anri", 40);
            Control.GameStart(3);
            while (true)
            {
                if (Control.checkforwin())
                {
                    Console.WriteLine("You win");
                    break;
                }

                if (Control.checkforlose())
                {
                    Console.WriteLine("You lose");
                    break;
                }
                Control.Heroaction();
                Control.Enemyaction();
                Control.display();
                Thread.Sleep(500);
                Console.Clear();
            }
        }
    }
}
