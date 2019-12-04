using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MyRnD.AdventCode2019.Parts.Tests
{
    [TestClass]
    public class BoolTests
    {
        [TestMethod]
        public void Bool_TryParse_DifferentValues()
        {
            string[] values = { null, String.Empty, "True", "False",
                "true", "false", "    true    ", "0",
                "1", "-1", "string" };
            foreach (var value in values)
            {
                bool flag;
                if (Boolean.TryParse(value, out flag))
                    Console.WriteLine("'{0}' --> {1}", value, flag);
                else
                    Console.WriteLine("Unable to parse '{0}' flag: '{1}'.",
                        value == null ? "<null>" : value, flag);
            }
        }
    }
}