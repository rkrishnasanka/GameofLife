using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameofLife
{
    class RuleGeneric:RuleSet
    {
        private int _a;
        private int _b;

        public RuleGeneric(int[,] field, int maxX, int maxY, int a, int b)
            : base(field, maxX, maxY)
        {
            _a = a;
            _b = b;
        }

        ///<summary>
        ///Converts a number to an array of digits. For example 123 becomes 1,2,3
        ///</summary>
        ///<param name="digits">Number, such as 123</param>
        ///<returns>List of numbers, such as 1,2,3</returns>
        ///
        protected List<int> ToDigitArray(int digits)
        {
            List<int> result = new List<int>();

            string digitString = digits.ToString();
            foreach (char digit in digitString)
            {
                result.Add(Convert.ToInt32(digit.ToString()));
            }

            return result;
        }

        protected override int[,] TickAlgorithm()
        {
            int[,] field2 = new int[_maxX, _maxY];

            // A/B
            // The first number(s) is what is required for a cell to continue.
            // The scond number(s) is the requirement for birth.
            for (int y = 0; y < _maxY; y++)
            {
                for (int x = 0; x < _maxX; x++)
                {
                    bool processed = false;
                    int neighbours = GetNumberOfNeighbours(x, y);

                    List<int> birthDigits = ToDigitArray(_b);

                    foreach (var digit in birthDigits)
                    {
                        if (neighbours == digit)
                        {
                            // cell is born
                            field2[x, y] = 1;
                            processed = true;
                            break;
                        }
                    }

                    if (processed)
                    {
                        continue;
                    }

                    List<int> liveDigits = ToDigitArray(_a);
                    foreach (var digit in liveDigits)
                    {
                        if (neighbours == digit)
                        {
                            // cell continues
                            field2[x, y] = _field[x, y];
                            processed = true;
                            break;
                        }
                    }

                    if (processed)
                    {
                        continue;
                    }

                    //cell dies
                    field2[x, y] = 0;
                }
            }

            return field2;
        }
    }


}
