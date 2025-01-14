using Microsoft.Playwright.MSTest;
using Microsoft.Playwright;
using System.Text.RegularExpressions;


namespace EmployeeManagementTests
{
    [TestClass]
    public class ExampleTest : PageTest
    {
        [TestMethod]
        public async Task HasTitle()
        {
            await Page.GotoAsync("https://playwright.dev");

            // Expect a title "to contain" a substring.
            await Expect(Page).ToHaveTitleAsync(new Regex("Playwright"));
        }

        [TestMethod]
        public async Task GetStartedLink()
        {
            await Page.GotoAsync("https://playwright.dev");

            // Click the get started link.
            await Page.GetByRole(AriaRole.Link, new() { Name = "Get started" }).ClickAsync();

            // Expects page to have a heading with the name of Installation.
            await Expect(Page.GetByRole(AriaRole.Heading, new() { Name = "Installation" })).ToBeVisibleAsync();
        }
    }

    [TestClass]
    public class RedirectTests : PageTest
    {
        [TestMethod]
        public async Task SignUpButtonIsClicked()
        {
            await Page.GotoAsync("https://localhost:7195/identity/account/login");
            await Page.WaitForSelectorAsync("a:has-text('Sign Up')", new() { State = WaitForSelectorState.Visible });
            await Page.ClickAsync("a:has-text('Sign Up')");
            await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);

            var currentUrl = Page.Url;
            Assert.AreEqual("https://localhost:7195/identity/account/register", currentUrl, "Redirecționarea nu a avut loc corect.");
        }
    }
}
