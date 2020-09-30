using System;
using System.IO;
using System.Text;
using ApprovalTests;
using ApprovalTests.Reporters;
using Xunit;

namespace GildedRose.ConsoleApp.Tests.TextDiffTests
{
    [Collection("Tests used to check if there is any difference between considered 'OK' output and the actual one after refactoring")]
    [UseReporter(typeof(DiffReporter))]
    public class StandardInputOutput
    {
        [Fact]
        public void ThirtyOneDay()
        {
            var consoleOutput = new StringBuilder();
            Console.SetOut(new StringWriter(consoleOutput));
            Console.SetIn(new StringReader("a\n"));
            Program.Main();
            Approvals.Verify(consoleOutput);
        }
    }
}
