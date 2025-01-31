using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace PlaywrightTests.Pages
{
    public class CheckoutStepTwoPage : BasePage
    {
        private const string LOCATOR_ITEM_TOTAL = ".summary_subtotal_label";
        private const string LOCATOR_TAX = ".summary_tax_label";
        private const string LOCATOR_TOTAL = ".summary_total_label";
        private const string LOCATOR_FINISH_BTN = "#finish";
        private const string LOCATOR_CANCEL_BTN = "#cancel";


        public CheckoutStepTwoPage(IPage page) : base(page)
        {
            //Assert.Contains("checkout-step-two.html", page.Url);
        }

        public async Task CheckItemTotal(string expectedTotal)
        {
            var actualTotalText = await Page.InnerTextAsync(LOCATOR_ITEM_TOTAL);
            var actualTotal = Regex.Match(actualTotalText, @"\d+\.\d{2}").Value;
            Assert.Equal(expectedTotal, actualTotal);
        }

        public async Task CheckTax(string expectedTax)
        {
            var actualTaxText = await Page.InnerTextAsync(LOCATOR_TAX);
            var actualTax = Regex.Match(actualTaxText, @"\d+\.\d{2}").Value;
            Assert.Equal(expectedTax, actualTax);
        }

        public async Task CheckTotal(string expectedTotal)
        {
            var actualTotalText = await Page.InnerTextAsync(LOCATOR_TOTAL);
            var actualTotal = Regex.Match(actualTotalText, @"\d+\.\d{2}").Value;
            Assert.Equal(expectedTotal, actualTotal);
        }

        public async Task ClickFinish()
        {
            await Page.ClickAsync(LOCATOR_FINISH_BTN);
        }
        public async Task ClickCancel()
        {
            await Page.ClickAsync(LOCATOR_CANCEL_BTN);
        }
    }
}