using OpenQA.Selenium;

namespace SpecFlowProject1.Pages
{

    public class FormsPage : CommonPage
    {
        IWebDriver webDriver;


        public FormsPage(IWebDriver webDriver) : base(webDriver)
        {
            this.webDriver = webDriver;
        }

        public string formsTitle = "Forms";
        public string practiceFormSection = "Practice Form";



    }
}
