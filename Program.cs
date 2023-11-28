namespace XpathCss
{
    internal class Program
    {
        // Parameterized XPath reference number 1
        public string testCasesLink = "//a[normalize-space()='Test Cases']";
        //CSS:
        // public string testCasesLink = "a[href='https://practice.automationtesting.in/test-cases/']";

        public string searchIcon = "//i[@class='icon-search']";
        //public string searchIcon = ".icon-search";

        public string pullDownLink = "//a[@class='pull-down']";
        //public string pullDownLink = ".pull-down";

        public string filterButton = "//button[normalize-space()='Filter']";
        // public string filterButton = "button[type='submit']";

        // Parameterized XPath reference number 2
        public string javaScriptLink = "//li[@class='cat-item cat-item-21']";
        // public string javaScriptLink = ".cat-item.cat-item-21";

        // Parameterized XPath reference number 3
        public string androidLearning = "//li[contains(@class, 'post-169')]";
        // public string androidLearning = ".post-169";

        // Parameterized XPath reference number 4
        public string htmlFormsPrice = "(//span[contains(@class,'woocommerce-Price-amount amount')])[4]";
        // or another XPath:
        // public string htmlFormsPrice = //span[@class='woocommerce-Price-amount amount' and text()='280.00'];
        // public string htmlFormsPrice = "div > ul > li:nth-child(3) > a > span > span"

        // Parameterized XPath reference number 5
        public string sortByNewness = "//select[@name='orderby']/option[@value='date']";
        // public string sortByNewness = "select[name='orderby'] option[value='date']";

        public string emailAddressInput = "//input[@placeholder='Your email address']";
        // public string emailAddressInput = "input[placeholder='Your email address']";

        public string footerYear = "//div[@class='one']/text()[last()]";
        // css selector for "2023" does not exist 


        //Parameterized XPath

        // 1. header links such as 'Shop', 'MyAccount', 'Test Cases', etc
        public string headerLinks(string linkName) => $"//a[normalize-space()={linkName}]";

        //2. PRODUCT CATEGORIES links such as 'Android', 'HTML', 'JavaScript', 'selenium'
        public string productLinks(string linkNumber) => $"//li[@class='cat-item cat-item-{linkNumber}']";

        // 3. Products of Sale such as 'Android Quick Start Guide', 'Functional Programming in JS', etc
        public string productOnSale(string postNumber) => $"//li[contains(@class, 'post-{postNumber}')]";

        // 4. Product price such as '280', '250', etc.
        public string productPrice(string indexNumber) => $"(//span[contains(@class,'woocommerce-Price-amount amount')])[{indexNumber}]";

        // 5. Sort by select such as 'Sort by populatity', 'Sort by newness', etc
        public string sortByselect(string valueName) => $"//select[@name='orderby']/option[@value='{valueName}']";





        static void Main(string[] args)
        {

        }
    }
}

