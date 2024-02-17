using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace SpecFlowProject1.Pages
{
    public class ElementsPage: CommonPage
    {
        IWebDriver webDriver;

        public ElementsPage(IWebDriver webDriver): base(webDriver) 
        {
            this.webDriver = webDriver;
        }

        // TexBox section
        public string textBoxSection = "Text Box";

        // public IWebElement Consent => webDriver.FindElement(By.XPath("//p[@class='fc-button-label' and contains(text(), 'Consent')]"));
        public IWebElement SubmitButton => webDriver.FindElement(By.XPath("//button[@id='submit']"));

        public IWebElement GetFieldByName(string fieldName) => webDriver.FindElement(By.XPath($"//input[@id='{fieldName}']"));

        public IWebElement GetTextAreaByName(string textAreaName) => webDriver.FindElement(By.XPath($"//textarea[@id='{textAreaName}']"));

        public IWebElement GetResutlFieldByName(string resutlFieldName) => webDriver.FindElement(By.XPath($"//p[@id='{resutlFieldName}']"));

        //CheckBox section

        public string checkBoxSection = "Check Box";
        public string checkBoxDesktop = "desktop";
        public string checkBoxAngular = "angular";
        public string checkBoxVue = "veu";
        public int scrollPixels = 500;
        public int folderHomeNumber = 1;
        public int folderOfficeNumber = 5;
        public int folderDownloadsNumber = 6;
        public int folderDocumentsNumber = 3;
        public int folderWorkSpaceNumber = 4;

        // parametrize toggle elements to expand the folders
        public IWebElement GetToggleElement(int index) => webDriver.FindElement(By.XPath($"(//button[@title='Toggle'])[{index}]"));

        // parametrize checkbox elements
        public IWebElement GetCheckboxElement(string checkboxTitle) => webDriver.FindElement(By.XPath($"//label[@for='tree-node-{checkboxTitle}']//span[@class='rct-checkbox']"));
        public IList<IWebElement> GetCheckboxElements() => webDriver.FindElements(By.XPath("(//ol)[5]//span[@class='rct-checkbox']"));
        public IWebElement DownloadsFolderTitle => webDriver.FindElement(By.XPath("//span[contains(text(),'Downloads')]"));

        public IWebElement ResultingMessage => webDriver.FindElement(By.XPath("//div[@id='result']"));

        // Web Tables section
        public string webTablesSection = "Web Tables";
        public IWebElement SalaryColumnTitle => webDriver.FindElement(By.XPath("//div[contains(text(),'Salary')]"));
        string salaryValue0 = "2000";
        string salaryValue1 = "10000";
        string salaryValue2 = "12000";

        // parametrize salary elements

        public IWebElement SalaryElement(string value) => webDriver.FindElement(By.XPath($"//div[normalize-space()='{value}']"));

        //public IWebElement DepartmentColumnElements(string elementName) => webDriver.FindElement(By.XPath($"//div[normalize-space()='{elementName}']"));
        public IWebElement DeleteIcon => webDriver.FindElement(By.XPath("(//*[name()='path'])[57]"));


        // Buttons section
        public string buttonsSection = "Buttons";

        public IWebElement ButtonElement(string name) => webDriver.FindElement(By.XPath($"//button[@id='{name}']"));

        public IWebElement ClickMeButton => webDriver.FindElement(By.XPath("(//button[normalize-space()='Click Me'])[1]"));

        public IWebElement ButtonSectionMessage(string message) => webDriver.FindElement(By.XPath($"//p[@id='{message}']"));

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

        public void ClickCheckBox(string checkBoxName)
        {
            GetCheckboxElement(checkBoxName).Click();

        }
        public void ClickToggle(int toggleNumber)
        {
            GetToggleElement(toggleNumber).Click();

        }

        public void ClickToggleOfTheFolderDownloads()
        {
            GetToggleElement(6).Click();

        }

        public void ClicksTitleOfDownloadsFolder()
        {
            DownloadsFolderTitle.Click();

        }

        public void ScrollDown(int pixels)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)webDriver;
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
            return ResultingMessage.Text.Replace("\r\n", " ");
        }

        // Web Tables methods
        public void ClickSalaryColumn()
        {
            SalaryColumnTitle.Click();

        }

        public void ClickDeleteIconOnTheSecondRowOfTheTable()
        {
            DeleteIcon.Click();

        }
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
            switch (buttonName)
            {
                case "Double click me":
                    ScrollDown(500);
                    action.DoubleClick(ButtonElement(xpathDouble)).Build().Perform();
                    resultMessage = ButtonSectionMessage("doubleClickMessage").Text;
                    break;

                case "Right click me":
                    ScrollDown(300);
                    Thread.Sleep(1000);
                    action.ContextClick(ButtonElement(xpathRight)).Build().Perform();
                    resultMessage = ButtonSectionMessage("rightClickMessage").Text;
                    break;

                case "Click me":
                    ScrollDown(200);
                    ClickMeButton.Click();
                    resultMessage = ButtonSectionMessage("dynamicClickMessage").Text;
                    break;
            }

            return resultMessage;
        }

    }
}