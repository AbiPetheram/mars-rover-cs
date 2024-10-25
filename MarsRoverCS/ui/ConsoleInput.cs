using MarsRoverCS.input;
using MarsRoverCS.input.parsing;
using MarsRoverCS.logic;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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
                    String[] input = Console.ReadLine()?.ToString().Split(' ') ?? new string[2];
                    var coordinates = CoordinateParser.ParseCoordinates(new string[] { input[0], input[1] });
                    var direction = DirectionParser.ParseDirection(input[2]);
                    return MissionControl.CreateRover(new Position(coordinates, direction), plateau);
                }
                catch (Exception e) when (e is ArgumentException || e is ArgumentNullException || e is IndexOutOfRangeException)
                {
                    Console.WriteLine("Invalid input, please try again");
                }
            }
        }

        public void MoveRover(Rover rover)
        {
            Console.WriteLine("Take your rover for a walk. Enter a series of turn and move commands: ");
            while (true)
            {
                try
                {
                    var input = InstructionParser.ParseInstructions(Console.ReadLine()?.ToString() ?? "");
                    rover.move(input);
                    Console.WriteLine("The rover is now in position " + rover.Position.ToString());
                    return;
                }
                catch (Exception e) when (e is ArgumentException || e is ArgumentNullException)
                {
                    Console.WriteLine("Invalid input, please try again");
                }
            }
        }

        public void OptionsList(Plateau plateau, Rover rover)
        {
            Console.WriteLine("What would you like to do next?\n1. Add another rover\n2. Move current rover again\n3. Quit");
            switch (Console.ReadLine())
            {
                case "1":
                    MoveRover(GetRover(plateau));
                    break;
                case "2":
                    MoveRover(rover);
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 3");
                    OptionsList(plateau, rover);
                    break;

            }
        }
    }
}
