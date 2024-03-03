using SpecFlowProject1.Drivers;
using SpecFlowProject1.Pages;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class FormsStepDefinitions
    {
        private DriverHelper _webDriver;
        FormsPage _formsPage;


        public FormsStepDefinitions(DriverHelper webDriver)
        {
            _webDriver = webDriver;
            _formsPage = new FormsPage(_webDriver.Driver);
        }

        [Given(@"User clicks Forms icon")]
        public void GivenUserClicksFormsIcon()
        {
            _formsPage.OpenUrl();
            _formsPage.ClickTitlesLink(_formsPage.formsTitle);
            _formsPage.ClickElement(_formsPage.Consent);

        }

        [Given(@"User navigates to Practice Form section")]
        public void GivenUserNavigatesToPracticeFormSection()
        {
            _formsPage.ClickElement(_formsPage.SectionElements(_formsPage.practiceFormSection));
        }

        [When(@"User enters the following data")]
        public void WhenUserEntersTheFollowingData(Table table)
        {
            var row = table.Rows.FirstOrDefault();

            _formsPage.EnterText(_formsPage.input, _formsPage.firstName, row["firstName"])
                        .EnterText(_formsPage.input, _formsPage.lastName, row["lastName"])
                        .EnterText(_formsPage.input, _formsPage.userEmail, row["email"])
                        .EnterText(_formsPage.input, _formsPage.userNumber, row["mobileNumber"])
                        .EnterText(_formsPage.textarea, _formsPage.currentAddress, row["address"]);
            Thread.Sleep(3000);
        }
        [When(@"User checks '(.*)' radio button")]
        public void WhenUserChecksRadioButton(string female)
        {
            _formsPage.ClickElement(_formsPage.FemaleLabel(female));
        }


        [When(@"User enters date of birth '(.*)'")]
        public void WhenUserEntersDateOfBirth(string dateOfBirth)
        {
            _formsPage.EnterDOB(dateOfBirth);

        }

        [When(@"User enters subjects Maths and Physics")]
        public void WhenUserEntersSubjectsMathsAndPhysics()
        {
        }

        [When(@"User checks Reading and Music checkboxes")]
        public void WhenUserChecksReadingAndMusicCheckboxes()
        {
        }

        [When(@"User selects Uttar Pradesh State and Merrut City")]
        public void WhenUserSelectsUttarPradeshStateAndMerrutCity()
        {
        }

        [Then(@"the following values are displayed in the modal")]
        public void ThenTheFollowingValuesAreDisplayedInTheModal(Table table)
        {
        }
    }
}
