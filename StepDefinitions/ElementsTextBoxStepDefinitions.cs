using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlowProject1.Pages;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using NUnit.Framework;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class ElementsTextBoxStepDefinitions
    {
        IWebDriver webDriver;
        ElementsPage elementsPage;
        string URL = "https://demoqa.com/";

        [Given(@"User opens browser")]
        public void GivenUserOpensBrowser()
        {
            webDriver = new ChromeDriver();
            elementsPage = new ElementsPage(webDriver);
        }

        [When(@"User enters URL")]
        public void WhenUserEntersURL()
        {
            webDriver.Navigate().GoToUrl(URL);
            webDriver.Manage().Window.Maximize();
        }

        [When(@"User clicks Elements icon")]
        public void WhenUserClicksElementsIcon()
        {
            elementsPage.ClickElementsLink();
        }

        [Then(@"Elements page is displayed")]
        public void ThenElementsPageIsDisplayed()
        {
        }

        [When(@"User clicks Text Box title")]
        public void WhenUserClicksTextBoxTitle()
        {
            elementsPage.ClickTextBox();
        }

        [Then(@"User enters the following data in Text Box fields")]
        public void ThenUserEntersTheFollowingDataInTextBoxFields(Table table)
        {
            var inputData = table.CreateSet<FieldDataEntered>();
            foreach (var data in inputData)
            {
                switch (data.FieldData)
                {
                    case "Viktor Gusev":
                        elementsPage.EnterName(data.FieldData);
                        break;
                    case "karage1625@bayxs.com":
                        elementsPage.EnterEmail(data.FieldData);
                        break;
                    case "Lesi 22, Kiev, 34433, Ukraine":
                        elementsPage.EnterCurrentAddress(data.FieldData);
                        break;
                    case "The same as above":
                        elementsPage.EnterPermanentAddress(data.FieldData);
                        break;
                }
            }
        }

        [When(@"User clicks Submit button")]
        public void WhenUserClicksSubmitButton()
        {
            elementsPage.ClickSubmitButton();
        }

        [Then(@"User verifies the following data is displayed in Table")]
        public void ThenUserVerifiesTheFollowingDataIsDisplayedInTable(Table table)
        {           
                var expectedData = table.CreateSet<TableDataDisplayed>();
                Assert.That(elementsPage.GetResultNameText(), Is.EqualTo(expectedData.ElementAt(0).TableData));
                Assert.That(elementsPage.GetResultEmailText(), Is.EqualTo(expectedData.ElementAt(1).TableData));
                Assert.That(elementsPage.GetResultCurrentAddressText(), Is.EqualTo(expectedData.ElementAt(2).TableData));
                Assert.That(elementsPage.GetResultPermanentAddressText(), Is.EqualTo(expectedData.ElementAt(3).TableData));
                webDriver.Close();
        }


        public class FieldDataEntered
        {
            public string FieldData { get; set; }
        }

        public class TableDataDisplayed
        {
            public string TableData { get; set; }
        }

        
    }
}
