using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowProject1.Pages;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class ElementsWebTables_2_StepDefinitions
    {
        private IWebDriver _webDriver;
        private ElementsPage _elementsPage;

        [Given(@"User clicks Web Tables title")]
        public void GivenUserClicksWebTablesTitle()
        {
            _webDriver = (IWebDriver)ScenarioContext.Current["WebDriver"];
            _elementsPage = (ElementsPage)ScenarioContext.Current["ElementsPage"];
            _elementsPage.ClickConsent();
            _elementsPage.ClickSection(_elementsPage.SectionElements("Web Tables"));
            Assert.That(_elementsPage.IsComplianceElementPresent(), Is.True, "Compliance element should be present before deleting a row");
        }

        [When(@"User click Delete icon on the second row of the table")]
        public void WhenUserClickDeleteIconOnTheSecondRowOfTheTable()
        {
            _elementsPage.DeleteIcon.Click();

        }

        [Then(@"Compliance are not displayed in Department column")]
        public void ThenComplianceAreNotDisplayedInDepartmentColumn()
        {
            Assert.That(_elementsPage.IsComplianceElementPresent(), Is.False, "Compliance element should not be present after deleting a row");
        }
    }
}
