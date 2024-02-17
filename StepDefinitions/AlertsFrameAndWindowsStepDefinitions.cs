using NUnit.Framework;
using SpecFlowProject1.Pages;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class AlertsFrameAndWindowsStepDefinitions
    {
        CommonPage _commonPage;
        AlertsFrameAndWindowsPage _alertsFrameAndWindowsPage;

        [Given(@"User clicks Alerts, Frame and Windows icon")]
        public void GivenUserClicksAllertsFrameAndWindowsIcon()
        {
            _commonPage = (CommonPage)ScenarioContext.Current["CommonPage"];
            _commonPage.OpenUrl();
            _commonPage.ClickTitlesLink(_commonPage.alertsFrameAndWindowsTitle);
            _commonPage.ClickConsent();
        }

        [Given(@"User click Browser Windows")]
        public void GivenUserClickBrowserWindows()
        {
            _alertsFrameAndWindowsPage = (AlertsFrameAndWindowsPage)ScenarioContext.Current["AlertsFrameAndWindowsPage"];
            _commonPage.ClickSection(_commonPage.SectionElements(_alertsFrameAndWindowsPage.browserWindowsSection));
            // Thread.Sleep(5000);
        }

        [When(@"User click New Tab button")]
        public void WhenUserClickNewTabButton()
        {
            _alertsFrameAndWindowsPage.ClickButton(_alertsFrameAndWindowsPage.tabButton);

        }

        [Then(@"'(.*)' is displayed in new tab")]
        public void ThenIsDisplayedInNewTab(string expectedText)
        {
            _alertsFrameAndWindowsPage.FocusOnNewTab();

            Assert.That(expectedText, Is.EqualTo(_alertsFrameAndWindowsPage.GetText()), $"Expected: {expectedText}, Actual: {_alertsFrameAndWindowsPage.GetText()}");

        }

        [Given(@"Browser Windows was clicked")]
        public void GivenBrowserWindowsWasClicked()
        {
        }

        [Then(@"""([^""]*)"" is displayed in new window")]
        public void ThenIsDisplayedInNewWindow(string p0)
        {
        }
    }
}
