using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using SpecFlowProject1.Drivers;
using SpecFlowProject1.Pages;
using System;
using System.Security.Cryptography.X509Certificates;
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

        [When(@"User types '(.*)', clicks Enter,  and '(.*)', clicks Enter")]
        public void WhenUserTypesClicksEnterAndClicksEnter(string p, string m)
        {
            _formsPage.TypeLetterAndEnterWords(p, m);
            // Thread.Sleep(3000);

        }

        [When(@"User checks '(.*)' and '(.*)' checkboxes")]
        public void WhenUserChecksAndCheckboxes(string reading, string music)
        {
            _formsPage.ScrollDown(200);
            _formsPage.ClickElement(_formsPage.HobbiesCheckBox(reading));
            _formsPage.ClickElement(_formsPage.HobbiesCheckBox(music));
        }

        [When(@"User clicks '(.*)'")]
        public void WhenUserClicks(string stateSelect)
        {
            _formsPage.ClickElement(_formsPage.SelectStateAndCity(stateSelect));
        }

        [When(@"User selects Uttar Pradesh state")]
        public void WhenUserSelectsUttarPradeshState()
        {
            _formsPage.ClickElement(_formsPage.StateAndCity(_formsPage.stateName));
        }

        [When(@"clicks '(.*)' > Merrut")]
        public void WhenClicksMerrut(string citySelect)
        {
            _formsPage.ScrollDown(200);

            _formsPage.ClickElement(_formsPage.SelectStateAndCity(citySelect));
            _formsPage.ClickElement(_formsPage.StateAndCity(_formsPage.cityName));
        }

        [When(@"clicks Submit button")]
        public void WhenClicksSubmitButton()
        {
            _formsPage.ClickElement(_formsPage.SubmitButton);
            Thread.Sleep(2000);
        }


        [Then(@"the following values are displayed in the modal")]
        public void ThenTheFollowingValuesAreDisplayedInTheModal(Table table)
        {
        }
    }
}
