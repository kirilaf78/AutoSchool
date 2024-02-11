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


        [Given(@"User enters URL")]
        public void WhenUserEntersURL()

        {
            _webDriver = (IWebDriver)ScenarioContext.Current["WebDriver"];
            _elementsPage = (ElementsPage)ScenarioContext.Current["ElementsPage"];
            _webDriver.Navigate().GoToUrl(URL);
            _webDriver.Manage().Window.Maximize();
        }

        [Given(@"User clicks Elements icon")]
        public void ThenUserClicksElementsIcon()
        {
            _elementsPage.ClickElementsLink();
        }


        [Given(@"User clicks Text Box title")]
        public void WhenUserClicksTextBoxTitle()
        {
            // Thread.Sleep(1000);
            _elementsPage.ClickConsent();
            _elementsPage.ClickSection(_elementsPage.SectionElements("Text Box"));
        }

        [When(@"User enters the following data in Text Box fields")]
        public void ThenUserEntersTheFollowingDataInTextBoxFields(Table table)
        {
            var row = table.Rows.FirstOrDefault();

            _elementsPage.EnterName(row["name"])
                        .EnterEmail(row["email"])
                        .EnterCurrentAddress(row["address1"])
                        .EnterPermanentAddress(row["address2"]);

        }

        [When(@"User clicks Submit button")]
        public void WhenUserClicksSubmitButton()
        {
            _elementsPage.ClickSubmitButton();
        }

        [Then(@"User verifies the following data is displayed in Table")]
        public void ThenUserVerifiesTheFollowingDataIsDisplayedInTable(Table table)
        {
            var row = table.Rows.FirstOrDefault(); // Get the first (and only) row from the table


            // Assert that the actual values match the expected values
            Assert.Multiple(() =>
            {
                Assert.That(row["name"], Is.EqualTo(_elementsPage.GetResultNameText()));
                Assert.That(row["email"], Is.EqualTo(_elementsPage.GetResultEmailText()));
                Assert.That(row["address1"], Is.EqualTo(_elementsPage.GetResultCurrentAddressText()));
                Assert.That(row["address2"], Is.EqualTo(_elementsPage.GetResultPermanentAddressText()));
            });

        }


    }
}
