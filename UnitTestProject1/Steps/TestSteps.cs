using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace UnitTestProject1.Steps
{
    [Binding]
    public class TestSteps
    {
        private int firstNumber;
        private int secondNumber;
        private int actualSum;

        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int number)
        {
            firstNumber = number;
        }

        [Given(@"I have also entered (.*) into the calculator")]
        public void GivenIHaveAlsoEnteredIntoTheCalculator(int number)
        {
            secondNumber = number;
        }

        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            actualSum = firstNumber + secondNumber;
        }

        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int expectedSum)
        {
            Assert.AreEqual(expectedSum, actualSum);
        }

    }
}
