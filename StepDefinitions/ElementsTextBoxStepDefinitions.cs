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
        IWebDriver _webDriver;
        ElementsPage _elementsPage;
        string URL = "https://demoqa.com/";


        [When(@"User enters URL")]
        public void WhenUserEntersURL()

        {
            _webDriver = (IWebDriver)ScenarioContext.Current["WebDriver"];
            _elementsPage = (ElementsPage)ScenarioContext.Current["ElementsPage"];
            _webDriver.Navigate().GoToUrl(URL);
            _webDriver.Manage().Window.Maximize();
        }

        [Then(@"User clicks Elements icon")]
        public void ThenUserClicksElementsIcon()
        {
            _elementsPage.ClickElementsLink();
        }


        [When(@"User clicks Text Box title")]
        public void WhenUserClicksTextBoxTitle()
        {
            _elementsPage.ClickCategory(_elementsPage.TextBox);
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
                        _elementsPage.EnterName(data.FieldData);
                        break;
                    case "karage1625@bayxs.com":
                        _elementsPage.EnterEmail(data.FieldData);
                        break;
                    case "Lesi 22, Kiev, 34433, Ukraine":
                        _elementsPage.EnterCurrentAddress(data.FieldData);
                        break;
                    case "The same as above":
                        _elementsPage.EnterPermanentAddress(data.FieldData);
                        break;
                }
            }
        }

        [When(@"User clicks Submit button")]
        public void WhenUserClicksSubmitButton()
        {
            _elementsPage.ClickSubmitButton();
        }

        [Then(@"User verifies the following data is displayed in Table")]
        public void ThenUserVerifiesTheFollowingDataIsDisplayedInTable(Table table)
        {
            var expectedData = table.CreateSet<TableDataDisplayed>();
            Assert.That(_elementsPage.GetResultNameText(), Is.EqualTo(expectedData.ElementAt(0).TableData));
            Assert.That(_elementsPage.GetResultEmailText(), Is.EqualTo(expectedData.ElementAt(1).TableData));
            Assert.That(_elementsPage.GetResultCurrentAddressText(), Is.EqualTo(expectedData.ElementAt(2).TableData));
            Assert.That(_elementsPage.GetResultPermanentAddressText(), Is.EqualTo(expectedData.ElementAt(3).TableData));
        }

        [AfterScenario]
        public void AfterScenario()
        {
             _webDriver?.Quit();
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
