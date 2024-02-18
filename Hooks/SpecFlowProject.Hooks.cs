using OpenQA.Selenium.Chrome;
using SpecFlowProject1.Drivers;

namespace SpecFlowProject1.Hooks
{
    [Binding]
    public class Hooks
    {
        private DriverHelper _webDriver;
        public Hooks(DriverHelper webDriver)
        {
            _webDriver = webDriver;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            ChromeOptions option = new ChromeOptions();
            option.AddArguments("start-maximized");
            // option.AddArguments("--headless");
            _webDriver.Driver = new ChromeDriver(option);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _webDriver.Driver.Quit();
        }
    }
}