using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MyRnD.AdventCode2019.D02.IntCode
{
    public sealed class Program
    {
        private const string DefaultFilename = @"IntCode-Program1.txt";
        //private const string DefaultFilename = "IntCode-Program2-MyInput.txt";

        static void Main(string[] args)
        {
            try
            {
                string fullFilename = Path.Combine(Environment.CurrentDirectory, DefaultFilename);
                Console.WriteLine();
                Console.WriteLine($"Loading IntCode data from '{fullFilename}'...");
                Console.WriteLine();

                var intCodeComputer = Factory.GetIntCodeComputerFromFile(fullFilename);
                Console.WriteLine($"There are #{intCodeComputer.InitialOpCodes.Count} Op codes in this IntCode program.");
                Console.WriteLine();

                var finalOpCodes = intCodeComputer.Run();
                Console.WriteLine($"The value left at position 0 is '{finalOpCodes[0]}' after running the IntCode program.");
                Console.WriteLine();

                int expectedOutput = 19690720;
                (int noun, int verb) = intCodeComputer.FindNounAndVerbForOutput(expectedOutput);
                Console.WriteLine();
                Console.WriteLine($"The expected value '{expectedOutput}' can be compute with noun='{noun}' and verb='{verb}' ({noun:00}{verb:00}).");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured '{ex.Message}'.{Environment.NewLine}Details: '{ex}'");
            }
        }
    }

    public sealed class IntCodeComputer
    {
        // OpCode 4 set structure : [OpCode, Input1, Input2, Output]
        public const int OpCodeIndex = 0;
        public const int Input1Index = 1;
        public const int Input2Index = 2;
        public const int OutputIndex = 3;

        public const int OperationLength = 4;

        public IntCodeComputer(List<int> initialOpCodes)
        {
            InitialOpCodes = initialOpCodes;
        }

        public List<int> InitialOpCodes { get; private set; }

        public List<int> Run()
        {
            List<int> opCodes = InitialOpCodes.ToList();
            return RunInternal(opCodes, 0);
        }

        public List<int> RunInternal(List<int> opCodes, int OpCodeCurrentIndex)
        {
            int[] currentOperation = new int[OperationLength];
            for (int s = OpCodeCurrentIndex, t = 0; s < OpCodeCurrentIndex + OperationLength; s++, t++)
            {
                currentOperation[t] = opCodes[s];
            }

            var currentOpCode = currentOperation[OpCodeIndex];
            if (currentOpCode.IsFinalOp())
            {
                // We reach the end
                return opCodes;
            }
            if (currentOpCode.IsAddOp())
            {
                var input1 = opCodes[currentOperation[Input1Index]];
                var input2 = opCodes[currentOperation[Input2Index]];
                var result = input1 + input2;
                var outputIndex = currentOperation[OutputIndex];
                opCodes[outputIndex] = result;
            }
            else if (currentOpCode.IsMultiplyOp())
            {
                var input1 = opCodes[currentOperation[Input1Index]];
                var input2 = opCodes[currentOperation[Input2Index]];
                var result = input1 * input2;
                var outputIndex = currentOperation[OutputIndex];
                opCodes[outputIndex] = result;
            }
            else
            {
                throw new InvalidOperationException($"Unknown OpCode '{currentOpCode}' at position '{OpCodeCurrentIndex}' " +
                                                    $"(Current Operation: [{currentOperation[0]}, {currentOperation[1]}, {currentOperation[2]}, {currentOperation[3]}]).");
            }

            return RunInternal(opCodes, OpCodeCurrentIndex + OperationLength);
        }

        public (int noun, int verb) FindNounAndVerbForOutput(int expectedOutput)
        {
            int nounValue = 0;
            int verbValue = 0;
            const int NounIndex = 1;
            const int verbIndex = 2;

            for (int n = 0; n < 100; n++)
            {
                for (int v = 0; v < 100; v++)
                {
                    List<int> opCodes = InitialOpCodes.ToList();
                    opCodes[1] = n;
                    opCodes[2] = v;
                    var result = RunInternal(opCodes, 0);
                    if (result[0] == expectedOutput)
                        return (n, v);
                }
            }
            return (-1, -1);
        }
    }

    public static class IntExtensions
    {
        // OpCodes
        public const int OpCodeAdd = 1;
        public const int OpCodeMultiply = 2;
        public const int OpCodeFinal = 99;

        public static bool IsAddOp(this int opCode)
        {
            return opCode == OpCodeAdd;
        }
        public static bool IsMultiplyOp(this int opCode)
        {
            return opCode == OpCodeMultiply;
        }
        public static bool IsFinalOp(this int opCode)
        {
            return opCode == OpCodeFinal;
        }
    }

    public abstract class Factory
    {
        const int BufferSize = 1024;

        public static IntCodeComputer GetIntCodeComputerFromFile(string fullFileName)
        {
            List<int> opCodes = new List<int>();
            using (var fileStream = File.OpenRead(fullFileName))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    // line has only one value
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        var opCodesTextInLine = line.Split(',');
                        var opCodesInLine = opCodesTextInLine.Select(int.Parse).ToList();
                        opCodes.AddRange(opCodesInLine);
                    }
                }
            }
            var tempIntCodeComputer = new IntCodeComputer(opCodes.ToList());
            return tempIntCodeComputer;
        }
    }

}
