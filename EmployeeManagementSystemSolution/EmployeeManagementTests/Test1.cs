using Microsoft.Playwright.MSTest;
using Microsoft.Playwright;
using System.Text.RegularExpressions;


namespace EmployeeManagementTests
{ 
    [TestClass]
    public class LoginPageTest : PageTest
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

        [TestMethod]
        public async Task LoginWithCorrectInput()
        {
            await Page.GotoAsync("https://localhost:7195/identity/account/login");
            await Page.FillAsync("input[placeholder='Enter your email']", "admin@example.com");
            await Page.FillAsync("input[placeholder='Enter your password']", "pass");
            await Page.ClickAsync("button:has-text('Login')");
            var dialog = await Page.WaitForSelectorAsync("text=Login Success");
            Assert.IsNotNull(dialog, "Login success dialog did not appear.");
            await Page.ClickAsync("button:has-text('OK')");
            await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);

            var currentUrl = Page.Url;
            Assert.AreEqual("https://localhost:7195/home/dashboard", currentUrl, "Redirecționarea nu a avut loc corect.");

        }

        [TestMethod]
        public async Task LoginWithIncorrectInput()
        {
            await Page.GotoAsync("https://localhost:7195/identity/account/login");
            await Page.FillAsync("input[placeholder='Enter your email']", "user@example.com");
            await Page.FillAsync("input[placeholder='Enter your password']", "string");
            await Page.ClickAsync("button:has-text('Login')");
            var alertDialog = await Page.WaitForSelectorAsync("text=Alert");
            Assert.IsNotNull(alertDialog, "Alert dialog did not appear.");
    
        }
    }
}
