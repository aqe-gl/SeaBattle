using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    internal class Ship
    {
        public bool Horizontal { get; private set; }
        public int SizeX { get; private set; }
        public int SizeY { get; private set; }
        public List<int[]> Coords { get; private set; }
        public List<int[]> ShotCoords { get; set; }

        


        public Ship(int size, Random r)
        {
            Coords = new List<int[]>();
            ShotCoords = new List<int[]>();
            int randomNumber = r.Next(1, 3);
            if (randomNumber == 1)
            {
                Horizontal = true;
                SizeX = size;
                SizeY = 1;
            }
            else
            {
                Horizontal = false;
                SizeX = 1;
                SizeY = size;
            }
        }
    }
}
