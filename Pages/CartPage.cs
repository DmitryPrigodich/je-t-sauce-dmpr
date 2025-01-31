using System.Threading.Tasks;
using Microsoft.Playwright;

namespace PlaywrightTests.Pages
{
    public class CartPage : BasePage
    {
        private const string LOCATOR_ITEM_QTY = "/ancestor::div[@class='cart_item']//div[@class='cart_quantity']";
        private const string LOCATOR_ITEM_PRICE = "/ancestor::div[@class='cart_item']//div[@class='inventory_item_price']";
        private const string LOCATOR_CHECKOUT_BTN = "#checkout";
        private const string LOCATOR_REMOVE_TSHIRT_RED = "#remove-test.allthethings()-t-shirt-(red)";


        public CartPage(IPage page) : base(page)
        {}


        public async Task CheckItemQTY(string itemName, int expectedQuantity)
        {
            var actualQuantity = int.Parse(await Page.InnerTextAsync($"//div[text()='{itemName}']" + LOCATOR_ITEM_QTY));
            Assert.Equal(expectedQuantity, actualQuantity);
        }

        public async Task CheckItemPrice(string itemName, string expectedPrice)
        {
            var actualPrice = await Page.InnerTextAsync($"//div[text()='{itemName}']" + LOCATOR_ITEM_PRICE);
            Assert.Equal(expectedPrice, actualPrice);
        }

        public async Task ClickCheckout()
        {
            await Page.ClickAsync(LOCATOR_CHECKOUT_BTN);
        }

        public async Task RemoveToCartTShirtRed()
        {
            await Page.ClickAsync(LOCATOR_REMOVE_TSHIRT_RED);
        }
    }
}