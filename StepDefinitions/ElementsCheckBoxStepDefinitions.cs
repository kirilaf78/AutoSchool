using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class ElementsCheckBoxStepDefinitions
    {
        [Given(@"User expands the folder ""([^""]*)""")]
        public void GivenUserExpandsTheFolder(string home)
        {
            throw new PendingStepException();
        }

        [Given(@"User selects the folder ""([^""]*)"" without expanding it")]
        public void GivenUserSelectsTheFolderWithoutExpandingIt(string desktop)
        {
            throw new PendingStepException();
        }

        [Given(@"User chooses ""([^""]*)"" and ""([^""]*)"" from the ""([^""]*)"" folder")]
        public void GivenUserChoosesAndFromTheFolder(string angular, string veu, string workSpace)
        {
            throw new PendingStepException();
        }

        [When(@"User expands the folder ""([^""]*)""")]
        public void WhenUserExpandsTheFolder(string office)
        {
            throw new PendingStepException();
        }

        [Then(@"User clicks on each element in the ""([^""]*)"" folder one by one")]
        public void ThenUserClicksOnEachElementInTheFolderOneByOne(string office)
        {
            throw new PendingStepException();
        }

        [When(@"User click toggle of the folder ""([^""]*)""")]
        public void WhenUserClickToggleOfTheFolder(string downloads)
        {
            throw new PendingStepException();
        }

        [Then(@"User selects the entire ""([^""]*)"" folder \(by clicking on its name\)")]
        public void ThenUserSelectsTheEntireFolderByClickingOnItsName(string downloads)
        {
            throw new PendingStepException();
        }

        [Then(@"the output should be ""([^""]*)""")]
        public void ThenTheOutputShouldBe(string p0)
        {
            throw new PendingStepException();
        }
    }
}
