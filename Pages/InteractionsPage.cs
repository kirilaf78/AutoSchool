using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject1.Pages
{
    public class InteractionsPage : CommonPage
    {

        IWebDriver webDriver;

        public InteractionsPage(IWebDriver webDriver) : base(webDriver)
        {
            this.webDriver = webDriver;
        }
        public string interactionsTitle = "Interactions";
        public string selectableSection = "Selectable";
        public IWebElement gridTab => webDriver.FindElement(By.XPath("//a[@id='demo-tab-grid']"));


    }
}
