using OpenQA.Selenium;
using SpecFlowProject1.Drivers;
using TechTalk.SpecFlow;
using System;

namespace SpecFlowProject1.Hooks
{
    [Binding]
    public class Hooks
    {
        private IWebDriver _webDriver;

        [BeforeScenario]
        public void BeforeScenario()
        {
            _webDriver = WebDriverFactory.CreateWebDriver();

            var elementsPage = new Pages.ElementsPage(_webDriver);

            ScenarioContext.Current["WebDriver"] = _webDriver;
            ScenarioContext.Current["ElementsPage"] = elementsPage;
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _webDriver?.Quit();
        }
    }
}