using NUnit.Framework;
using SpecFlowProject1.Pages;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class ElementsCheckBoxStepDefinitions
    {
        ElementsPage _elementsPage;
        CommonPage _commonPage;



        [Given(@"User clicks Check Box title")]
        public void WhenUserClicksCheckBoxTitle()

        {
            _commonPage = (CommonPage)ScenarioContext.Current["CommonPage"];

            _elementsPage = (ElementsPage)ScenarioContext.Current["ElementsPage"];

            _commonPage.ClickConsent();
            _commonPage.ClickSection(_commonPage.SectionElements(_elementsPage.checkBoxSection));

        }

        [When(@"User expands the folder Home")]
        public void WhenUserExpandsTheFolderHome()
        {
            _elementsPage.ClickToggle(_elementsPage.folderHomeNumber);
        }


        [When(@"User selects the folder Desktop without expanding it")]
        public void WhenUserSelectsTheFolderDesktopWithoutExpandingIt()
        {
            _elementsPage.ClickCheckBox(_elementsPage.checkBoxDesktop);
        }

        [When(@"User expands Documents folder")]
        public void WhenUserExpandsDocumentsFolder()
        {
            _elementsPage.ClickToggle(_elementsPage.folderDocumentsNumber);

        }

        [When(@"User expands WorkSpace folder")]
        public void WhenUserExpandsWorkSpaceFolder()
        {
            _elementsPage.ClickToggle(_elementsPage.folderWorkSpaceNumber);
        }

        [When(@"User selects Angular and Veu")]
        public void ThenUserSelectsAngularAndVeu()
        {
            _elementsPage.ClickCheckBox(_elementsPage.checkBoxAngular);
            _elementsPage.ClickCheckBox(_elementsPage.checkBoxVue);

        }

        [When(@"User expands the folder Office")]
        public void WhenUserExpandsTheFolderOffice()
        {
            _elementsPage.ClickToggle(_elementsPage.folderOfficeNumber);
        }

        [When(@"User clicks on each element in the Office folder one by one")]
        public void ThenUserClicksOnEachElementInTheOfficeFolderOneByOne()
        {
            _elementsPage.ScrollDown(_elementsPage.scrollPixels);
            _elementsPage.ClickAllInOfficeFolder();
        }

        [When(@"User click toggle of the folder Downloads")]
        public void WhenUserClickToggleOfTheFolderDownloads()
        {

            _elementsPage.ClickToggleOfTheFolderDownloads();
        }

        [When(@"User clicks title of  Downloads folder \(by clicking on its name\)")]
        public void ThenUserClicksTitleOfDownloadsFolderByClickingOnItsName()
        {
            _elementsPage.ClicksTitleOfDownloadsFolder();
        }

        [Then(@"the output should be ""([^""]*)""")]
        public void ThenTheOutputShouldBe(string expectedOutput)
        {
            Assert.That(_elementsPage.GetActualOutput(), Is.EqualTo(expectedOutput), "The output does not match the expected output");
        }

    }
}
