using System;

namespace MyRnD.AdventCode2019.ConsoleApp
{

    public sealed partial class Program
    {
        static void Main(string[] args)
        {
#if false
            Console.WriteLine("PRESS ENTER TO START ...");
            Console.ReadLine();
            Separator(nameof(Program.Day01));
            Day01();

            Separator(nameof(Program.Day02_A));
            Day02_A();
            Separator(nameof(Program.Day02_B));
            Day02_B();

            Separator(nameof(Program.Day03_A));
            Day03_A();
            Separator(nameof(Program.Day03_B));
            Day03_B();

            Separator(nameof(Program.Day04_A));
            Day04_A();
#endif

            Separator(nameof(Program.Day06_A));
            Day06_A();
            Separator(nameof(Program.Day06_B));
            Day06_B();

            Console.WriteLine("PRESS ENTER TO STOP.");
            Console.ReadLine();
        }

        static void Separator(string name)
        {
            Console.WriteLine();
            Console.WriteLine($"***************** {name.ToUpper()} ********************");
        }
    }
}
