using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;


namespace SpecFlowProject1.Pages
{
    public class AlertsFrameAndWindowsPage
    {
        IWebDriver webDriver;


        public AlertsFrameAndWindowsPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public string browserWindowsSection = "Browser Windows";
        public string tabButton = "tabButton";
        public string windowButton = "windowButton";

        public IWebElement AlertsFrameAndWindowsButtons(string name) => webDriver.FindElement(By.XPath($"//button[@id='{name}']"));
        public IWebElement H_OneTitle => webDriver.FindElement(By.XPath("//h1[@id='sampleHeading']"));
        public void ClickButton(string buttonName)
        {
            AlertsFrameAndWindowsButtons(buttonName).Click();
        }

        public string GetText()
        {
            return H_OneTitle.Text;
        }

        public void FocusOnNewTab()
        {
            // Wait for the new tab to open
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.WindowHandles.Count == 2);

            // Switch to the new tab
            webDriver.SwitchTo().Window(webDriver.WindowHandles[1]);

        }

        public void FocusOnNewWindow()
        {
            string newWindowHandle = webDriver.WindowHandles[^1]; // Get the handle of the last opened window
            webDriver.SwitchTo().Window(newWindowHandle);


        }
    }
}
