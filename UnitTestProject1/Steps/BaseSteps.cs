using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using UnitTestsMail;


namespace UnitTestProject1.Steps
{
    [Binding]
    public class BaseSteps
    {
        [SetUp]
        public virtual void SetUp()
        {
            WebDriverUtil.GetInstance().Manage().Window.Maximize();
        }

        [TearDown]
        public virtual void TearDown()
        {
            WebDriverUtil.DisposeDriver();
        }
    }
}
