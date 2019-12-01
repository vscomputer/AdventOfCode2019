using System;
using System.IO;

namespace Day01
{
    public class CalculatesFuelFromMass
    {
        public decimal Calculate(decimal mass)
        {
            decimal result = 0;
            result += Math.Floor(mass / 3) - 2;
            if (Math.Floor(result / 3) - 2 > 0)
            {
                result += Calculate(result);
            }
            return result;
        }

        public decimal ParseFile(string fileName)
        {
            var modules = File.ReadAllLines(fileName);
            decimal result = 0;
            foreach (var module in modules)
            {                
                result += Calculate(int.Parse(module));
            }

            return result;
        }
    }
}