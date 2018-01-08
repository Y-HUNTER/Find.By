using System;
using Find.By.Core.Attributes;
using JetBrains.Application.Progress;
using JetBrains.ProjectModel;
using JetBrains.ReSharper.Feature.Services.ContextActions;
using JetBrains.ReSharper.Feature.Services.CSharp.Analyses.Bulbs;
using JetBrains.ReSharper.Psi.CSharp.Tree;
using JetBrains.TextControl;
using JetBrains.Util;
using Attribute = Find.By.Core.Attributes.Attribute;

namespace Find.By.Core.ContextAction
{
    [ContextAction(Group = "C#", Name = "Locator verification", Description = "Finding & Verifying locators")]
    public class VerifyLocatorInBrowserContextAction : ContextActionBase
    {
        private ICSharpContextActionDataProvider Provider { get; set; }

        public VerifyLocatorInBrowserContextAction(ICSharpContextActionDataProvider provider)
        {
            Provider = provider;
        }

        protected override Action<ITextControl> ExecutePsiTransaction(ISolution solution, IProgressIndicator progress)
        {
            var attr = Provider.GetSelectedElement<IAttribute>();
            if (attr == null) return null;
            var attribute = Attribute.Parse(attr);
            var locator = LocatorFactory.CreateLocator(attribute.How, attribute.Value);
            Deamon.ShowLocator(locator);
            return null;
        }

        public override string Text => "Highlight element";

        public override bool IsAvailable(IUserDataHolder cache)
        {
            var attr = Provider.GetSelectedElement<IAttribute>();
            if (attr == null) return false;
            var attribute = Attribute.Parse(attr);
            return attribute.IsLocator;
        }
    }
}
