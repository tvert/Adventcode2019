using System.Collections.Generic;
using System.Linq;

namespace MyRnD.AdventCode2019.Parts
{
    public sealed class Rocket
    {
        public Rocket()
            : this(new List<Module>())
        {
        }

        public Rocket(List<Module> modules)
        {
            Modules = modules;
        }

        public List<Module> Modules { get; set; }

        public int FuelCounterUpper
        {
            get
            {
                int total = 0;
                if (Modules != null && Modules.Any())
                {
                    foreach (var module in Modules)
                    {
                        total += module.FuelCounterUpper;
                    }
                }
                return total;
            }
        }

        public int FuelCounterUpper2
        {
            get
            {
                int total = 0;
                if (Modules != null && Modules.Any())
                {
                    foreach (var module in Modules)
                    {
                        total += module.FuelCounterUpper2;
                    }
                }
                return total;
            }
        }

    }
}
