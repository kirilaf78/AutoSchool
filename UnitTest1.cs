namespace TestProject4
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
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

        [FindsBy(How = How.CssSelector, Using = "a[href='https://practice.automationtesting.in/my-account/lost-password/']")]

        public IWebElement LostYourPassword { get; set; }

        [FindsBy(How = How.CssSelector, Using = "label[for='rememberme']")]
        public IWebElement RememberMe { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='register']")]
        public IWebElement RegisterButton { get; set; }

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

        [TestCase("karage16255@bayxs.com", "222uSNj%g")]
        public void IsLoginSuccess(string userName, string password)
        {
            loginPage.UserName.SendKeys(userName);
            loginPage.Password.SendKeys(password);
            loginPage.LoginButton.Click();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            Assert.That(loginPage.SuccessfullMessage.Displayed, Is.EqualTo(true), $"User did not logged in");
        }

        [TestCase("Remember me")]
        public void IsRememberMeDisplayed(string expectedResult)
        {
            Assert.That(loginPage.RememberMe.Text, Is.EqualTo(expectedResult), $"Remember me text is not displayed");

        }

        [TestCase("Lost your password?")]
        public void IsLostPasswordDisplayed(string expectedResult)
        {
            Assert.That(loginPage.LostYourPassword.Text, Is.EqualTo(expectedResult), $"Lost your password? text is not displayed");

        }

        [TestCase("Register")]
        public void IsRegisterDisplayed(string expectedResult)
        {
            Assert.That(loginPage.RegisterButton.GetAttribute("value"), Is.EqualTo(expectedResult), $"Register text is not displayed");
        }



        [TearDown]
        public void TearDown()
        {
            webDriver.Close();
        }
    }
}