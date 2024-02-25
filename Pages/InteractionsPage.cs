using OpenQA.Selenium;

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
        public IList<string> gridSquareNumbers = new List<string> { "One", "Three", "Five", "Seven", "Nine" };
        public IWebElement GridTab => webDriver.FindElement(By.XPath("//a[@id='demo-tab-grid']"));
        public IWebElement GridElement(string number) => webDriver.FindElement(By.XPath($"//li[normalize-space()='{number}']"));
        public IList<IWebElement> ActiveGridElements => webDriver.FindElements(By.XPath("//div[@id='gridContainer']//li[contains(@class, 'active')]"));
        // Initializing a list to store the actual values
        public List<string> actualSquareNumbers = new List<string>();

        public void ClickGridSquare()
        {
            foreach (var gridSquareNumber in gridSquareNumbers)
            {
                ClickElement(GridElement(gridSquareNumber));
            }
        }

        public void GetActiveSquareNumbers()
        {
            foreach (var gridSquareNumber in ActiveGridElements)
            {
                actualSquareNumbers.Add(gridSquareNumber.Text.Trim());
            }
        }


    }
}
