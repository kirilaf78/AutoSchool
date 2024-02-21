using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject1.Pages
{
    public class WidgetsPage : CommonPage
    {

        IWebDriver webDriver;

        public string autoCompleteSection = "Auto Complete";
        public string multiColorInput = "autoCompleteMultipleInput";
        public string singleColorInput = "autoCompleteSingleInput";

        public WidgetsPage(IWebDriver webDriver) : base(webDriver)
        {
            this.webDriver = webDriver;
        }

        public IWebElement ColorNamesInputs(string input) => webDriver.FindElement(By.XPath($"//input[@id='{input}']"));
        public IWebElement SingleColorNameInput => webDriver.FindElement(By.XPath("//input[@id='autoCompleteSingleInput']"));
        public IWebElement AutoCompleteElement(string number) => webDriver.FindElement(By.XPath($"//*[@id=\"react-select-2-option-{number}\"]"));
        public ReadOnlyCollection<IWebElement> AutoCompleteOptions => webDriver.FindElements(By.XPath(".//div[contains(@class, 'auto-complete__option')]"));
        public void TypeLetter(string input, string letter)
        {
            ColorNamesInputs(input).Click();
            // Thread.Sleep(1000);
            ColorNamesInputs(input).SendKeys(letter);
        }
        public bool DoesContainLetter(string letter)
        {
            foreach(var option in AutoCompleteOptions)
            {
                string color = option.Text;
                if (!color.ToLower().Contains(letter))
                {
                    return false;
                }

            }
            return true;
        }
    }
}
