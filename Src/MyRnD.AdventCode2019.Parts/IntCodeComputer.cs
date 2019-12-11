using MyRnD.AdventCode2019.Parts.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyRnD.AdventCode2019.Parts
{
    public interface IInputter
    {
        int InputValue();
    }
    public interface IOutputter
    {
        void OutputValue(int valueToOutput);
    }

    #region Inputters & Outputters

    public sealed class ConsoleInputer : IInputter
    {
        public int InputValue()
        {
            return int.Parse(Console.ReadLine() ?? throw new InvalidOperationException("Unable to capture from an integer from the console."));
        }
    }

    public sealed class AutoInputer : IInputter
    {
        public int AutoValue { get; set; }

        public int InputValue()
        {
            return AutoValue;
        }
    }

    public sealed class ConsoleOutputter : IOutputter
    {
        public void OutputValue(int valueToOutput)
        {
            Console.WriteLine($"[Value: {valueToOutput} ]");
        }
    }

    #endregion

    public sealed class IntCodeComputer
    {
        // OpCode 4 set structure : [OpCode, Input1, Input2, Output]
        public const int OpCodeIndex = 0;
        public const int Input1Index = 1;
        public const int Input2Index = 2;
        public const int OutputIndex = 3;

        public const int OperationLength = 4;


        // Fields
        private readonly IInputter _inputter;
        private readonly IOutputter _outputter;

        public IntCodeComputer(List<int> initialIntCodes)
            : this(initialIntCodes, new AutoInputer {AutoValue = 0}, new ConsoleOutputter())
        {
        }

        public IntCodeComputer(List<int> initialIntCodes, IInputter inputter)
            : this(initialIntCodes, inputter, new ConsoleOutputter())
        {
        }

        public IntCodeComputer(List<int> initialIntCodes, IInputter inputter, IOutputter outputter)
        {
            InitialIntCodes = initialIntCodes;
            _inputter = inputter;
            _outputter = outputter;
        }

        public List<int> InitialIntCodes { get; private set; }

        public List<int> Run()
        {
            List<int> opCodes = InitialIntCodes.ToList();
            (List<int> intCodes, _) = RunInternal(opCodes, 0);
            return intCodes;
        }

        public (int noun, int verb) FindNounAndVerbForOutput(int expectedOutput)
        {
            // Noun and verb can range from 00 to 99.
            // Brute force approach: iterate through both range until finding the expected value.
            for (int nounIndex = 0; nounIndex < 100; nounIndex++)
            {
                for (int verbIndex = 0; verbIndex < 100; verbIndex++)
                {
                    List<int> opCodes = InitialIntCodes.ToList();
                    opCodes[1] = nounIndex;
                    opCodes[2] = verbIndex;
                    (List<int> result, _) = RunInternal(opCodes, 0);
                    if (result[0] == expectedOutput)
                        return (nounIndex, verbIndex);
                }
            }
            return (-1, -1);
        }

        #region Helpers

        private (List<int> intCodes, int newInstructionIndex) RunInternal(List<int> intCodes, int currentInstructionIndex)
        {
            int newInstructionIndex = currentInstructionIndex;
            int currentInstruction = intCodes[currentInstructionIndex];
            // The rightmost 2 digits.
            int currentOpCode = currentInstruction % 100;
            // Then going right to left, the parameter modes are 0 (hundreds digit), 1 (thousands digit), and 0 (ten-thousands digit, not present and therefore zero)
            int parameterMode1 = (currentInstruction / 100) % 10;
            int parameterMode2 = (currentInstruction / 1000) % 10;
            int parameterMode3 = (currentInstruction / 10000) % 10;

            if (currentOpCode.IsFinalOp())
            {
                // We reach the end
                return (intCodes, newInstructionIndex);
            }
            if (currentOpCode.IsAddOp() || currentOpCode.IsMultiplyOp())
            {
                int input1 = parameterMode1.IsPositionMode()
                    ? intCodes[intCodes[currentInstructionIndex + 1]]
                    : intCodes[currentInstructionIndex + 1];
                int input2 = parameterMode2.IsPositionMode()
                    ? intCodes[intCodes[currentInstructionIndex + 2]]
                    : intCodes[currentInstructionIndex + 2];
                int result;
                if (currentOpCode.IsAddOp())
                    result = input1 + input2;
                else
                    result = input1 * input2;
                var outputIndex = intCodes[currentInstructionIndex + 3];
                intCodes[outputIndex] = result;
                newInstructionIndex += 4; // opCode + Input1 + Input2 + Output
            }
            else if (currentOpCode.IsInputOp())
            {
                var storeInputAtIndex = intCodes[currentInstructionIndex + 1];
                var result = _inputter.InputValue();
                intCodes[storeInputAtIndex] = result;
                newInstructionIndex += 2; // opCode + Index
            }
            else if (currentOpCode.IsOutputOp())
            {
                int outputValue = parameterMode1.IsPositionMode()
                    ? intCodes[intCodes[currentInstructionIndex + 1]]
                    : intCodes[currentInstructionIndex + 1];
                _outputter.OutputValue(outputValue);
                newInstructionIndex += 2; // opCode + Index
            }
            else
            {
                throw new InvalidOperationException($"Unknown OpCode '{currentOpCode}' at position '{currentInstructionIndex}' " +
                                                    $"(Current instruction: [{currentInstruction}, ParamMode1: {parameterMode1}, ParamMode2: {parameterMode2}, ParamMode3: {parameterMode3}]).");
            }

            return RunInternal(intCodes, newInstructionIndex);
        }

        #endregion
    }
}