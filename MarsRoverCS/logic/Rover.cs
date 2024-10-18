using MarsRoverCS.input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverCS.logic
{
    public class Rover
    {
        private Position Position { get; set; }
        private Plateau Plateau { get; set; }

        public Rover(Position position, Plateau plateau)
        {
            Position = position;
            Plateau = plateau;
        }
    }
}
