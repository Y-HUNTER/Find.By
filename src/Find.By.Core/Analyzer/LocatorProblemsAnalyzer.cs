using Find.By.Core.Attributes;
using Find.By.Core.Validators;
using JetBrains.ReSharper.Feature.Services.Daemon;
using JetBrains.ReSharper.Psi.CSharp.Tree;
using JetBrains.ReSharper.Psi.Tree;

namespace Find.By.Core.Analyzer
{
    [ElementProblemAnalyzer(typeof(IAttribute), HighlightingTypes = new[] { typeof(LocatorErrorHighlighting) })]
    public class LocatorProblemsAnalyzer : ElementProblemAnalyzer<IAttribute>
    {
        protected override void Run(IAttribute element, ElementProblemAnalyzerData data, IHighlightingConsumer consumer)
        {
            Attribute attribute = Attribute.Parse(element);
            if (!attribute.IsLocator) return;
            ILocatorValidator validator = ValidatorFactory.CreateValidator(attribute);
            if (!validator.IsValid)
            {
                var locatorErrorHighlighting = new LocatorErrorHighlighting(attribute.ValueExpression, validator.ErrorMessage);
                consumer.AddHighlighting(locatorErrorHighlighting, element.GetDocumentRange());
            }
        }
    }
}
