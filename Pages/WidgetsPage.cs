using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;

namespace SpecFlowProject1.Pages
{
    public class WidgetsPage : CommonPage
    {

        IWebDriver webDriver;
        WebDriverWait wait;
        public WidgetsPage(IWebDriver webDriver) : base(webDriver)
        {
            this.webDriver = webDriver;
        }
        public string widgetsTitle = "Widgets";
        public string autoCompleteSection = "Auto Complete";
        public string multiColorInput = "autoCompleteMultipleInput";
        public string singleColorInput = "autoCompleteSingleInput";
        public string progressBarSection = "Progress Bar";
        public string startStopButton = "startStopButton";
        public string resetButton = "resetButton";

        public IWebElement ColorNamesInputs(string input) => webDriver.FindElement(By.XPath($"//input[@id='{input}']"));
        public IWebElement SingleColorNameInput => webDriver.FindElement(By.XPath("//input[@id='autoCompleteSingleInput']"));
        public IWebElement AutoCompleteElement(string number) => webDriver.FindElement(By.XPath($"//*[@id=\"react-select-2-option-{number}\"]"));
        public ReadOnlyCollection<IWebElement> AutoCompleteOptions => webDriver.FindElements(By.XPath(".//div[contains(@class, 'auto-complete__option')]"));
        public IWebElement Buttons(string buttonName) => webDriver.FindElement(By.XPath($"//button[@id='{buttonName}']"));
        public IWebElement ProgressBar => webDriver.FindElement(By.XPath($"//div[@id='progressBar']/div[@role='progressbar']"));
        public List<string> colors = new List<string> { "Red", "Yellow", "Green", "Blue", "Purple" };

        //Typing "g" letter
        public void TypeLetter(string input, string letter)
        {
            ColorNamesInputs(input).Click();
            ColorNamesInputs(input).SendKeys(letter);
        }
        public bool DoesContainLetter(string letter)
        {
            foreach (var option in AutoCompleteOptions)
            {
                string color = option.Text;
                if (!color.ToLower().Contains(letter))
                {
                    return false;
                }

            }
            return true;
        }
        // Entering colors
        public void EnterColor(List<string> colors)
        {
            string allColors = string.Join(" ", colors);
            SingleColorNameInput.Click();
            SingleColorNameInput.SendKeys(allColors);
        }

        public void RemoveColors()
        {
            // Getting the current value of the input field
            string currentColors = SingleColorNameInput.GetAttribute("value");

            // Removing "Yellow" and "Purple" from the string
            string updatedColors = currentColors.Replace(" Yellow", "").Replace(" Purple", "");

            // Clearing the input field
            SingleColorNameInput.Clear();

            // Entering the updated string into the input field
            SingleColorNameInput.SendKeys(updatedColors);

        }

        public bool VerifyRemainingColors()
        {
            // Get the remaining colors from the input field
            string remainingColors = SingleColorNameInput.GetAttribute("value");

            // Check if only "Red", "Green", and "Blue" are present
            return remainingColors.Contains("Red") && remainingColors.Contains("Green") && remainingColors.Contains("Blue")
                && !remainingColors.Contains("Yellow") && !remainingColors.Contains("Purple");
        }

        public void WaitForCompletion(string number)
        {
            wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));

            //Wait for the progress to reach 100%
            wait.Until(webDriver => GetText(ProgressBar) == number);
        }


    }
}
