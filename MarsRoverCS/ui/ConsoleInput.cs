using MarsRoverCS.input;
using MarsRoverCS.input.parsing;
using MarsRoverCS.logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverCS.ui
{
    internal class ConsoleInput
    {
        CoordinateParser CoordinateParser;
        DirectionParser DirectionParser;
        InstructionParser InstructionParser;
        MissionControl MissionControl;
        public ConsoleInput(MissionControl missionControl) 
        {
            CoordinateParser = new CoordinateParser();
            DirectionParser = new DirectionParser();
            InstructionParser = new InstructionParser();
            MissionControl = missionControl;
        }
        public Plateau GetPlateau()
        {
            Console.WriteLine("Hello! Please specify the dimensions of your plateau in the format 0 0: ");
            while (true) 
            {
                try
                {
                    String[] input = Console.ReadLine()?.ToString().Split(' ') ?? new string[2];
                    var coordinates = CoordinateParser.ParseCoordinates(input);
                    return MissionControl.CreatePlateau(coordinates);
                }
                catch (Exception e) when (e is ArgumentException || e is ArgumentNullException) 
                {
                    Console.WriteLine("Invalid input, please try again");
                }
            }
        }
        public Rover GetRover(Plateau plateau)
        {
            Console.WriteLine("Add a rover to your plateau. Specify the location in the format 0 0 N: ");
            while (true)
            {
                try
                {
                    String[] input = Console.ReadLine()?.ToString().Split(' ') ?? new string[3];
                    var coordinates = CoordinateParser.ParseCoordinates(new string[] { input[0], input[1] });
                    var direction = DirectionParser.ParseDirection(input[2]);
                    return MissionControl.CreateRover(new Position(coordinates, direction), plateau);
                }
                catch (Exception e) when (e is ArgumentException || e is ArgumentNullException)
                {
                    Console.WriteLine("Invalid input, please try again");
                }
            }
        }
    }
}
