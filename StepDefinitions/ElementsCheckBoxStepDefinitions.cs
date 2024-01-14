using OpenQA.Selenium;
using SpecFlowProject1.Pages;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class ElementsCheckBoxStepDefinitions
    {
        IWebDriver webDriver;
        ElementsPage elementsPage;
        string URL = "https://demoqa.com/";

        [When(@"User clicks Check Box title")]
        public void WhenUserClicksCheckBoxTitle()
        {
            elementsPage.ClickCategory(elementsPage.CheckBox);
        }
        [When(@"User expands the folder Home")]
        public void WhenUserExpandsTheFolderHome()
        {
            elementsPage.GetToggleElement(1).Click();
        }


        [When(@"User selects the folder Desktop without expanding it")]
        public void WhenUserSelectsTheFolderDesktopWithoutExpandingIt()
        {
            elementsPage.GetCheckboxElement("desktop").Click();
        }

        [When(@"User expands Documents folder")]
        public void WhenUserExpandsDocumentsFolder()
        {   
            elementsPage.GetToggleElement(3).Click();
                
        }

        [When(@"User expands WorkSpace folder")]
        public void WhenUserExpandsWorkSpaceFolder()
        {
            elementsPage.GetToggleElement(4).Click();
        }

        [Then(@"User selects Angular and Veu")]
        public void ThenUserSelectsAngularAndVeu()
        {
            elementsPage.GetCheckboxElement("angular").Click();
            elementsPage.GetCheckboxElement("veu").Click();

        }

        [When(@"User expands the folder Office")]
        public void WhenUserExpandsTheFolderOffice()
        {
            elementsPage.GetToggleElement(5).Click();
        }

        [Then(@"User clicks on each element in the Office folder one by one")]
        public void ThenUserClicksOnEachElementInTheOfficeFolderOneByOne()
        {
            foreach (var element in new[] { "public", "private", "classified", "general" })
            {
                elementsPage.GetCheckboxElement(element).Click();
            }

        }

        [When(@"User click toggle of the folder ""([^""]*)""")]
        public void WhenUserClickToggleOfTheFolder(string downloads)
        {
            throw new PendingStepException();
        }

        [Then(@"User clicks title of  ""([^""]*)"" folder \(by clicking on its name\)")]
        public void ThenUserClicksTitleOfFolderByClickingOnItsName(string downloads)
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
