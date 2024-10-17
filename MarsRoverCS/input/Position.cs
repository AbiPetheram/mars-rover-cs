using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverCS.input
{
    public class Position
    {
        private Coordinates coordinates { get; set;}
        private CompassDirection direction { get; set;} 

        override
        public string ToString()
        {
            return coordinates.x + " " + coordinates.y + " " + direction.ToString();
        }
    }
}
