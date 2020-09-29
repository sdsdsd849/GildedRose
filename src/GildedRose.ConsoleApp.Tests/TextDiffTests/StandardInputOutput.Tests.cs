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
            var expectedOutput = new StringBuilder(File.ReadAllText(Path.Combine(nameof(TextDiffTests), "StandardInputOutput.ThirtyOneDay.approved.txt")));
            Console.SetOut(new StringWriter());
            Console.SetIn(new StringReader("a\n"));
            Program.Main();
            Approvals.Verify(expectedOutput.ToString());
        }
    }
}
