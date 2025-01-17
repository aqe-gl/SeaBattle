using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Battlefield area = new Battlefield();
            area.PlaceShips();
            area.Print();

            int turns = 30;
            for(int turn = 0; turn < turns; turn++)
            {
                Console.WriteLine($"You have {turns - turn} attempts");
                Console.WriteLine("Where to shoot?");
                string input;
                while (true)
                {
                    input = Console.ReadLine();
                    if (area.IsValidInput(input))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Your input is not understood. Try again.");
                    }
                }               
               // Console.Clear();
                if(area.ShootAt(input) == true)
                {
                    turn--;
                }
                area.Print();
                if (area.CheckVictory())
                {
                    Console.WriteLine("You have won the battle");
                    break;
                }
            }

            Console.ReadLine();
        }
    }
}
