using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public IWebElement ElementsOnMain => webDriver.FindElement(By.XPath("//h5[normalize-space()='Elements']"));
        // TexBox section

        public IWebElement TextBox => webDriver.FindElement(By.XPath("//span[normalize-space()='Text Box']"));

        public IWebElement SubmitButton => webDriver.FindElement(By.XPath("//button[@id='submit']"));


        public IWebElement GetFieldByName(string fieldName) => webDriver.FindElement(By.XPath($"//input[@id='{fieldName}']"));


        public IWebElement GetTextAreaByName(string textAreaName) => webDriver.FindElement(By.XPath($"//textarea[@id='{textAreaName}']"));

        public IWebElement GetResutlFieldByName(string resutlFieldName) => webDriver.FindElement(By.XPath($"//p[@id='{resutlFieldName}']"));

        //CheckBox section
        // to replace with parametrize 
        public IWebElement CheckBox => webDriver.FindElement(By.XPath("//span[normalize-space()='Check Box']"));

        // toggle elements to expand the folders
        public IWebElement GetToggleElement(int index) => webDriver.FindElement(By.XPath($"(//button[@title='Toggle'])[{index}]"));
        //public IWebElement HomeToggle => webDriver.FindElement(By.XPath("(//button[@title='Toggle'])[1]"));
        //public IWebElement DocumentsToggle => webDriver.FindElement(By.XPath("(//button[@title='Toggle'])[3]"));
        //public IWebElement WorkSpaceToggle => webDriver.FindElement(By.XPath("(//button[@title='Toggle'])[4]"));
        //public IWebElement OfficeToggle => webDriver.FindElement(By.XPath("(//button[@title='Toggle'])[5]"));
        //public IWebElement DownloadsToggle => webDriver.FindElement(By.XPath("(//button[@title='Toggle'])[6]"));


        public IWebElement GetCheckboxElement(string checkboxTitle) => webDriver.FindElement(By.XPath($"//label[@for='tree-node-{checkboxTitle}']//span[@class='rct-checkbox']"));
        //public IWebElement DesktopCheckbox => webDriver.FindElement(By.XPath("//label[@for='tree-node-desktop']//span[@class='rct-checkbox']"));
        //public IWebElement AngularCheckbox => webDriver.FindElement(By.XPath("//label[@for='tree-node-angular']//span[@class='rct-checkbox']"));
        //public IWebElement VeuCheckbox => webDriver.FindElement(By.XPath("//label[@for='tree-node-veu']//span[@class='rct-checkbox']"));

        //public IWebElement PublicCheckbox => webDriver.FindElement(By.XPath("//label[@for='tree-node-public']//span[@class='rct-checkbox']"));

        //public IWebElement PrivateCheckbox => webDriver.FindElement(By.XPath("//label[@for='tree-node-private']//span[@class='rct-checkbox']"));

        //public IWebElement ClassifiedCheckbox => webDriver.FindElement(By.XPath("//label[@for='tree-node-classified']//span[@class='rct-checkbox']"));

        //public IWebElement GeneralCheckbox => webDriver.FindElement(By.XPath("//label[@for='tree-node-general']//span[@class='rct-checkbox']"));

        public IWebElement DownloadsFolderTitle => webDriver.FindElement(By.XPath("//span[contains(text(),'Downloads')]"));

        public IWebElement ResultingMessage => webDriver.FindElement(By.XPath("//div[@id='result']"));

        
        
        public void ClickElementsLink()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)webDriver;
            js.ExecuteScript("arguments[0].click();", ElementsOnMain);
        }

        // to click categories  such as Text Box, Check Box.... on Elements page
        public void ClickCategory(IWebElement element)
        {
            element.Click();
        }

        // TexBox methods

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


        




    }
}
