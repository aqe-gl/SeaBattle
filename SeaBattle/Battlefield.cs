using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    internal class Battlefield
    {
        Random r = new Random();
        List<string> letters = new List<string>{ "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
        char[,] visibleArea = new char[10, 10];

        bool[,] area = new bool[10, 10];

        List<Ship> ships = new List<Ship>();
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
                    if (area[i, j] == true)
                    {
                        // visibleArea[i, j] = '#';
                    }
                    areaString += $"{visibleArea[i, j]} ";
                }
                areaString += "\n";
            }

            Console.WriteLine(areaString);
        }

        public void PlaceShips()
        {

            Ship battleship = new Ship(4, r);
            Ship destroyer1 = new Ship(3, r);
            Ship destroyer2 = new Ship(3, r);
            Ship submarine1 = new Ship(2, r);
            Ship submarine2 = new Ship(2, r);
            Ship submarine3 = new Ship(2, r);
            Ship patrolBoat1 = new Ship(1, r);
            Ship patrolBoat2 = new Ship(1, r);
            Ship patrolBoat3 = new Ship(1, r);
            Ship patrolBoat4 = new Ship(1, r);

            ships.Add(battleship);
            ships.Add(destroyer1);
            ships.Add(destroyer2);
            ships.Add(submarine1);
            ships.Add(submarine2);
            ships.Add(submarine3);
            ships.Add(patrolBoat1);
            ships.Add(patrolBoat2);
            ships.Add(patrolBoat3);
            ships.Add(patrolBoat4);

            //for (int i = 0; i < ships.Count; i++)
            //{
            //    PlaceShip(ships[i]);

            //}

            foreach (Ship ship in ships)
            {
                PlaceShip(ship);
            }

        }

        private void PlaceShip(Ship ship)
        {
            
            int row, column;
            while (true)
            {
                if (ship.Horizontal)
                {
                    row = r.Next(0, 10);
                    column = r.Next(0, 11 - ship.SizeX);
                }
                else
                {
                    column = r.Next(0, 10);
                    row = r.Next(0, 11 - ship.SizeY);
                }

                if (CheckPlacement(column, row, ship))
                {
                    for (int i = 0; i < ship.SizeX; i++)
                    {
                        for (int j = 0; j < ship.SizeY; j++)
                        {
                            area[column + i, row + j] = true;
                            ship.Coords.Add(new int[] { column + i, row + j });

                        }
                    }
                    break;
                }

                
            }
           
        }

        private bool CheckPlacement(int column, int row, Ship ship)
        {
            for (int i = column - 1; i <= column + ship.SizeX; i++)
            {
                for (int j = row - 1; j <= row + ship.SizeY; j++)
                {
                    if (i >= 0 && i < 10 && j >= 0 && j < 10)
                    {
                        if (area[i, j] == true)
                        {
                            return false;
                        }                        
                    }
                    
                }
            }
            return true;
        }

        public bool ShootAt(string location) // E.g. "a8"
        {

            var row = letters.IndexOf(location[0].ToString().ToUpper());
            var column = int.Parse(location[1].ToString());

            if (area[row, column] == true)
            {
                foreach (Ship ship in ships.ToList())
                {

                    foreach (int[] coords in ship.Coords)
                    {
                        if (row == coords[0] && column == coords[1])
                        {
                            ship.ShotCoords.Add(coords);
                            area[row, column] = false;
                            if (ship.Coords.Count == ship.ShotCoords.Count)
                            {
                                Console.WriteLine("Killed");
                                ShipKilled(ship);
                            }
                            else
                            {
                                Console.WriteLine("Damaged");
                                visibleArea[row, column] = '0';
                            }
                        }
                    }
                }
                return true;
            }
            else
            {
                Console.WriteLine("You missed");
                visibleArea[row, column] = 'X';
                return false;
            }
        }

        void ShipKilled(Ship ship)
        {
            ships.Remove(ship);
            int column = ship.Coords[0][0];
            int row = ship.Coords[0][1];
            for(int i = column - 1; i < column + ship.SizeX + 1; i++)
            {
                for(int j = row - 1; j < row + ship.SizeY + 1; j++)
                {
                    if(i >= 0 && i < 10 && j >= 0 && j < 10)
                    {
                        visibleArea[i, j] = 'X';
                    }
                }

            }
            for (int i = column; i < column + ship.SizeX; i++)
            {
                for (int j = row; j < row + ship.SizeY; j++)
                {
                    visibleArea[i, j] = 'O';
                }
            }
        }

        public bool CheckVictory()
        {
            if (ships.Count == 0)
            {
                return true;
            }
            else
            {
                return false;

            }
        }
        public bool IsValidInput(string input)
        {
            try
            {
                var row = letters.IndexOf(input[0].ToString().ToUpper());
                var column = int.Parse(input[1].ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
