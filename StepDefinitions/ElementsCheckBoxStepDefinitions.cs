using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowProject1.Pages;
using OpenQA.Selenium.Chrome;

using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class ElementsCheckBoxStepDefinitions
    {
        private IWebDriver _webDriver;
        private ElementsPage _elementsPage;


        [When(@"User clicks Check Box title")]
        public void WhenUserClicksCheckBoxTitle()

        {
            _webDriver = (IWebDriver)ScenarioContext.Current["WebDriver"];
            _elementsPage = (ElementsPage)ScenarioContext.Current["ElementsPage"];


            //elementsPage.ClickSection(elementsPage.InitializeWaitAndCheckbox());

            //IJavaScriptExecutor js = (IJavaScriptExecutor)webDriver;
            //js.ExecuteScript("arguments[0].click();", elementsPage.CheckBox);
            //Console.WriteLine(webDriver.PageSource);

            _elementsPage.ClickSection(_elementsPage.SectionElements("Check Box"));
        }

        [When(@"User expands the folder Home")]
        public void WhenUserExpandsTheFolderHome()
        {
            _elementsPage.GetToggleElement(1).Click();
        }


        [When(@"User selects the folder Desktop without expanding it")]
        public void WhenUserSelectsTheFolderDesktopWithoutExpandingIt()
        {
            _elementsPage.GetCheckboxElement("desktop").Click();
        }

        [When(@"User expands Documents folder")]
        public void WhenUserExpandsDocumentsFolder()
        {   
            _elementsPage.GetToggleElement(3).Click();
                
        }

        [When(@"User expands WorkSpace folder")]
        public void WhenUserExpandsWorkSpaceFolder()
        {
            _elementsPage.GetToggleElement(4).Click();
        }

        [Then(@"User selects Angular and Veu")]
        public void ThenUserSelectsAngularAndVeu()
        {
            _elementsPage.GetCheckboxElement("angular").Click();
            _elementsPage.GetCheckboxElement("veu").Click();

        }

        [When(@"User expands the folder Office")]
        public void WhenUserExpandsTheFolderOffice()
        {
            _elementsPage.GetToggleElement(5).Click();
        }

        [Then(@"User clicks on each element in the Office folder one by one")]
        public void ThenUserClicksOnEachElementInTheOfficeFolderOneByOne()
        {
            // Thread.Sleep(10000);
            //_webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _elementsPage.ScrollDown(_webDriver, 500);

            foreach (var element in new[] { "public", "private", "classified", "general" })
            {
                _elementsPage.GetCheckboxElement(element).Click();
            }

        }

        [When(@"User click toggle of the folder Downloads")]
        public void WhenUserClickToggleOfTheFolderDownloads()
        {

            _elementsPage.GetToggleElement(6).Click();
        }

        [Then(@"User clicks title of  Downloads folder \(by clicking on its name\)")]
        public void ThenUserClicksTitleOfDownloadsFolderByClickingOnItsName()
        {
            _elementsPage.DownloadsFolderTitle.Click();
        }

        [Then(@"the output should be ""([^""]*)""")]
        public void ThenTheOutputShouldBe(string expectedOutput)
        {
            string actualOutput = _elementsPage.GetActualOutput().Replace("\r\n", " ");
            Assert.AreEqual(expectedOutput, actualOutput);
        }

    }
}
