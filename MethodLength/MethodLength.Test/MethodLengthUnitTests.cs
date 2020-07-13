using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestHelper;

namespace MethodLength.Test
{
    [TestClass]
    public class UnitTest : CodeFixVerifier
    {
        [TestMethod]
        public void Should_Not_Trigger_Diagnostics()
        {
            var test = @"class Program
    {
        static void Main(string[] args)
        {
            int x2 = 0;
            Console.WriteLine(x2);
            Console.WriteLine(x2);
            Console.WriteLine(x2);
            Console.WriteLine(x2);
            Console.WriteLine(x2);
            Console.WriteLine(x2);
            Console.WriteLine(x2);
            Console.WriteLine(x2);
            Console.WriteLine(x2);
            Console.WriteLine(x2);
            Console.WriteLine(x2);
            Console.WriteLine(x2);
            Console.WriteLine(x2);
            Console.WriteLine(x2);
            Console.WriteLine(x2);           
            Console.WriteLine(x2);
            Console.WriteLine(x2);
        }
    }";

            VerifyCSharpDiagnostic(test);
        }

        [TestMethod]
        public void Should_Trigger_Diagnostics_With_Correct_Info()
        {
            var test = @"class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(""Hello World!"");
            int x2 = 0;
            Console.WriteLine(x2);
            Console.WriteLine(x2);
            Console.WriteLine(x2);
            Console.WriteLine(x2);
            Console.WriteLine(x2);
            Console.WriteLine(x2);
            Console.WriteLine(x2);
            Console.WriteLine(x2);
            Console.WriteLine(x2);
            Console.WriteLine(x2);
            Console.WriteLine(x2);
            Console.WriteLine(x2);
            Console.WriteLine(x2);
            Console.WriteLine(x2);
            Console.WriteLine(x2);
            Console.WriteLine(x2);
            Console.WriteLine(x2);
            Console.WriteLine(x2);
            Console.WriteLine(x2);
            Console.WriteLine(x2);
            Console.WriteLine(x2);
            Console.WriteLine(x2);
            Console.WriteLine(x2);
            Console.WriteLine(x2);
            Console.WriteLine(x2);
            Console.WriteLine(x2);
            Console.WriteLine(x2);
            Console.WriteLine(x2);
            Console.WriteLine(x2);
            Console.WriteLine(x2);
            Console.WriteLine(x2);
            Console.WriteLine(x2);
            Console.WriteLine(x2);
            Console.WriteLine(x2);
            Console.WriteLine(x2);
            Console.WriteLine(x2);
            Console.WriteLine(x2);
            Console.WriteLine(x2);
            Console.WriteLine(x2);
            Console.WriteLine(x2);
            Console.WriteLine(x2);
            Console.WriteLine(x2);
            Console.WriteLine(x2);
            Console.WriteLine(x2);
            Console.WriteLine(x2);
            Console.WriteLine(x2);
            Console.WriteLine(x2);
            Console.WriteLine(x2);
            Console.WriteLine(x2);
            Console.WriteLine(x2);
            Console.WriteLine(x2);
            Console.WriteLine(x2);
            Console.WriteLine(x2);
            Console.WriteLine(x2);
            Console.WriteLine(x2);
            Console.WriteLine(x2);
            Console.WriteLine(x2);
            Console.WriteLine(x2);
            Console.WriteLine(x2);
            Console.WriteLine(x2);
        }
    }";
            var expected = new DiagnosticResult
            {
                Id = "Method_length_60",
                Message = "Method length should be less than 60 lines.",
                Severity = DiagnosticSeverity.Warning,
                Locations =
                    new[] {
                            new DiagnosticResultLocation("Test0.cs", 3, 9)
                        }
            };

            VerifyCSharpDiagnostic(test, expected);
        }

        protected override DiagnosticAnalyzer GetCSharpDiagnosticAnalyzer()
        {
            return new MethodLengthAnalyzer();
        }
    }
}
