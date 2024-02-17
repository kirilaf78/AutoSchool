using OpenQA.Selenium;
using SpecFlowProject1.Drivers;
using TechTalk.SpecFlow;
using System;
using SpecFlowProject1.Pages;

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
            var commonPage = new Pages.CommonPage(_webDriver);
            var alertsFrameAndWindowsPage = new Pages.AlertsFrameAndWindowsPage(_webDriver);

            ScenarioContext.Current["WebDriver"] = _webDriver;
            ScenarioContext.Current["ElementsPage"] = elementsPage;
            ScenarioContext.Current["CommonPage"] = commonPage;
            ScenarioContext.Current["AlertsFrameAndWindowsPage"] = alertsFrameAndWindowsPage;


        }

        [AfterScenario]
        public void AfterScenario()
        {
            _webDriver?.Quit();
        }
    }
}