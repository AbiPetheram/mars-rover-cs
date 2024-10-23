using MarsRoverCS.input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverCS.logic
{
    public class MissionControl
    {
        public Dictionary<Plateau, List<Rover>> PlateauRovers;

        public MissionControl()
        {
            this.PlateauRovers = new Dictionary<Plateau, List<Rover>>();
        }

        public Plateau CreatePlateau(Coordinates Coordinates)
        {
            if(Coordinates == null)
            {
                throw new ArgumentNullException(nameof(Coordinates));
            }
            Plateau plateau = new Plateau(Coordinates);
            PlateauRovers.Add(plateau, new List<Rover>()); 
            return plateau;
        }
    }
}
