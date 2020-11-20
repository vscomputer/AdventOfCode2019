using System.Collections.Generic;

namespace DaysCombined
{
    public class RunsOpcodes
    {
        private readonly ParsesOpcodeStrings _parsesOpcodeStrings;
        public RunsOpcodes(ParsesOpcodeStrings parsesOpcodeStrings)
        {
            _parsesOpcodeStrings = new ParsesOpcodeStrings();
        }

        public string Run(List<decimal> opcodes)
        {
            int currentIndex = 0;
            while (opcodes[0 + currentIndex] != 99)
            {
                switch (opcodes[0 + currentIndex])
                {
                    case 1:
                        opcodes[(int) opcodes[3 + currentIndex]] = opcodes[(int) opcodes[1 + currentIndex]] + opcodes[(int) opcodes[2 + currentIndex]];
                        break;
                    case 2:
                        opcodes[(int) opcodes[3 + currentIndex]] = opcodes[(int) opcodes[1 + currentIndex]] * opcodes[(int) opcodes[2 + currentIndex]];
                        break;
                }
                currentIndex += 4;
            }
            return _parsesOpcodeStrings.Parse(opcodes);
        }

        public string Run(string opcodeString)
        {
            var opcodes = _parsesOpcodeStrings.Parse(opcodeString);
            return Run(opcodes);
        }
    }
}