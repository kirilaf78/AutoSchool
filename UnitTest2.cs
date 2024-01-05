namespace TestProject2
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support.UI;

    public class SelenuimWebDriverTest
    {
        IWebDriver webdriver;

        // links with names of all products on the main page 
        public string title = "HTML";
        public string productName = "Thinking in HTML";
        public string saleTitle = "SALE!";
        public int quantity = 3;

        public string producstLinks(string productName) => $"//a[contains(@href, 'https') and descendant::h3[text()='{productName}']]";


        [SetUp]
        public void Setup()
        {
            webdriver = new ChromeDriver();
            webdriver.Navigate().GoToUrl("https://practice.automationtesting.in/shop/");
            webdriver.Manage().Window.Maximize();


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

            searchInput.SendKeys(title + Keys.Enter);

            IWebElement pageTitle = webdriver.FindElement(By.XPath($"//h1[@class='page-title']"));
            string actualTitle = pageTitle.Text;

            Assert.That(actualTitle, Does.Contain(title), $"The title: {actualTitle} must contain {title}");
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

        public void VerifySaleMarkPriceAndDiscount()
        {
            IWebElement productLink = webdriver.FindElement(By.XPath(producstLinks(productName)));
            productLink.Click();
            IWebElement saleMark = webdriver.FindElement(By.XPath("//span[@class='onsale']"));
            IWebElement priceElement = webdriver.FindElement(By.XPath("//del//span[@class='woocommerce-Price-amount amount']"));
            IWebElement discountPriceElement = webdriver.FindElement(By.XPath("//ins//span[@class='woocommerce-Price-amount amount']"));

            string actualText = saleMark.Text;
            string actualRegularPrice = priceElement.Text.Substring(1);
            string actualDiscountedPrice = discountPriceElement.Text.Substring(1);

            Assert.That(saleTitle, Is.EqualTo(actualText), $"The title: {actualText} must be equal to {saleMark}");
            Assert.That(actualRegularPrice, Is.Not.Empty, "Regular price should be displayed");
            Assert.That(actualDiscountedPrice, Is.Not.Empty, "Discounted price should be displayed");

        }


        [Test]
        public void VerifyRelatedProduct()

        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)webdriver;
            WebDriverWait wait = new WebDriverWait(webdriver, TimeSpan.FromSeconds(10));



            IWebElement productLink = webdriver.FindElement(By.XPath(producstLinks(productName)));
            productLink.Click();

            // opening related product
            IWebElement relatedProduct = wait.Until(e => e.FindElement(By.XPath("//img[@title=\"HTML5 Web Application Development Beginner's guide\"]")));

            js.ExecuteScript("arguments[0].scrollIntoView(true);", relatedProduct);
            // следующие 2 строчки вроде бы дублируют функционал, но так, почему-то тест более стабилен
            relatedProduct.Click();
            js.ExecuteScript("arguments[0].click();", relatedProduct);

            // adding to basket 1 qty.
            IWebElement addToBasket = webdriver.FindElement(By.XPath("//button[normalize-space()='Add to basket']"));
            js.ExecuteScript("arguments[0].click();", addToBasket);


            // saving related product name
            IWebElement relatedProductElementName = webdriver.FindElement(By.XPath("//h1[normalize-space()='HTML5 WebApp Develpment']"));
            string relatedProductName = relatedProductElementName.Text;

            // saving related product price
            IWebElement relatedProductPriceElement = webdriver.FindElement(By.XPath("//p[@class='price']//span[@class='woocommerce-Price-amount amount']"));
            string relatedProductPrice = relatedProductPriceElement.Text.Substring(1);

            // calculating final product price 
            double productPrice = Double.Parse(relatedProductPrice);
            double priceForThreeItems = productPrice * quantity;
            string relatedProductFinalPrice = priceForThreeItems.ToString("F2");

            // Setting the product quantity to a total of 3 in the basket
            IWebElement viewBasketLink = webdriver.FindElement(By.XPath("//a[@title='View your shopping cart']"));
            viewBasketLink.Click();
            IWebElement productQuantityInBasket = webdriver.FindElement(By.XPath("//input[@title='Qty']"));
            productQuantityInBasket.Clear();
            productQuantityInBasket.SendKeys("3" + Keys.Enter);


            Thread.Sleep(3000);
            // product name and price in the basket

            IWebElement relatedProductElementNameInBasket = wait.Until(e => e.FindElement(By.XPath("//a[normalize-space()='HTML5 WebApp Develpment']")));
            string relatedProductNameInBasket = relatedProductElementNameInBasket.Text;
            IWebElement relatedProductPriceElementInBasket = wait.Until(e => e.FindElement(By.XPath("//td[@class='product-subtotal']//span[@class='woocommerce-Price-amount amount']")));
            string relatedProductPriceInBasket = relatedProductPriceElementInBasket.Text.Substring(1);
            Console.WriteLine($"Actual Product Price in Basket: {relatedProductPriceInBasket}");

            Assert.That(relatedProductName, Is.EqualTo(relatedProductNameInBasket), "Product name is not the same as product name in the basket");
            Assert.That(relatedProductFinalPrice, Is.EqualTo(relatedProductPriceInBasket), "Product price times 3 is not equal to product price in the basket");
        }






        [TearDown]
        public void TearDown()
        {
            webdriver.Close();
        }
    }
}
