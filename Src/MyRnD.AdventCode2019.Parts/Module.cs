using System;

namespace MyRnD.AdventCode2019.Parts
{
    public sealed class Module
    {
        public int Mass { get; set; }

        /// <summary>
        /// Simple calculation just for the module's mass.
        /// </summary>
        public int FuelCounterUpper
        {
            get { return ((int)Math.Floor(Mass / 3.0) - 2); }
        }

        /// <summary>
        /// Calculates the fuel required by the module and for the fuel itself.
        /// </summary>
        public int FuelCounterUpper2
        {
            get
            {
                int totalFuelNeeded = 0;
                int mass = Mass;
                while (mass > 0)
                {
                    int fuelNeeded = ((int)Math.Floor(mass / 3.0) - 2);
                    if (fuelNeeded > 0)
                        totalFuelNeeded += fuelNeeded;
                    mass = fuelNeeded;
                }

                return totalFuelNeeded;
            }
        }
    }
}