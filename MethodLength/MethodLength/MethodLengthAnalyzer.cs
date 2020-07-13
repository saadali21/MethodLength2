using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace MethodLength
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)] // Every diagnostic analyzer must provide this attribute that describes the language it operates on.
    public class MethodLengthAnalyzer : DiagnosticAnalyzer // Every diagnostic analyzer must derive from the DiagnosticAnalyzer class.
    {
        public const string DiagnosticId = "Method_length_60";

        private static readonly LocalizableString Title = new LocalizableResourceString(nameof(Resources.AnalyzerTitle), Resources.ResourceManager, typeof(Resources));
        private static readonly LocalizableString MessageFormat = new LocalizableResourceString(nameof(Resources.AnalyzerMessageFormat), Resources.ResourceManager, typeof(Resources));
        private static readonly LocalizableString Description = new LocalizableResourceString(nameof(Resources.AnalyzerDescription), Resources.ResourceManager, typeof(Resources));
        private const string Category = "Usage";

        private static readonly DiagnosticDescriptor Rule = new DiagnosticDescriptor(DiagnosticId, Title, MessageFormat, Category, DiagnosticSeverity.Warning, isEnabledByDefault: true, description: Description);

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(Rule);

        public override void Initialize(AnalysisContext context)
        {
            context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.Analyze | GeneratedCodeAnalysisFlags.None);
            context.EnableConcurrentExecution(); // better performance, ensure that all actions can execute in parallel.

            // The actions represent code changes that should trigger the analyzer to examine code for violations.
            // When Visual Studio detects code edits that match a registered action, it calls the analyzer's registered method.
            context.RegisterSyntaxNodeAction(AnalyzeNode, SyntaxKind.MethodDeclaration);
        }

        private static void AnalyzeNode(SyntaxNodeAnalysisContext context)
        {
            var localDeclaration = (MethodDeclarationSyntax)context.Node;
            
            var lineSpan = localDeclaration.SyntaxTree.GetMappedLineSpan(localDeclaration.Span);
            var lines = lineSpan.EndLinePosition.Line - lineSpan.StartLinePosition.Line + 1; // span is not including the leading and trailing trivia

            if (lines < 60)
            {
                return;
            }

            // When the analyzer detects a violation, it creates a diagnostic object that Visual Studio uses to notify the user of the violation.
            context.ReportDiagnostic(Diagnostic.Create(Rule, context.Node.GetLocation()));
        }
    }
}
