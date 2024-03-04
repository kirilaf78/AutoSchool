using OpenQA.Selenium;
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
        public const string URL = "https://demoqa.com/";

        public IWebElement TitlesOnMain(string title) => webDriver.FindElement(By.XPath($"//h5[normalize-space()='{title}']"));

        // parametrize elements such as Text Box, Check Box, Web Tables ...

        public IWebElement SectionElements(string section) => webDriver.FindElement(By.XPath($"//span[normalize-space()='{section}']"));

        // "Consent" button
        public IWebElement Consent => webDriver.FindElement(By.XPath("//p[@class='fc-button-label' and contains(text(), 'Consent')]"));
        public void ClickTitlesLink(string title)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)webDriver;
            js.ExecuteScript("arguments[0].click();", TitlesOnMain(title));
        }

        public void OpenUrl()
        {
            webDriver.Navigate().GoToUrl(URL);
            webDriver.Manage().Window.Maximize();

        }
        public void ScrollDown(int pixels)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)webDriver;
            js.ExecuteScript($"window.scrollBy(0, {pixels});");
        }

        public void ClickElement(IWebElement element)
        {
            element.Click();
        }

        public string GetText(IWebElement element)
        {
            return element.Text;
        }

        public void ClickEnter(IWebElement element)
        {
            element.SendKeys(Keys.Enter);   
        }


    }
}
