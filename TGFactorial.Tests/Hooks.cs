using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace TGFactorial.Tests
{
    [Binding]
    public class Hooks
    {
        [Before]
        public void CreateWebDriver(ScenarioContext context)
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            IWebDriver webDriver = new ChromeDriver(options);
            context["WEB_DRIVER"] = webDriver;
        }

        [After]
        public void CloseWebDriver(ScenarioContext context)
        {
            IWebDriver driver = context["WEB_DRIVER"] as IWebDriver;
            driver.Quit();
        }
    }
}
