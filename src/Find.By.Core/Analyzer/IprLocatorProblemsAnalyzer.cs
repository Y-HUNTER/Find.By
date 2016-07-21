using Find.By.Core.Validators;
using JetBrains.ReSharper.Daemon.Stages.Dispatcher;
using JetBrains.ReSharper.Feature.Services.Daemon;
using JetBrains.ReSharper.Psi.CSharp.Tree;
using JetBrains.ReSharper.Psi.Tree;

namespace Find.By.Core
{
    [ElementProblemAnalyzer(typeof (IAttribute), HighlightingTypes = new[] {typeof (LocatorErrorHighlighting)})]
    internal class IprLocatorProblemsAnalyzer : ElementProblemAnalyzer<IAttribute>
    {
        protected override void Run(IAttribute element, ElementProblemAnalyzerData data, IHighlightingConsumer consumer)
        {
            Attribute attribute = Attribute.Parse(element);
            if (!attribute.IsLocator) return;
            ILocatorValidator validator = ValidatorFactory.CreateValidator(attribute);
            if (!validator.IsValid)
            {
                consumer.AddHighlighting(new LocatorErrorHighlighting(attribute.ValueExpression, validator.ErrorMessage), element.GetDocumentRange(), element.GetContainingFile());
            }
        }
    }
}