using NUnit.Framework;
using SpecFlowProject1.Drivers;
using SpecFlowProject1.Pages;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class WidgetsStepDefinitions
    {
        private DriverHelper _webDriver;
        WidgetsPage _widgetsPage;


        public WidgetsStepDefinitions(DriverHelper webDriver)
        {
            _webDriver = webDriver;
            _widgetsPage = new WidgetsPage(_webDriver.Driver);

        }

        [Given(@"User clicks Widgets icon")]
        public void GivenUserClicksWidgetsIcon()
        {
            _widgetsPage.OpenUrl();
            _widgetsPage.ClickTitlesLink(_widgetsPage.widgetsTitle);
            _widgetsPage.ClickConsent();
        }

        [Given(@"User navigates to Auto Complete section")]
        public void GivenUserNavigatesToAutoCompleteSection()
        {
            _widgetsPage.ClickSection(_widgetsPage.SectionElements(_widgetsPage.autoCompleteSection));

        }

        [When(@"User enters '(.*)' in the Type multiple color names field")]
        public void WhenUserEntersInTheTypeMultipleColorNamesField(string g)
        {
            // Thread.Sleep(3000);
            _widgetsPage.ScrollDown(300);
            _widgetsPage.TypeLetter(_widgetsPage.multiColorInput, g);
            // Thread.Sleep(5000);
        }

        [Then(@"There are three suggestions displayed with each containing the letter '(.*)'")]
        public void ThenThereAreThreeSuggestionsDisplayedWithEachContainingTheLetter(string g)
        {
            Assert.Multiple(() =>
            {
                Assert.That(_widgetsPage.AutoCompleteOptions.Count, Is.EqualTo(3));
                Assert.That(_widgetsPage.DoesContainLetter(g), Is.True);

            });
        }

        [When(@"User enters the colors: Red, Yellow, Green, Blue, and Purple")]
        public void WhenUserEntersTheColorsRedYellowGreenBlueAndPurple()
        {
        }

        [When(@"User removes Yellow and Purple")]
        public void WhenUserRemovesYellowAndPurple()
        {
        }

        [Then(@"Only Red, Green, and Blue are displayed in the field")]
        public void ThenOnlyRedGreenAndBlueAreDisplayedInTheField()
        {
        }

        [Given(@"User navigates to Progress Bar section")]
        public void GivenUserNavigatesToProgressBarSection()
        {
        }

        [When(@"User clicks on Start and waits for the progress to reach (.*)%")]
        public void WhenUserClicksOnStartAndWaitsForTheProgressToReach(int p0)
        {
        }

        [Then(@"The button label changes to Reset")]
        public void ThenTheButtonLabelChangesToReset()
        {
        }

        [Then(@"User clicks on Reset")]
        public void ThenUserClicksOnReset()
        {
        }

        [Then(@"The button label changes back to Start")]
        public void ThenTheButtonLabelChangesBackToStart()
        {
        }

        [Then(@"The progress bar value is reset to (.*)%")]
        public void ThenTheProgressBarValueIsResetTo(int p0)
        {
        }
    }
}
