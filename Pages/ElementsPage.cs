using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject1.Pages
{
    public class ElementsPage
    {
        IWebDriver webDriver;


        public ElementsPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }


        // Elements category on Main page
        public IWebElement ElementsOnMain => webDriver.FindElement(By.XPath("//h5[normalize-space()='Elements']"));
        public void ClickElementsLink()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)webDriver;
            js.ExecuteScript("arguments[0].click();", ElementsOnMain);
        }


        // parametrize elements such as Text Box, Check Box, Web Tables ...

        public IWebElement SectionElements(string section) => webDriver.FindElement(By.XPath($"//span[normalize-space()='{section}']"));

        // to click sections  such as Text Box, Check Box.... on Elements page
        public void ClickSection(IWebElement element)
        {
            element.Click();
        }



        // TexBox section

        public IWebElement Consent => webDriver.FindElement(By.XPath("//p[@class='fc-button-label' and contains(text(), 'Consent')]"));
        public IWebElement SubmitButton => webDriver.FindElement(By.XPath("//button[@id='submit']"));


        public IWebElement GetFieldByName(string fieldName) => webDriver.FindElement(By.XPath($"//input[@id='{fieldName}']"));


        public IWebElement GetTextAreaByName(string textAreaName) => webDriver.FindElement(By.XPath($"//textarea[@id='{textAreaName}']"));

        public IWebElement GetResutlFieldByName(string resutlFieldName) => webDriver.FindElement(By.XPath($"//p[@id='{resutlFieldName}']"));

        //CheckBox section

        // parametrize toggle elements to expand the folders
        public IWebElement GetToggleElement(int index) => webDriver.FindElement(By.XPath($"(//button[@title='Toggle'])[{index}]"));

        // parametrize checkbox elements
        public IWebElement GetCheckboxElement(string checkboxTitle) => webDriver.FindElement(By.XPath($"//label[@for='tree-node-{checkboxTitle}']//span[@class='rct-checkbox']"));
        public IList<IWebElement> GetCheckboxElements() => webDriver.FindElements(By.XPath("(//ol)[5]//span[@class='rct-checkbox']"));
        public IWebElement DownloadsFolderTitle => webDriver.FindElement(By.XPath("//span[contains(text(),'Downloads')]"));

        public IWebElement ResultingMessage => webDriver.FindElement(By.XPath("//div[@id='result']"));

        // Web Tables section
        public IWebElement SalaryColumnTitle => webDriver.FindElement(By.XPath("//div[contains(text(),'Salary')]"));
        string salaryValue0 = "2000";
        string salaryValue1 = "10000";
        string salaryValue2 = "12000";


        // parametrize salary elements

        public IWebElement SalaryElement(string value) => webDriver.FindElement(By.XPath($"//div[normalize-space()='{value}']"));

        //public IWebElement DepartmentColumnElements(string elementName) => webDriver.FindElement(By.XPath($"//div[normalize-space()='{elementName}']"));
        public IWebElement DeleteIcon => webDriver.FindElement(By.XPath("(//*[name()='path'])[57]"));


        // Buttons section

        public IWebElement ButtonElement(string name) => webDriver.FindElement(By.XPath($"//button[@id='{name}']"));

        public IWebElement ButtonSectionMessage(string message) => webDriver.FindElement(By.XPath($"//p[@id='{message}']"));

        // TexBox methods
        public void ClickConsent()
        {
            Consent.Click();
        }

        public ElementsPage EnterName(string name)
        {
            string fieldName = "userName";
            GetFieldByName(fieldName).SendKeys(name);
            return this;
        }

        public ElementsPage EnterEmail(string email)
        {
            string fieldName = "userEmail";
            GetFieldByName(fieldName).SendKeys(email);
            return this;
        }

        public ElementsPage EnterCurrentAddress(string currentAddress)
        {
            string textAreaName = "currentAddress";
            GetTextAreaByName(textAreaName).SendKeys(currentAddress);
            return this;
        }

        public ElementsPage EnterPermanentAddress(string permanentAddress)
        {
            string textAreaName = "permanentAddress";
            GetTextAreaByName(textAreaName).SendKeys(permanentAddress);
            return this;
        }

        public ElementsPage ClickSubmitButton()
        {
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));

            IJavaScriptExecutor js = (IJavaScriptExecutor)webDriver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", wait.Until(e => SubmitButton));
            js.ExecuteScript("arguments[0].click();", SubmitButton);
            // SubmitButton.Click();
            return this;
        }


        public string GetResultNameText()
        {
            string name = "name";
            return GetResutlFieldByName(name).Text;
        }

        public string GetResultEmailText()
        {
            string email = "email";
            return GetResutlFieldByName(email).Text;
        }

        public string GetResultCurrentAddressText()
        {
            string currentAddress = "currentAddress";
            return GetResutlFieldByName(currentAddress).Text;
        }

        public string GetResultPermanentAddressText()
        {
            string permanentAddress = "permanentAddress";
            return GetResutlFieldByName(permanentAddress).Text;
        }



        // CheckBox methods
        public void ScrollDown(IWebDriver driver, int pixels)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript($"window.scrollBy(0, {pixels});");
        }
        public void ClickAllInOfficeFolder()
        {
            var checkboxElements = GetCheckboxElements();

            foreach (var checkboxElement in checkboxElements)
            {
                checkboxElement.Click();
            }
        }


        public string GetActualOutput()
        {
            return ResultingMessage.Text;
        }


        // Web Tables methods

        public List<int> GetSalaryValues()
        {
            List<int> salaryValues = new List<int>();
            salaryValues.Add(int.Parse(SalaryElement(salaryValue0).Text));
            salaryValues.Add(int.Parse(SalaryElement(salaryValue1).Text));
            salaryValues.Add(int.Parse(SalaryElement(salaryValue2).Text));
            return salaryValues;
        }

        public bool AreValuesInAscendingOrder(List<int> values)
        {
            return values.SequenceEqual(values.OrderBy(v => v));
        }

        public bool IsComplianceElementPresent()
        {
            var complianceElementsBeforeDeletion = webDriver.FindElements(By.XPath("//div[normalize-space()='Compliance']"));

            return complianceElementsBeforeDeletion.Count > 0;
        }

        // Button methods



        public string ClickButtonAndGetMessage(string buttonName)
        {
            Actions action = new Actions(webDriver);
            string resultMessage = "";
            string xpathDouble = "doubleClickBtn";
            string xpathRight = "rightClickBtn";
            string xpathClick = "itJ9X";
            switch (buttonName)
            {
                case "Double click me":
                    action.DoubleClick(ButtonElement(xpathDouble)).Build().Perform();
                    Thread.Sleep(10000);
                    resultMessage = ButtonSectionMessage("doubleClickMessage").Text;
                    break;

                case "Right click me":
                    action.ContextClick(ButtonElement(xpathRight)).Build().Perform();
                    Thread.Sleep(10000);
                    resultMessage = ButtonSectionMessage("rightClickMessage").Text;
                    break;

                case "Click me":
                    ButtonElement(xpathClick).Click();
                    Thread.Sleep(1000);
                    resultMessage = ButtonSectionMessage("dynamicClickMessage").Text;
                    break;
            }

            return resultMessage;
        }

    }
}