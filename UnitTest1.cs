
namespace TestProject3
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support.UI;

    public class LoginPage
    {
        IWebDriver webDriver;

        public LoginPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        private WebDriverWait CreateWebdriverWait(TimeSpan time)
        {
            return new WebDriverWait(webDriver, time);
        }

        private IWebElement RegEmailInput => webDriver.FindElement(By.XPath("//input[@id='reg_email']"));
        private IWebElement RegPasswordInput => webDriver.FindElement(By.XPath("//input[@id='reg_password']"));
        private IWebElement RegisterButton => webDriver.FindElement(By.XPath("//input[@name='register']"));
        private IWebElement LoginUsername => webDriver.FindElement(By.XPath("//input[@id='username']"));
        private IWebElement LoginPassword => webDriver.FindElement(By.XPath("//input[@id='password']"));
        private IWebElement LoginButton => webDriver.FindElement(By.XPath("//input[@name='login']"));

        private IWebElement AccountExistsMessage => webDriver.FindElement(By.XPath("//li[contains(text(),'An account is already registered with your email a')]"));
        private IWebElement SuccessMessage => webDriver.FindElement(By.XPath("//p[contains(text(),'Hello')]"));
        private IWebElement NoRegPassword => webDriver.FindElement(By.XPath("//div[@id='body'][.//li[contains(., 'Error') and contains(., 'Please enter an account password.')]]"));
        private IWebElement NoRegEmail => webDriver.FindElement(By.XPath("//div[@id='body'][.//li[contains(., 'Error') and contains(., 'Please provide a valid email address.')]]"));

        private IWebElement LostYourPassword => webDriver.FindElement(By.CssSelector("a[href='https://practice.automationtesting.in/my-account/lost-password/']"));
        private IWebElement RememberMe => webDriver.FindElement(By.CssSelector("label[for='rememberme']"));


        public LoginPage EnterRegEmail(string email)
        {
            RegEmailInput.SendKeys(email);
            return this;
        }

        public LoginPage EnterRegPassword(string password)
        {
            RegPasswordInput.SendKeys(password);
            return this;
        }

        public LoginPage ClickRegisterButton()
        {
            RegisterButton.Click();
            return this;
        }
        public LoginPage EnterUserName(string email)
        {
            LoginUsername.SendKeys(email);
            return this;
        }

        public LoginPage EnterPassword(string password)
        {
            LoginPassword.SendKeys(password);
            return this;
        }

        public LoginPage ClickLoginButton()
        {
            LoginButton.Click();
            return this;
        }

        public bool IsAccountExistMessage()
        {
            WebDriverWait wait = CreateWebdriverWait(TimeSpan.FromSeconds(5));
            IWebElement element = wait.Until(e => AccountExistsMessage);
            return AccountExistsMessage.Displayed;
        }

        public bool IsLoginSuccessfull()
        {
            WebDriverWait wait = CreateWebdriverWait(TimeSpan.FromSeconds(3));
            IWebElement element = wait.Until(e => SuccessMessage);
            return SuccessMessage.Displayed;
        }
        public bool IsPasswordNeededToReg()
        {
            WebDriverWait wait = CreateWebdriverWait(TimeSpan.FromSeconds(3));
            IWebElement element = wait.Until(e => NoRegPassword);
            return NoRegPassword.Displayed;

        }

        public bool NoRegEmailWarning()
        {
            WebDriverWait wait = CreateWebdriverWait(TimeSpan.FromSeconds(3));
            IWebElement element = wait.Until(e => NoRegEmail);
            return NoRegEmail.Displayed;

        }

        public string GetLostYourPasswordText()
        {
            return LostYourPassword.Text;
        }

        public string GetRememberMeText()
        {
            return RememberMe.Text;
        }

        public string GetRegisterText()
        {
            return RegisterButton.GetAttribute("value");
        }

    }
    public class LoginPageTest
    {

        IWebDriver webDriver;
        LoginPage loginPage;
        string URL = "https://practice.automationtesting.in/my-account/";



        [SetUp]
        public void SetUp()
        {
            webDriver = new ChromeDriver();
            loginPage = new LoginPage(webDriver);
            webDriver.Navigate().GoToUrl(URL);
            webDriver.Manage().Window.Maximize();
            try
            {
                IWebElement consentButton = webDriver.FindElement(By.XPath("//p[@class='fc-button-label' and text()='Consent']"));
                consentButton.Click();
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("No such an element!");
            }

        }
        // account is already registered message

        [TestCase("karage16255@bayxs.com", "222uSNj%g")]
        public void IsAccountRegistered(string email, string password)
        {
            loginPage.EnterRegEmail(email)
                     .EnterRegPassword(password)
                     .ClickRegisterButton();
            Assert.That(loginPage.IsAccountExistMessage(), Is.EqualTo(true), "The account exists message is not displayed");
        }

        [TestCase("karage16255@bayxs.com", "222uSNj%g")]

        public void IsLoginSuccess(string email, string password)
        {
            loginPage.EnterUserName(email)
                     .EnterPassword(password)
                     .ClickLoginButton();
            Assert.That(loginPage.IsLoginSuccessfull(), Is.EqualTo(true), "The success message is not displayed");

        }
        // error message displayed when user did not enter password on registration

        [TestCase("sarage16255@bayxs.com")]
        public void IsNoRegPasswordWarning(string email)
        {
            loginPage.EnterRegEmail(email)
                     .ClickRegisterButton();

            Assert.That(loginPage.IsPasswordNeededToReg, Is.EqualTo(true), "The success message is not displayed");

        }
        // error message displayed when user did not enter email on registration


        [TestCase("222uSNj%g")]

        public void IsNoRegEmailWarning(string password)
        {
            loginPage.EnterRegPassword(password)
                     .ClickRegisterButton();

            Assert.That(loginPage.NoRegEmailWarning, Is.EqualTo(true), "The success message is not displayed");

        }

        //[Test]

        //public void IsLostPasswordText()
        //{
        //    string expectedResult = "Lost your password?";
        //    Assert.That(loginPage.GetLostYourPasswordText(), Is.EqualTo(expectedResult), "The text doesn't equal to expectedResult");
        //}


        //[Test]

        //public void IsRememberMeText() 
        //{
        //    string expectedResult = "Remember me";
        //    Assert.That(loginPage.GetRememberMeText(), Is.EqualTo(expectedResult), "The text doesn't equal to expectedResult");
        //}

        //[Test]

        //public void IsRegisterText() 
        //{
        //    string expectedResult = "Register";
        //    Assert.That(loginPage.GetRegisterText(), Is.EqualTo(expectedResult), "The text doesn't equal to expectedResult");
        //}

        [TestCase("Lost your password?", TestName = "LostPasswordText")]
        [TestCase("Remember me", TestName = "RememberMeText")]
        [TestCase("Register", TestName = "RegisterText")]
        public void CheckText(string expectedText)
        {
            string actualText = "";

            switch (TestContext.CurrentContext.Test.Name)
            {
                case "LostPasswordText":
                    actualText = loginPage.GetLostYourPasswordText();
                    break;
                case "RememberMeText":
                    actualText = loginPage.GetRememberMeText();
                    break;
                case "RegisterText":
                    actualText = loginPage.GetRegisterText();
                    break;
            }

            Assert.That(actualText, Is.EqualTo(expectedText), $"The text doesn't equal to {expectedText}");
        }


        [TearDown]
        public void TearDown()
        {
            webDriver.Close();
        }
    }
}