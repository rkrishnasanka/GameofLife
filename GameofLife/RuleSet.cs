using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameofLife
{
    public abstract class RuleSet
    {
        protected int _maxX = 0;
        protected int _maxY = 0;
        protected int[,] _field;

        ///<summary>
        ///Instantiates the RuleSet with a copy of the game field and the maximum X,Y boundaries.
        ///</summary>
        ///<param name="field">int[][] game field</param>
        ///<param name="maxX">Maximum X boundary</param>
        ///<param name="maxY">Maximum Y boundary</param>
        ///
        public RuleSet(int[,] field, int maxX, int maxY)
        {
            _field = field;
            _maxX = maxX;
            _maxY = maxY;
        }

        ///<summary>
        ///Returns the number of neighbours for a cell at X,Y
        ///</summary>
        ///<param name="x">X coordinate of the cell to check</param>
        ///<param name="y">Y coordinate of the cell to check</param>
        ///<returns>number of neighbours</returns>
        ///
        protected int GetNumberOfNeighbours(int x, int y)
        {
            // Returns the number of neighbours for a specific coordinate
            int neighbours = 0;

            if (x + 1 < _maxX && _field[x+1,y]==1)
            {
                neighbours++;
            }

            if (x-1 >= 0 && _field[x-1,y]==1)
            {
                neighbours++;
            }

            if (y + 1 < _maxY && _field[x,y+1] == 1)
            {
                neighbours++;
            }

            if (y - 1 >= 0 && _field[x,y-1] == 1)
            {
                neighbours++;
            }
             
            // Now checking the diagnols

            if (x+1 < _maxX && y+1 < _maxY && _field[x+1,y+1]==1)
            {
                neighbours++;
            }

            if (x+1 < _maxX && y-1 >= 0 && _field[x+1,y-1]==1)
            {
                neighbours++;
            }

            if (x-1 >= 0 && y+1 < _maxY && _field[x-1,y+1] == 1)
            {
                neighbours++;
            }

            if (x-1 >= 0 && y-1 >= 0 && _field[x-1,y-1]==1)
            {
                neighbours++;
            }

            return neighbours;
        }

        ///<summary>
        ///Executes one generation of the game field, causing cells to live , die or give birth
        ///This is a template method, which calls the concrete method TickAlgorithm() to execute the cell movement details.
        ///</summary>
        ///
        public void Tick()
        {
            int[,] field2 = TickAlgorithm();

            //Copy field = field2
            Array.Copy(field2, _field, field2.Length);
        }

        ///<summary>
        ///This is a part of the template method Tick() and contains the details for the cell activity.
        ///This method examines the current field and returns a new field with the changes for 1 generation
        ///</summary>
        ///<returns>int[][] new game field/returns>
        ///
        protected abstract int[,] TickAlgorithm();
    }
}
