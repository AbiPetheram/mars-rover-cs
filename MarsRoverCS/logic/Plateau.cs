using MarsRoverCS.input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverCS.logic
{
    public class Plateau
    {
        public Coordinates Size { get; set; }

        public Plateau(Coordinates size) 
        {
            this.Size = size;
        }
    }
}
