using Microsoft.Playwright;

namespace PlaywrightTests.Pages
{
    public abstract class BasePage
    {
        protected IPage Page { get; }

        protected BasePage(IPage page)
        {
            Page = page;
        }

        public virtual async Task GoToAsync(string url)
        {
            await Page.GotoAsync(url);
        }

        public virtual async Task WaitForSelectorAsync(string selector)
        {
            await Page.WaitForSelectorAsync(selector);
        }

        public virtual async Task WaitForAWhile(int seconds)
        {
            await Page.WaitForTimeoutAsync(seconds * 1000);
        }
    }
}