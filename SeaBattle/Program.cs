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
                string input = Console.ReadLine();
               // Console.Clear();
                if(area.ShootAt(input) == true)
                {
                    turn--;
                }
                area.Print();
            }

            Console.ReadLine();
        }
    }
}
