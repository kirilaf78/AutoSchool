using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Security.Cryptography.X509Certificates;

namespace SpecFlowProject1.Pages
{

    public class FormsPage : CommonPage
    {
        IWebDriver webDriver;


        public FormsPage(IWebDriver webDriver) : base(webDriver)
        {
            this.webDriver = webDriver;
        }

        public string formsTitle = "Forms";
        public string practiceFormSection = "Practice Form";
        public string input = "input";
        public string textarea = "textarea";
        public string firstName = "firstName";
        public string lastName = "lastName";
        public string userEmail = "userEmail";
        public string userNumber = "userNumber";
        public string currentAddress = "currentAddress";

        public IWebElement TableFieldByName(string elementName, string fieldName) => webDriver.FindElement(By.XPath($"//{elementName}[@id='{fieldName}']"));
        public IWebElement YearPicker => webDriver.FindElement(By.XPath("//select[@class='react-datepicker__year-select']"));
        public IWebElement Year(string year) => webDriver.FindElement(By.XPath($"//option[@value='{year}']"));
        public IWebElement DateOfBirthInput => webDriver.FindElement(By.XPath("//input[@id='dateOfBirthInput']"));
        public IWebElement Date => webDriver.FindElement(By.XPath("//div[@aria-label='Choose Tuesday, February 28th, 2006']"));
        public IWebElement FemaleLabel(string name) => webDriver.FindElement(By.XPath($"//label[normalize-space()='{name}']"));


        public FormsPage EnterText(string elementName, string fieldName, string text)
        {
            TableFieldByName(elementName, fieldName).SendKeys(text);
            return this;
        }

        public void EnterDOB(string dateOfBirth)
        {
                DateOfBirthInput.SendKeys("");
                ClickElement(YearPicker);
                ClickElement(Year(dateOfBirth));
                ClickElement(Date);
                Thread.Sleep(3000);
        }

    }
}


