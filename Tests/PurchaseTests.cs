using System.Threading.Tasks;
using je_t_sauce_dmpr;
using Microsoft.Playwright;
using PlaywrightTests.Fixtures;
using PlaywrightTests.Pages;
using Xunit;

namespace PlaywrightTests.Tests
{
    public class PurchaseTests : IClassFixture<PlaywrightFixture>
    {
        private readonly IBrowser _browser;

        public PurchaseTests(PlaywrightFixture fixture)
        {
            _browser = fixture.Browser;
        }

        [Fact]
        public async Task TestBuyTShirtHappyPath()
        {
            var context = await _browser.NewContextAsync();
            var page = await context.NewPageAsync();

            // GET THROUGH LOGIN PAGE
            var loginPage = new LoginPage(page);
            await loginPage.GotoSaucePage();
            await loginPage.LoginAsStandardUserENV();
            Assert.Contains("inventory.html", page.Url);

            // GET THROUGH PRODUCTS PAGE
            var productsPage = new InventoryPage(page);
            await productsPage.AddToCartTShirtBolt();
            await productsPage.CheckCartQuantity(1);
            await productsPage.ClickOnCart();
            Assert.Contains("cart.html", page.Url);

            // GET THROUGH CART PAGE
            var cartPage = new CartPage(page);
            await cartPage.CheckItemQTY("Sauce Labs Bolt T-Shirt", 1);
            await cartPage.CheckItemPrice("Sauce Labs Bolt T-Shirt", "$15.99");
            await cartPage.ClickCheckout();
            Assert.Contains("checkout-step-one.html", page.Url);

            // GET THROUGH CHECKOUT STEP ONE PAGE
            var checkoutPage = new CheckoutStepOnePage(page);
            await checkoutPage.InputFirstName("TestFName");
            await checkoutPage.InputLastName("TestLName");
            await checkoutPage.InputZIP("TestZIP");
            await checkoutPage.ClickContinue();
            Assert.Contains("checkout-step-two.html", page.Url);

            // GET THROUGH CHECKOUT STEP TWO PAGE
            var checkoutOVPage = new CheckoutStepTwoPage(page);
            await checkoutOVPage.CheckItemTotal("15.99");
            await checkoutOVPage.CheckTax("1.28");
            await checkoutOVPage.CheckTotal("17.27");
            await checkoutOVPage.ClickFinish();
            Assert.Contains("checkout-complete.html", page.Url);

            // GET THROUGH CHECKOUT COMPLETE PAGE
            var checkoutEndPage = new CheckoutCompletePage(page);
            await checkoutEndPage.CheckPageHeader("Thank you for your order!");
            await checkoutEndPage.ClickBackHome();
            Assert.Contains("inventory.html", page.Url);

            await context.CloseAsync();
        }

        //[Fact]
        //public async Task TestLoginDifferentUsers() { }
        //public async Task TestLoginWrongUser() { }
        //public async Task TestLoginWrongPassword() { }

        //[Fact]
        //public async Task TestInventoryAddRemoveItems() { }
        //public async Task TestInventorySortItems() { }
        //public async Task TestInventoryAddMultipleItems() { }

        //[Fact]
        //public async Task TestInventoryItemClickItem() { }
        //public async Task TestInventoryItemAddItem() { }
        //public async Task TestInventoryItemRemoveItem() { }
        //public async Task TestInventoryItemBackToProducts() { }

        //[Fact]
        //public async Task TestCartReturnToInventory() { }
        //public async Task TestCartRemoveItems() { }

        //[Fact]
        //public async Task TestCheckoutStepOneWrongFirstName() { }
        //public async Task TestCheckoutStepOneWrongLastName() { }
        //public async Task TestCheckoutStepOneWrongZIPCode() { }
        //public async Task TestCheckoutStepOneCancel() { }

        //[Fact]
        //public async Task TestCheckoutStepTwoCancel() { }

    }
}
