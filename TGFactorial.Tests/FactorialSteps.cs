using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using TechTalk.SpecFlow;
using Xunit;

namespace TGFactorial.Tests
{
    [Binding]
    public class FactorialSteps
    {
        private readonly IWebDriver _webDriver;

        public FactorialSteps(ScenarioContext scenarioContext)
        {
            _webDriver = scenarioContext["WEB_DRIVER"] as IWebDriver;
        }

        [Given(@"I navigate to factorial calculator")]
        public void GivenINavigateToFactorialCalculator()
        {
            _webDriver.Url = $"https://qa-test-app.transfergo.rocks/index.php/";
        }

        [Given(@"enter (.*) into the calculator")]
        public void GivenEnterIntoTheCalculator(string input)
        {
            _webDriver.FindElement(By.Id("number")).SendKeys(input);
        }

        [When(@"I click Calculate! button")]
        public void WhenIClickCalculateButton()
        {
            _webDriver.FindElement(By.Id("getFactorial")).Click();
        }

        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(string expected)
        {
            IWebElement resultElement = _webDriver.FindElement(By.Id("resultDiv"));
            WebDriverWait wait = new WebDriverWait(_webDriver, new TimeSpan(0, 0, 3));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElement(resultElement, "factorial"));
            string actual = resultElement.Text.Split(" ").Last();
            Assert.Equal(expected, actual);
        }

        [Then(@"the (.*) should be displayed")]
        public void ThenTheShouldBeDisplayed(string expected)
        {
            IWebElement resultElement = _webDriver.FindElement(By.Id("resultDiv"));
            WebDriverWait wait = new WebDriverWait(_webDriver, new TimeSpan(0, 0, 3));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElement(resultElement, expected));
        }
    }
}
