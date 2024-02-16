using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace SpecFlowProject1.Pages
{
    public class CommonPage
    {
        IWebDriver webDriver;


        public CommonPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public IWebElement TitlesOnMain(string title) => webDriver.FindElement(By.XPath($"//h5[normalize-space()='{title}']"));
        public string elementsTitle = "Elements";
        public void ClickTitlesLink(string title)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)webDriver;
            js.ExecuteScript("arguments[0].click();", TitlesOnMain(title));
        }
        public const string URL = "https://demoqa.com/";

        public void OpenUrl()
        {
            webDriver.Navigate().GoToUrl(URL);
            webDriver.Manage().Window.Maximize();

        }


    }
}
