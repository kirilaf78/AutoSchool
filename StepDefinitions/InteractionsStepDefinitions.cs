using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class InteractionsStepDefinitions
    {
        [Given(@"User navigates to Selectable section")]
        public void GivenUserNavigatesToSelectableSection()
        {
        }

        [When(@"User clicks Grid tab")]
        public void WhenUserClicksGridTab()
        {
        }

        [When(@"User clicks  One, Three, Five, Seven and Nine")]
        public void WhenUserClicksOneThreeFiveSevenAndNine()
        {
        }

        [Then(@"value of selected squares is One, Three, Five, Seven and Nine")]
        public void ThenValueOfSelectedSquaresIsOneThreeFiveSevenAndNine()
        {
        }
    }
}
