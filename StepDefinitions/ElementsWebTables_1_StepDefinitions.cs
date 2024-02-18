using NUnit.Framework;
using SpecFlowProject1.Drivers;
using SpecFlowProject1.Pages;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class ElementsWebTables_1_StepDefinitions
    {
        private DriverHelper _webDriver;

        ElementsPage _elementsPage;

        public ElementsWebTables_1_StepDefinitions(DriverHelper webDriver)
        {
            _webDriver = webDriver;
            _elementsPage = new ElementsPage(_webDriver.Driver);
        }

        [Given(@"User navigates to Web Tables section")]
        public void GivenUserNavigatesToWebTablesSection()
        {
            _elementsPage.ClickConsent();
            _elementsPage.ClickSection(_elementsPage.SectionElements(_elementsPage.webTablesSection));
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
