using NUnit.Framework;
using SpecFlowProject1.Pages;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class ElementsWebTables_2_StepDefinitions
    {
        private ElementsPage _elementsPage;
        CommonPage _commonPage;


        [Given(@"User clicks Web Tables title")]
        public void GivenUserClicksWebTablesTitle()
        {
            _commonPage = (CommonPage)ScenarioContext.Current["CommonPage"];
            _elementsPage = (ElementsPage)ScenarioContext.Current["ElementsPage"];
            _commonPage.ClickConsent();
            _commonPage.ClickSection(_commonPage.SectionElements(_elementsPage.webTablesSection));
            Assert.That(_elementsPage.IsComplianceElementPresent(), Is.True, "Compliance element should be present before deleting a row");
        }

        [When(@"User click Delete icon on the second row of the table")]
        public void WhenUserClickDeleteIconOnTheSecondRowOfTheTable()
        {
            _elementsPage.ClickDeleteIconOnTheSecondRowOfTheTable();

        }

        [Then(@"Compliance are not displayed in Department column")]
        public void ThenComplianceAreNotDisplayedInDepartmentColumn()
        {
            Assert.That(_elementsPage.IsComplianceElementPresent(), Is.False, "Compliance element should not be present after deleting a row");
        }
    }
}
