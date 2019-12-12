namespace MyRnD.AdventCode2019.Parts.Extensions
{
    public static class IntExtensions
    {
        #region OpCodes

        // OpCodes
        public const int OpCodeAdd = 1;
        public const int OpCodeMultiply = 2;
        public const int OpCodeInput = 3;
        public const int OpCodeOutput = 4;
        public const int OpCodeJumpIfTrue = 5;
        public const int OpCodeJumpIfFalse = 6;
        public const int OpCodeJumpLessThan = 7;
        public const int OpCodeEquals = 8;
        public const int OpCodeFinal = 99;


        public static bool IsAddOp(this int opCode)
        {
            return opCode == OpCodeAdd;
        }

        public static bool IsMultiplyOp(this int opCode)
        {
            return opCode == OpCodeMultiply;
        }

        public static bool IsInputOp(this int opCode)
        {
            return opCode == OpCodeInput;
        }

        public static bool IsOutputOp(this int opCode)
        {
            return opCode == OpCodeOutput;
        }

        public static bool IsJumpIfTrueOp(this int opCode)
        {
            return opCode == OpCodeJumpIfTrue;
        }
        public static bool IsJumpIfFalseOp(this int opCode)
        {
            return opCode == OpCodeJumpIfFalse;
        }
        public static bool IsJumpLessThanOp(this int opCode)
        {
            return opCode == OpCodeJumpLessThan;
        }
        public static bool IsEqualsOp(this int opCode)
        {
            return opCode == OpCodeEquals;
        }

        public static bool IsFinalOp(this int opCode)
        {
            return opCode == OpCodeFinal;
        }

        #endregion

        #region Parameter Mode

        public const int PositionMode  = 0;
        public const int ImmediateMode = 1;

        public static bool IsPositionMode(this int parameterMode)
        {
            return parameterMode == PositionMode;
        }

        public static bool IsImmediateMode(this int parameterMode)
        {
            return parameterMode == ImmediateMode;
        }

        #endregion
    }
}