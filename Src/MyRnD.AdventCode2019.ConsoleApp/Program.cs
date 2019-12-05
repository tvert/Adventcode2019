using System;

namespace MyRnD.AdventCode2019.ConsoleApp
{

    public sealed partial class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("PRESS ENTER TO START ...");
            Console.ReadLine();
#if false
            Separator(nameof(Program.Day01));
            Day01();

            Separator(nameof(Program.Day02_A));
            Day02_A();
            Separator(nameof(Program.Day02_B));
            Day02_B();
#endif
            Separator(nameof(Program.Day03_A));
            Day03_A();

            Separator(nameof(Program.Day03_B));
            Day03_B();

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
