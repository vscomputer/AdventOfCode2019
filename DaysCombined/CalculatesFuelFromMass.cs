using System;

namespace DaysCombined
{
    public class CalculatesFuelFromMass
    {
        public decimal CalculateFuel(decimal mass)
        {
            decimal result = 0;
            result += Math.Floor(mass / 3) - 2;
            if (Math.Floor(result / 3) - 2 > 0)
            {
                result += CalculateFuel(result);
            }
            return result;
        }
    }
}