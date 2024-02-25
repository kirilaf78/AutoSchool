using NUnit.Framework;
using SpecFlowProject1.Drivers;
using SpecFlowProject1.Pages;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class InteractionsStepDefinitions
    {
        private DriverHelper _webDriver;
        InteractionsPage _interactionsPage;


        public InteractionsStepDefinitions(DriverHelper webDriver)
        {
            _webDriver = webDriver;
            _interactionsPage = new InteractionsPage(_webDriver.Driver);
        }

        [Given(@"User types URL")]
        public void GivenUserTypesURL()
        {
            _interactionsPage.OpenUrl();
        }

        [Given(@"Widgets icon is clicked")]
        public void GivenWidgetsIconIsClicked()
        {
            _interactionsPage.ClickTitlesLink(_interactionsPage.interactionsTitle);
            _interactionsPage.ClickElement(_interactionsPage.Consent);

        }


        [Given(@"User navigates to Selectable section")]
        public void GivenUserNavigatesToSelectableSection()
        {
            _interactionsPage.ScrollDown(200);
            _interactionsPage.ClickElement(_interactionsPage.SectionElements(_interactionsPage.selectableSection));
        }

        [When(@"User clicks Grid tab")]
        public void WhenUserClicksGridTab()
        {
            _interactionsPage.ClickElement(_interactionsPage.GridTab);
        }

        [When(@"User clicks  One, Three, Five, Seven and Nine")]
        public void WhenUserClicksOneThreeFiveSevenAndNine()
        {
            _interactionsPage.ClickGridSquare();
        }

        [Then(@"value of selected squares is One, Three, Five, Seven and Nine")]
        public void ThenValueOfSelectedSquaresIsOneThreeFiveSevenAndNine()
        {
            _interactionsPage.GetActiveSquareNumbers();
            Assert.That(_interactionsPage.gridSquareNumbers, Is.EqualTo(_interactionsPage.actualSquareNumbers));
        }
    }
}
