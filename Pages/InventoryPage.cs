using System.Threading.Tasks;
using Microsoft.Playwright;

namespace PlaywrightTests.Pages
{
    public class InventoryPage : BasePage
    {
        private const string LOCATOR_ADD_TSHIRT_BOLT = "#add-to-cart-sauce-labs-bolt-t-shirt";
        private const string LOCATOR_REMOVE_TSHIRT_BOLT = "#remove-test.allthethings()-t-shirt-(red)";
        private const string LOCATOR_ADD_TSHIRT_RED = "#add-to-cart-test.allthethings()-t-shirt-(red)";
        private const string LOCATOR_REMOVE_TSHIRT_RED = "#remove-test.allthethings()-t-shirt-(red)";

        private const string LOCATOR_CART_ITEM_QUANTITY = "#shopping_cart_container .shopping_cart_badge";
        private const string LOCATOR_CART_ICON = "#shopping_cart_container";

        public InventoryPage(IPage page) : base(page) 
        {}

        public async Task AddToCartTShirtBolt()
        {
            await Page.ClickAsync(LOCATOR_ADD_TSHIRT_BOLT);
        }
        public async Task RemoveToCartTShirtBolt()
        {
            await Page.ClickAsync(LOCATOR_REMOVE_TSHIRT_BOLT);
        }

        public async Task AddToCartTShirtRed()
        {
            await Page.ClickAsync(LOCATOR_ADD_TSHIRT_RED);
        }
        public async Task RemoveToCartTShirtRed()
        {
            await Page.ClickAsync(LOCATOR_REMOVE_TSHIRT_RED);
        }

        public async Task CheckCartQuantity(int expectedQuantity)
        {
            var actualQuantity = int.Parse(await Page.InnerTextAsync(LOCATOR_CART_ITEM_QUANTITY));
            Assert.Equal(expectedQuantity, actualQuantity);
        }

        public async Task ClickOnCart()
        {
            await Page.ClickAsync(LOCATOR_CART_ICON);
        }
    }
}