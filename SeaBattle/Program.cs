﻿using System;
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
            area.Print();

            Console.ReadLine();
        }
    }
}
