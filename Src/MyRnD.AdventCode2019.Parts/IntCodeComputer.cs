using MyRnD.AdventCode2019.Parts.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyRnD.AdventCode2019.Parts
{
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
            // Noun and verb can range from 00 to 99.
            // Brute force approach: iterate through both range until finding the expected value.
            for (int nounIndex = 0; nounIndex < 100; nounIndex++)
            {
                for (int verbIndex = 0; verbIndex < 100; verbIndex++)
                {
                    List<int> opCodes = InitialOpCodes.ToList();
                    opCodes[1] = nounIndex;
                    opCodes[2] = verbIndex;
                    var result = RunInternal(opCodes, 0);
                    if (result[0] == expectedOutput)
                        return (nounIndex, verbIndex);
                }
            }
            return (-1, -1);
        }
    }
}