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

        }
    }
