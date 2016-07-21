using Find.By.Core;
using JetBrains.ReSharper.FeaturesTestFramework.Intentions;
using NUnit.Framework;

namespace Find.By.Tests
{
    [TestFixture]
    public class VerifyLocatorInBrowserContextActionTests : CSharpContextActionExecuteTestBase<IprVerifyLocatorInBrowserContextAction>
    {
        protected override string ExtraPath => "VerifyLocatorInBrowserContextActionTests";

        protected override string RelativeTestDataPath => "VerifyLocatorInBrowserContextActionTests";

        [Test]
        public void Test01()
        {
            DoTestFiles("Test01.cs");
        }
    }
}