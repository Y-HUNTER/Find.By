using System;
using Find.By.Server;
using JetBrains.Application.Progress;
using JetBrains.ProjectModel;
using JetBrains.ReSharper.Feature.Services.ContextActions;
using JetBrains.ReSharper.Feature.Services.CSharp.Analyses.Bulbs;
using JetBrains.ReSharper.Psi.CSharp.Tree;
using JetBrains.TextControl;
using JetBrains.Util;

namespace Find.By.Core
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
            IAttribute attr = Provider.GetSelectedElement<IAttribute>();
            if (attr == null) return null;
            Attribute attribute = Attribute.Parse(attr);
            Locator locator = LocatorFactory.CreateLocator(attribute.How, attribute.Value);
            Deamon.ShowLocator(locator);
            return null;
        }

        public override string Text => "Highlight element";

        public override bool IsAvailable(IUserDataHolder cache)
        {
            IAttribute attr = Provider.GetSelectedElement<IAttribute>();
            if (attr == null) return false;
            Attribute attribute = Attribute.Parse(attr);
            return attribute.IsLocator;
        }
    }
}
