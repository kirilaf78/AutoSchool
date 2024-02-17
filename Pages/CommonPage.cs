using OpenQA.Selenium;

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
        public string alertsFrameAndWindowsTitle = "Alerts, Frame & Windows";
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

        // parametrize elements such as Text Box, Check Box, Web Tables ...

        public IWebElement SectionElements(string section) => webDriver.FindElement(By.XPath($"//span[normalize-space()='{section}']"));

        public void ClickSection(IWebElement element)
        {
            element.Click();
        }

        // Click "Consent" button
        public IWebElement Consent => webDriver.FindElement(By.XPath("//p[@class='fc-button-label' and contains(text(), 'Consent')]"));
        public void ClickConsent()
        {
            Consent.Click();
        }



    }
}
