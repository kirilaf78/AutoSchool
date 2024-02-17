using NUnit.Framework;
using SpecFlowProject1.Pages;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class ElementsTextBoxStepDefinitions
    {
        ElementsPage _elementsPage;
        CommonPage _commonPage;



        [Given(@"User enters URL")]
        public void WhenUserEntersURL()

        {
            _commonPage = (CommonPage)ScenarioContext.Current["CommonPage"];
            _commonPage.OpenUrl();
        }

        [Given(@"User clicks Elements icon")]
        public void ThenUserClicksElementsIcon()
        {
            _commonPage.ClickTitlesLink(_commonPage.elementsTitle);
        }


        [Given(@"User clicks Text Box title")]
        public void WhenUserClicksTextBoxTitle()
        {
            _elementsPage = (ElementsPage)ScenarioContext.Current["ElementsPage"];
            _commonPage.ClickConsent();
            _commonPage.ClickSection(_commonPage.SectionElements(_elementsPage.textBoxSection));
        }

        [When(@"User enters the following data in Text Box fields")]
        public void ThenUserEntersTheFollowingDataInTextBoxFields(Table table)
        {
            var row = table.Rows.FirstOrDefault();

            _elementsPage.EnterName(row["name"])
                        .EnterEmail(row["email"])
                        .EnterCurrentAddress(row["address1"])
                        .EnterPermanentAddress(row["address2"]);

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
                Assert.That(row["name"], Is.EqualTo(_elementsPage.GetResultNameText()));
                Assert.That(row["email"], Is.EqualTo(_elementsPage.GetResultEmailText()));
                Assert.That(row["address1"], Is.EqualTo(_elementsPage.GetResultCurrentAddressText()));
                Assert.That(row["address2"], Is.EqualTo(_elementsPage.GetResultPermanentAddressText()));
            });

        }


    }
}
