using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace DaysCombined
{
    public class ParsesOpcodeStrings
    {
        public List<decimal> Parse(string opcodeString)
        {
            var splitString = opcodeString.Split(',');
            return splitString.Select(decimal.Parse).ToList();
        }

        public string Parse(List<decimal> opcodes)
        {
            var result = new StringBuilder();
            foreach (var opcode in opcodes)
            {
                result.Append(opcode.ToString(CultureInfo.InvariantCulture) + ",");
            }

            return result.Remove(result.Length - 1, 1).ToString(); //gotta remove that last comma
        }
    }
}