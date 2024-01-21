using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject1.Drivers
{
    public class WebDriverFactory
    {
        public static IWebDriver CreateWebDriver()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("start-maximized");

            return new ChromeDriver(chromeOptions);
        }
    }
}
