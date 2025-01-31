using System.Threading.Tasks;
using Microsoft.Playwright;
using je_t_sauce_dmpr;

namespace PlaywrightTests.Pages
{
    public class LoginPage : BasePage
    {
        private const string LOCATOR_USER_INPUT = "#user-name";
        public const string LOCATOR_PSWD_INPUT = "#password";
        public const string LOCATOR_LOGIN_BTN = "#login-button";

        public LoginPage(IPage page) : base(page)
        {}

        public async Task GotoSaucePage()
        {
            await GoToAsync(Constants.BASE_URL);
        }

        public async Task LoginAs(string username, string password)
        {
            await Page.FillAsync(LOCATOR_USER_INPUT, username);
            await Page.FillAsync(LOCATOR_PSWD_INPUT, password);
            await Page.ClickAsync(LOCATOR_LOGIN_BTN);
        }

        public async Task LoginAsStandardUser()
        {
            await LoginAs(Constants.USER_STANDARD, Constants.PASSWORD);
        }

        public async Task LoginAsStandardUserENV()
        {
            var username = Environment.GetEnvironmentVariable("SAUCE_USERNAME");
            var password = Environment.GetEnvironmentVariable("SAUCE_PASSWORD");
            await LoginAs(username, password);
        }
    }
}