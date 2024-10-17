using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverCS.input.parsing
{
    internal class DirectionParser
    {
        public CompassDirection ParseDirection(string input)
        {
            if(input.Length > 0 || !char.IsLetter(input[0]))
            {
                throw new ArgumentOutOfRangeException(nameof(input));
            }
            return input.ToUpper() switch
            {
                "N" => CompassDirection.N,
                "S" => CompassDirection.S,
                "E" => CompassDirection.E,
                "W" => CompassDirection.W,
                _ => throw new ArgumentException()
            };
        }
    }
}
