using MyRnD.AdventCode2019.Parts;
using System;
using System.IO;

namespace MyRnD.AdventCode2019.ConsoleApp
{

    public sealed partial class Program
    {
        static void Main(string[] args)
        {
            Separator(nameof(Program.Day01));
            Day01();

            Separator(nameof(Program.Day02_A));
            Day02_A();
            Separator(nameof(Program.Day02_B));
            Day02_B();
        }

        static void Separator(string name)
        {
            Console.WriteLine();
            Console.WriteLine($"***************** {name.ToUpper()} ********************");
        }
    }

}
