using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverCS.input.parsing
{
    public class CoordinateParser
    {
        public Coordinates ParseCoordinates(string[] input)
        {
            if(input == null || input.Length != 2)
            {
                throw new ArgumentException();
            } else if (!char.IsDigit(input[0][0]) || !char.IsDigit(input[1][0]))
            {
                throw new ArgumentException();
            } else
            {
                return new Coordinates(int.Parse(input[0]), int.Parse(input[1]));
            }
        }
    }
}
