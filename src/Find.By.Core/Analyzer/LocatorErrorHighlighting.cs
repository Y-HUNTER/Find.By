using System;
using JetBrains.DocumentModel;
using JetBrains.ReSharper.Feature.Services.Daemon;
using JetBrains.ReSharper.Psi.CSharp;
using JetBrains.ReSharper.Psi.CSharp.Tree;

namespace Find.By.Core.Analyzer
{
    [StaticSeverityHighlighting(Severity.ERROR, CSharpLanguage.Name)]
    public class LocatorErrorHighlighting : IHighlighting
    {
        public LocatorErrorHighlighting(ICSharpLiteralExpression literal, string toolTips)
        {
            Literal = literal;
            ToolTip = toolTips;
            ErrorStripeToolTip = string.Empty;
        }

        private ICSharpLiteralExpression Literal { get; }

        public bool IsValid()
        {
            return Literal != null && Literal.IsValid();
        }

        public DocumentRange CalculateRange()
        {
            throw new NotImplementedException();
        }

        public string ToolTip { get; }
        public string ErrorStripeToolTip { get; }
    }
}
