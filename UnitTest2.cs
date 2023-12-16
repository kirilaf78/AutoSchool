namespace TestProject2
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support.UI;
    using System.Drawing;
    using System.Xml.Linq;
    using static System.Net.Mime.MediaTypeNames;

    public class SelenuimWebDriverTest
    {
        IWebDriver webdriver;
        
        // links with names of all products on the main page 
        public string producstLinks(string productName) => $"//a[contains(@href, 'https') and descendant::h3[text()='{productName}']]";




        [SetUp]
        public void Setup()
        {
            webdriver = new ChromeDriver();
            webdriver.Navigate().GoToUrl("https://practice.automationtesting.in/shop/");

            try
            {
                IWebElement consentButton = webdriver.FindElement(By.XPath("//p[@class='fc-button-label' and text()='Consent']"));
                consentButton.Click();
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("No such an element!");
            }

        }

        [Test]
        public void IsTitleDisplayed()
        {


            IWebElement searchInput = webdriver.FindElement(By.XPath("//input[@id='s']"));

            searchInput.SendKeys("HTML" + Keys.Enter);

            string expectedTitle = "HTML";
            IWebElement element = webdriver.FindElement(By.XPath("//em[contains(text(), 'HTML')]"));
            string actualTitle = element.Text;

            Assert.That(expectedTitle, Is.EqualTo(actualTitle), $"The title: {actualTitle} must be equal to {expectedTitle}");
        }

        [Test]
        public void AreProductNamesLinks()
        {
            string[] productNames = 
            {
             "Android Quick Start Guide",
             "Functional Programming in JS",
             "HTML5 Forms",
             "HTML5 WebApp Develpment",
             "Selenium Ruby",
             "JS Data Structures and Algorithm",
             "Mastering JavaScript",
             "Thinking in HTML"
            };

            foreach (string productName in productNames)
            {
                IWebElement productLink = webdriver.FindElement(By.XPath(producstLinks(productName)));
                string actualText = productLink.Text;
                string hrefAttribute = productLink.GetAttribute("href");

                Assert.That(actualText, Contains.Substring(productName), $"Text does not contain the expected value for {productName}.");
                Assert.That(hrefAttribute, Contains.Substring("https"), $"The href attribute does not contain 'https' for {productName}.");
            }

        }


        [Test]
        public void VerifyRelatedProduct()

        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)webdriver;
            WebDriverWait wait = new WebDriverWait(webdriver, TimeSpan.FromSeconds(10));

            int quantity = 3;


            string productName = "Thinking in HTML";
            IWebElement productLink = webdriver.FindElement(By.XPath(producstLinks(productName)));
            productLink.Click();

            // opening related product
            IWebElement relatedProduct = wait.Until(e=>e.FindElement(By.XPath("//img[contains(@title,\"HTML5 Web Application Development Beginner's guide\")]")));
            js.ExecuteScript("arguments[0].scrollIntoView(true);", relatedProduct);
            // знаю, что следующие 2 строчки вроде бы дублируют функционал, но так, почему-то тест более стабилен
            relatedProduct.Click();
            js.ExecuteScript("arguments[0].click();", relatedProduct);
            
            // Thread.Sleep(3000);
            // adding to basket 1 qty.
            IWebElement addToBasket = webdriver.FindElement(By.XPath("//button[normalize-space()='Add to basket']"));
            js.ExecuteScript("arguments[0].click();", addToBasket);


            // saving related product name
            IWebElement relatedProductElementName = webdriver.FindElement(By.XPath("//h1[normalize-space()='HTML5 WebApp Develpment']"));
            string relatedProductName = relatedProductElementName.Text;

            // saving related product price
            IWebElement relatedProductElementPrice = webdriver.FindElement(By.XPath("//p[@class='price']//span[@class='woocommerce-Price-amount amount']"));
            string relatedProductPrice = relatedProductElementPrice.Text;
            string numericValue = relatedProductPrice.Substring(1);

            // calculating final product price 
            double productPrice = Double.Parse(numericValue);
            double priceForThreeItems = productPrice * quantity;
            string relatedProductFinalPrice = priceForThreeItems.ToString("F2");

            // adding two more to make total of  3 in the basket
            IWebElement productQuantity = webdriver.FindElement(By.XPath("//input[@title='Qty']"));
            productQuantity.Clear();
            productQuantity.SendKeys("2" + Keys.Enter);
            IWebElement viewBasketLink = webdriver.FindElement(By.XPath("//a[@title='View your shopping cart']"));
            viewBasketLink.Click();

            // product name and price in the basket
            IWebElement relatedProductElementNameInBasket = webdriver.FindElement(By.XPath("//a[normalize-space()='HTML5 WebApp Develpment']"));
            string relatedProductNameInBasket = relatedProductElementNameInBasket.Text;
            IWebElement relatedProductPriceElementInBasket = webdriver.FindElement(By.XPath("//td[@class='product-subtotal']//span[@class='woocommerce-Price-amount amount']"));
            string relatedProductPriceInBasket = relatedProductPriceElementInBasket.Text;
            string numericValueOfPriceInBasket = relatedProductPriceInBasket.Substring(1);

            Assert.That(relatedProductName, Is.EqualTo(relatedProductNameInBasket), "Product name is not the same as product name in the basket");
            Assert.That(relatedProductFinalPrice, Is.EqualTo(numericValueOfPriceInBasket), "Product price times 3 is not equal to product price in the basket");

        }






        [TearDown]
        public void TearDown()
        {
            webdriver.Close();
        }
    }
}
