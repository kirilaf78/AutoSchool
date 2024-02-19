using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject1.Pages
{
    public class WidgetsPage : CommonPage
    {

        IWebDriver webDriver;


        public WidgetsPage(IWebDriver webDriver) : base(webDriver)
        {
            this.webDriver = webDriver;
        }


    }
}
