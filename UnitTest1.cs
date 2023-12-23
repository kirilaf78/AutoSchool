namespace TestProject4
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support.UI;
    using SeleniumExtras.PageObjects;

    public class LoginPage
    {

        [FindsBy(How = How.XPath, Using = "//p[@class='fc-button-label' and text()='Consent']")]
        public IWebElement ConsentButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='username']")]
        public IWebElement UserName { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='password']")] 
        public IWebElement Password { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='login']")] 
        public IWebElement LoginButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//p[contains(text(),'Hello')]")]
        public IWebElement SuccessfullMessage { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[normalize-space()='Lost your password?']")]

        public IWebElement LostYourPassword { get; set; }

        [FindsBy(How = How.XPath, Using = "//label[normalize-space()='Remember me']")]
        public IWebElement RememberMe { get; set; }
       

    }
    public class LoginPageTests
    {
        IWebDriver webDriver;
        LoginPage loginPage;
        string URL = "https://practice.automationtesting.in/my-account/";


        [SetUp]
        public void Setup()
        {
            webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl(URL);
            webDriver.Manage().Window.Maximize();
            loginPage = new LoginPage();
            PageFactory.InitElements(webDriver, loginPage);
            loginPage.ConsentButton.Click();
        }

        [Test]
        public void IsLoginSuccess()
        {
            string userName = "karage16255@bayxs.com";
            string password = "222uSNj%g";
            loginPage.UserName.SendKeys(userName);
            loginPage.Password.SendKeys(password);
            loginPage.LoginButton.Click();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            Assert.That(loginPage.SuccessfullMessage.Displayed, Is.EqualTo(true), $"User did not logged in");
        }

        [Test]
        public void IsRememberMeDisplayed()
        {
            string expectedResult = "Remember me";
            Assert.That(loginPage.RememberMe.Displayed, Is.EqualTo(true), $"Remember me text is not displayed");

        }

        [Test]
        public void IsLostPasswordDisplayed()
        {
            string expectedResult = "Remember me";
            Assert.That(loginPage.LostYourPassword.Displayed, Is.EqualTo(true), $"Lost your password? text is not displayed");

        }




        [TearDown]
        public void TearDown()
        {
            webDriver.Close();
        }
    }
}