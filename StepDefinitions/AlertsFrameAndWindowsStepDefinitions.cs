using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowProject1.Pages;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class AlertsFrameAndWindowsStepDefinitions
    {
        AlertsFrameAndWindowsPage _alertsFrameAndWindowsPage;


        [Given(@"User clicks Alerts, Frame and Windows icon")]
        public void GivenUserClicksAllertsFrameAndWindowsIcon()
        {
            _alertsFrameAndWindowsPage = (AlertsFrameAndWindowsPage)ScenarioContext.Current["AlertsFrameAndWindowsPage"];
            _alertsFrameAndWindowsPage.OpenUrl();
            _alertsFrameAndWindowsPage.ClickTitlesLink(_alertsFrameAndWindowsPage.alertsFrameAndWindowsTitle);
            _alertsFrameAndWindowsPage.ClickConsent();

        }

        [Given(@"User click Browser Windows")]
        public void GivenUserClickBrowserWindows()
        {
            _alertsFrameAndWindowsPage.ClickSection(_alertsFrameAndWindowsPage.SectionElements(_alertsFrameAndWindowsPage.browserWindowsSection));
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

            _alertsFrameAndWindowsPage.ClickSection(_alertsFrameAndWindowsPage.SectionElements(_alertsFrameAndWindowsPage.browserWindowsSection));

        }

        [When(@"User click New Window button")]
        public void WhenUserClickNewWindowButton()
        {
            _alertsFrameAndWindowsPage.ClickButton(_alertsFrameAndWindowsPage.windowButton);
        }


        [Then(@"'(.*)' is displayed in new window")]
        public void ThenIsDisplayedInNewWindow(string expectedText)
        {
            _alertsFrameAndWindowsPage.FocusOnNewWindow();

            Assert.That(expectedText, Is.EqualTo(_alertsFrameAndWindowsPage.GetText()), $"Expected: {expectedText}, Actual: {_alertsFrameAndWindowsPage.GetText()}");
        }
    }
}
