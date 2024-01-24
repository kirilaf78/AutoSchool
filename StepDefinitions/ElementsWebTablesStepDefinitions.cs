using NuGet.Frameworks;
using OpenQA.Selenium;
using SpecFlowProject1.Pages;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class ElementsWebTablesStepDefinitions
    {
        private IWebDriver _webDriver;
        private ElementsPage _elementsPage;

        [When(@"User clicks Web Tables title")]
        public void WhenUserClicksWebTablesTitle()
        {
            _webDriver = (IWebDriver)ScenarioContext.Current["WebDriver"];
            _elementsPage = (ElementsPage)ScenarioContext.Current["ElementsPage"];
            _elementsPage.ClickCategory(_elementsPage.SectionElements("Web Tables"));
        }

        [When(@"User clicks Salary column")]
        public void WhenUserClicksSalaryColumn()
        {
            _elementsPage.SalaryColumnTitle.Click();
        }

        [Then(@"values in the column sorted in ascending order")]
        public void ThenValuesInTheColumnSortedInAscendingOrder()
        {
            Assert.IsTrue(_elementsPage.AreValuesInAscendingOrder(_elementsPage.GetSalaryValues()));
        }

        [When(@"User click Delete icon on the third row of the table")]
        public void WhenUserClickDeleteIconOnTheThirdRowOfTheTable()
        {
        }

        [Then(@"Compliance are not displayed in Department column")]
        public void ThenComplianceAreNotDisplayedInDepartmentColumn()
        {
        }
    }
}
