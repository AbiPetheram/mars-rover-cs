using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverCS.input
{
    public class Position
    {
        public Position(Coordinates coordinates, CompassDirection direction)
        {
            Coordinates = coordinates;
            Direction = direction;
        }

        private Coordinates Coordinates { get; set;}
        private CompassDirection Direction { get; set;} 

        public override string ToString()
        {
            return Coordinates.x + " " + Coordinates.y + " " + Direction.ToString();
        }
    }
}
