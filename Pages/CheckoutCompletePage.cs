using System.Threading.Tasks;
using Microsoft.Playwright;

namespace PlaywrightTests.Pages
{
    public class CheckoutCompletePage : BasePage
    {
        private const string LOCATOR_PAGE_TEXT = ".complete-header";
        private const string LOCATOR_BACK_HOME_BTN = "#back-to-products";

        public CheckoutCompletePage(IPage page) : base(page)
        {
            //Assert.Contains("checkout-complete.html", page.Url);
        }

        public async Task CheckPageHeader(string expectedText)
        {
            var actualText = await Page.InnerTextAsync(LOCATOR_PAGE_TEXT);
            Assert.Equal(expectedText, actualText);
        }

        public async Task ClickBackHome()
        {
            await Page.ClickAsync(LOCATOR_BACK_HOME_BTN);
        }
    }
}