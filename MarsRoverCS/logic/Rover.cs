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
        public Position Position { get; set; }
        public Plateau Plateau { get; set; }

        public Rover(Position position, Plateau plateau)
        {
            Position = position;
            Plateau = plateau;
        }

        public void move(Instruction[] instructions)
        {
            foreach (Instruction instruction in instructions)
            {
                if(instruction == Instruction.M)
                {
                    moveForward(instruction);
                }
            }
        }

        private void moveForward(Instruction instruction)
        {
            switch (Position.Direction)
            {
                case CompassDirection.N:
                    Position = new Position(new Coordinates(Position.Coordinates.x, Position.Coordinates.y + 1), Position.Direction);
                    break;
                case CompassDirection.E:
                    Position = new Position(new Coordinates(Position.Coordinates.x + 1, Position.Coordinates.y), Position.Direction);
                    break;
                case CompassDirection.S:
                    Position = new Position(new Coordinates(Position.Coordinates.x, Position.Coordinates.y - 1), Position.Direction);
                    break;
                case CompassDirection.W:
                    Position = new Position(new Coordinates(Position.Coordinates.x - 1, Position.Coordinates.y), Position.Direction);
                    break;
            }
        }
    }
}
