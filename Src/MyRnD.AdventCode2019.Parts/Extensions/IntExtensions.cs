namespace MyRnD.AdventCode2019.Parts.Extensions
{
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
}