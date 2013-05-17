using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameofLife
{
    class Program
    {

        private const char cellIcon = 'o';
        private const int maxX = 60;
        private const int maxY = 40;
        private static int[,] field = new int[maxX, maxY];

        static void DrawField()
        {
            Console.CursorLeft = 0;
            Console.CursorTop = 0;

            for (int y = 0; y < maxY; y++)
            {
                for (int x = 0; x < maxX; x++)
                {
                    Console.Write(field[x, y] == 1 ? cellIcon : ' ');
                }

                Console.WriteLine();
            }
        }


        static void Main(string[] args)
        {
            //Initialize
            Console.SetWindowSize(maxX + 10, maxY + 10);
            Console.SetWindowPosition(0, 0);

            //Random initial positions
            Random r = new Random((int)DateTime.Now.Ticks);
            for (int x = 0; x < maxX; x++)
            {
                for (int y = 0; y < maxY; y++)
                {
                    field[x, y] = r.Next(0, 1 + 1);
                }
            }

            //Instantiate the desired concrete RuleSet in this Strategy pattern
            RuleSet ruleSet = new ConwaysGameOfLife(field, maxX, maxY);

            for (int i = 0; i < 5000; i++)
            {
                DrawField();
                ruleSet.Tick();
            }
        }
    }
}
