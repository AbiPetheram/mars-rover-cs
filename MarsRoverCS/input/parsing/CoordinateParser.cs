using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject.input.parsing
{
    internal class CoordinateParser
    {
        public Coordinates parseCoordinates(string[] input)
        {
            if(input == null || input.Length != 2)
            {
                throw new ArgumentOutOfRangeException();
            } else if (!char.IsDigit(input[0][0]) || !char.IsDigit(input[1][0]))
            {
                throw new ArgumentOutOfRangeException();
            } else
            {
                return new Coordinates(Int32.Parse(input[0]), Int32.Parse(input[1]));
            }
        }
    }
}
