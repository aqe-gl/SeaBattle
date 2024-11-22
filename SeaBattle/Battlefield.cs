using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    internal class Battlefield
    {
        string[] letters = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
        char[,] visibleArea = new char[10, 10];
        public void Print()
        {
            string areaString = "  0 1 2 3 4 5 6 7 8 9\n";
            for (int i = 0; i < 10; i++)
            {
                areaString += $"{letters[i]} ";
                for (int j = 0; j < 10; j++)
                {
                    if (visibleArea[i, j] == '\0')
                    {
                        visibleArea[i, j] = '~';
                    }                    
                    areaString += $"{visibleArea[i, j]} ";
                }
                areaString += "\n";
            }

            Console.WriteLine(areaString);
        }
    }
}
