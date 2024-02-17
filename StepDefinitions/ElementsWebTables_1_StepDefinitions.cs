using NUnit.Framework;
using SpecFlowProject1.Pages;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class ElementsWebTables_1_StepDefinitions
    {
        private ElementsPage _elementsPage;
        CommonPage _commonPage;


        [Given(@"User navigates to Web Tables section")]
        public void GivenUserNavigatesToWebTablesSection()
        {
            _commonPage = (CommonPage)ScenarioContext.Current["CommonPage"];
            _elementsPage = (ElementsPage)ScenarioContext.Current["ElementsPage"];
            _commonPage.ClickConsent();
            _commonPage.ClickSection(_commonPage.SectionElements(_elementsPage.webTablesSection));
        }


        [When(@"User clicks Salary column")]
        public void WhenUserClicksSalaryColumn()
        {
            _elementsPage.ClickSalaryColumn();

        }

        [Then(@"values in the column sorted in ascending order")]
        public void ThenValuesInTheColumnSortedInAscendingOrder()
        {
            Assert.That(_elementsPage.AreValuesInAscendingOrder(_elementsPage.GetSalaryValues()), Is.True, "Values are not in ascending order");
        }

    }
}
