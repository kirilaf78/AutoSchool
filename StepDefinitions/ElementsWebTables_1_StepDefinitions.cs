using NuGet.Frameworks;
using OpenQA.Selenium;
using SpecFlowProject1.Pages;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class ElementsWebTables_1_StepDefinitions
    {
        private IWebDriver _webDriver;
        private ElementsPage _elementsPage;

        [Given(@"User navigates to Web Tables section")]
        public void GivenUserNavigatesToWebTablesSection()
        {
            _webDriver = (IWebDriver)ScenarioContext.Current["WebDriver"];
            _elementsPage = (ElementsPage)ScenarioContext.Current["ElementsPage"];
            _elementsPage.ClickConsent();
            _elementsPage.ClickSection(_elementsPage.SectionElements("Web Tables"));
        }


        [When(@"User clicks Salary column")]
        public void WhenUserClicksSalaryColumn()
        {
            _elementsPage.SalaryColumnTitle.Click();

        }

        [Then(@"values in the column sorted in ascending order")]
        public void ThenValuesInTheColumnSortedInAscendingOrder()
        {
            Assert.That(_elementsPage.AreValuesInAscendingOrder(_elementsPage.GetSalaryValues()), Is.True, "Values are not in ascending order");
        }

    }
}
