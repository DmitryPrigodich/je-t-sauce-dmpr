using System.Threading.Tasks;
using Microsoft.Playwright;

namespace PlaywrightTests.Pages
{
    public class CheckoutStepOnePage : BasePage
    {
        private const string LOCATOR_FIRST_NAME = "#first-name";
        private const string LOCATOR_LAST_NAME = "#last-name";
        private const string LOCATOR_ZIP_CODE = "#postal-code";
        private const string LOCATOR_CONTINUE_BTN = "#continue";

        public CheckoutStepOnePage(IPage page) : base(page)
        {
            //Assert.Contains("checkout-step-one.html", page.Url);
        }

        public async Task InputFirstName(string firstName)
        {
            await Page.FillAsync(LOCATOR_FIRST_NAME, firstName);
        }

        public async Task InputLastName(string lastName)
        {
            await Page.FillAsync(LOCATOR_LAST_NAME, lastName);
        }

        public async Task InputZIP(string zip)
        {
            await Page.FillAsync(LOCATOR_ZIP_CODE, zip);
        }

        public async Task ClickContinue()
        {
            await Page.ClickAsync(LOCATOR_CONTINUE_BTN);
        }
    }
}