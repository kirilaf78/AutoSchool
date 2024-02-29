using NUnit.Framework;
using SpecFlowProject1.Drivers;
using SpecFlowProject1.Pages;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class ElementsTextBoxStepDefinitions
    {
        private DriverHelper _webDriver;

        ElementsPage _elementsPage;

        public ElementsTextBoxStepDefinitions(DriverHelper webDriver)
        {
            _webDriver = webDriver;
            _elementsPage = new ElementsPage(_webDriver.Driver);
        }

        [Given(@"User enters URL")]
        public void WhenUserEntersURL()

        {
            _elementsPage.OpenUrl();
        }

        [Given(@"User clicks Elements icon")]
        public void ThenUserClicksElementsIcon()
        {
            _elementsPage.ClickTitlesLink(_elementsPage.elementsTitle);
        }


        [Given(@"User clicks Text Box title")]
        public void WhenUserClicksTextBoxTitle()
        {
            _elementsPage.ClickElement(_elementsPage.Consent);
            _elementsPage.ClickElement(_elementsPage.SectionElements(_elementsPage.textBoxSection));
        }

        [When(@"User enters the following data in Text Box fields")]
        public void ThenUserEntersTheFollowingDataInTextBoxFields(Table table)
        {
            var row = table.Rows.FirstOrDefault();

            _elementsPage.EnterText(_elementsPage.input, _elementsPage.userName, row["name"])
                        .EnterText(_elementsPage.input, _elementsPage.userEmail, row["email"])
                        .EnterText(_elementsPage.textarea, _elementsPage.currentAddress, row["address1"])
                        .EnterText(_elementsPage.textarea, _elementsPage.permanentAddress, row["address2"]);

        }
        [When(@"Submit button is clicked")]
        public void WhenSubmitButtonIsClicked()
        {
            _elementsPage.ClickSubmitButton();
        }


        [Then(@"User verifies the following data is displayed in Table")]
        public void ThenUserVerifiesTheFollowingDataIsDisplayedInTable(Table table)
        {
            var row = table.Rows.FirstOrDefault(); // Get the first (and only) row from the table


            // Assert that the actual values match the expected values
            Assert.Multiple(() =>
            {
                Assert.That(row["name"], Is.EqualTo(_elementsPage.GetResultText(_elementsPage.name)));
                Assert.That(row["email"], Is.EqualTo(_elementsPage.GetResultText(_elementsPage.email)));
                Assert.That(row["address1"], Is.EqualTo(_elementsPage.GetResultText(_elementsPage.currentAddress)));
                Assert.That(row["address2"], Is.EqualTo(_elementsPage.GetResultText(_elementsPage.permanentAddress)));
            });

        }


    }
}
