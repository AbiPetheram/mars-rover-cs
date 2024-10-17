using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverCS.input.parsing
{
    internal class InstructionParser
    {
        public Instruction[] ParseInstructions(String input)
        {
            if(String.IsNullOrEmpty(input)) throw new ArgumentNullException(nameof(input));
            Instruction[] result = new Instruction[input.Length];
            for (int i = 0; i < result.Length; i++)
            {
                switch (char.ToUpper(input[i]))
                {
                    case 'L':
                        result[i] = Instruction.L;
                        break;
                    case 'R':
                        result[i] = Instruction.R;
                        break;
                    case 'M':
                        result[i] = Instruction.M;
                        break;
                    default:
                        throw new ArgumentException(nameof(input));
                }
            }
            return result;
        }
    }
}
