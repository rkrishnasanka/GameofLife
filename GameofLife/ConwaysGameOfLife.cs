using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameofLife
{
    public class ConwaysGameOfLife : RuleSet
    {
        public ConwaysGameOfLife(int[,] field, int maxX, int maxY)
            : base(field, maxX, maxY)
        {
        }

        protected override int[,] TickAlgorithm()
        {
            int[,] field2 = new int[_maxX, _maxY];
             
            //23/3 - Conway's Game of Life
            //The first number(s) is the requirement for a cell to continue.
            //The second number(s) is th requirement for birth.
            for (int y = 0; y < _maxY; y++)
            {
                for (int x = 0; x < _maxX; x++)
                {
                    int neighbours = GetNumberOfNeighbours(x, y);
                    if (neighbours == 3)
                    {
                        //cell is born
                        field2[x, y] = 1;
                        continue;
                    }

                    if (neighbours ==2 || neighbours == 3)
                    {
                        // cell continue
                        field2[x, y] = _field[x, y];
                        continue;
                    }

                    // cell dies
                    field2[x, y] = 0;
                }
            }

            return field2;
        }
    }
}
