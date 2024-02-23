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
            _widgetsPage.ScrollDown(300);
            _widgetsPage.TypeLetter(_widgetsPage.multiColorInput, g);
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
            _widgetsPage.EnterColor(_widgetsPage.colors);


        }

        [When(@"User removes Yellow and Purple")]
        public void WhenUserRemovesYellowAndPurple()
        {
            _widgetsPage.RemoveColors();
        }

        [Then(@"Only Red, Green, and Blue are displayed in the field")]
        public void ThenOnlyRedGreenAndBlueAreDisplayedInTheField()
        {
            Assert.That(_widgetsPage.VerifyRemainingColors(), Is.True);
        }

        [Given(@"User navigates to Progress Bar section")]
        public void GivenUserNavigatesToProgressBarSection()
        {
            _widgetsPage.ScrollDown(200);
            // Thread.Sleep(5000);

            _widgetsPage.ClickSection(_widgetsPage.SectionElements(_widgetsPage.progressBarSection));

        }

        [When(@"User clicks on Start and waits for the progress to reach '(.*)'")]
        public void WhenUserClicksOnStartAndWaitsForTheProgressToReach(string percent)
        {
            _widgetsPage.ClickButton(_widgetsPage.Buttons(_widgetsPage.startStopButton));
            _widgetsPage.WaitForCompletion(percent);
            Console.WriteLine(_widgetsPage.GetText(_widgetsPage.ProgressBar));
        }


        [Then(@"The button label changes to '(.*)'")]
        public void ThenTheButtonLabelChangesTo(string reset)
        {
            Assert.That(_widgetsPage.GetText(_widgetsPage.Buttons(_widgetsPage.resetButton)) == reset);
        }

        [Then(@"User clicks on Reset")]
        public void ThenUserClicksOnReset()
        {
            _widgetsPage.ClickButton(_widgetsPage.Buttons(_widgetsPage.resetButton));
            Thread.Sleep(3000);
        }

        [Then(@"The button label changes back to '(.*)'")]
        public void ThenTheButtonLabelChangesBackTo(string start)
        {
            Assert.That(_widgetsPage.GetText(_widgetsPage.Buttons(_widgetsPage.startStopButton)) == start);
        }

        [Then(@"The progress bar value is reset to '(.*)'")]
        public void ThenTheProgressBarValueIsResetTo(string percent)
        {
           //_widgetsPage.WaitForCompletion(percent);

            Assert.That(_widgetsPage.GetText(_widgetsPage.ProgressBar) == percent, $"Actual: {_widgetsPage.GetText(_widgetsPage.ProgressBar)}, expected: {percent}"); 
        }
    }
}