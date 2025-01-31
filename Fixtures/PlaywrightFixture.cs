using System.Threading.Tasks;
using Microsoft.Playwright;
using Xunit;

namespace PlaywrightTests.Fixtures
{
    public class PlaywrightFixture : IAsyncLifetime
    {
        public IPlaywright Playwright { get; private set; }
        public IBrowser Browser { get; private set; }

        
        public async Task InitializeAsync()
        {
            Playwright = await Microsoft.Playwright.Playwright.CreateAsync();
            Browser = await Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
            });
        }

        public async Task DisposeAsync()
        {
            if (Browser != null)
                await Browser.CloseAsync();

            Playwright?.Dispose();
        }
    }
}