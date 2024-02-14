using NUnit.Framework;
using SpecFlowProject1.Pages;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class ElementsButtonsStepDefinitions
    {
        private ElementsPage _elementsPage;

        [Given(@"User clicks Buttons")]
        public void GivenUserClicksButtons()
        {
            _elementsPage = (ElementsPage)ScenarioContext.Current["ElementsPage"];
            _elementsPage.ScrollDown(200);
            _elementsPage.ClickConsent();
            _elementsPage.ClickSection(_elementsPage.SectionElements(_elementsPage.buttonsSection));


        }

        [When(@"User clicks (.*) button")]
        public void WhenUserClicksDoubleClickMeButton(string buttonName)
        {
            string actualText = _elementsPage.ClickButtonAndGetMessage(buttonName);
            // Storing the value of actualText in the scenario context under the key "ActualText".
            // This means that we associate the value of actualText with the key "ActualText" in the current scenario context
            ScenarioContext.Current["ActualText"] = actualText;

        }

        [Then(@"(.*) should be displayed")]
        public void ThenShouldBeDisplayed(string expectedText)
        {
            // Retrieve the value previously stored in the scenario context under the key "ActualText."

            string actualText = (string)ScenarioContext.Current["ActualText"];
            Assert.That(expectedText, Is.EqualTo(actualText), $"Expected: {expectedText}, Actual: {actualText}");

        }
    }
}
