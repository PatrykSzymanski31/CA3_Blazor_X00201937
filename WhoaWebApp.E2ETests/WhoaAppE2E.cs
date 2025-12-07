using Microsoft.Playwright;

namespace WhoaWebApp.E2ETests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class Tests : PageTest
    {
        [Test]
        public async Task RandomWhoaTest()
        {
            await Page.GotoAsync("https://localhost:7001/random-whoa");

            // Adjust text to match your heading
            await Expect(Page.GetByText("Random Whoa")).ToBeVisibleAsync();

            // Give API/Blazor a moment
            await Page.WaitForTimeoutAsync(3000);

            await Expect(Page.GetByText("Character:")).ToBeVisibleAsync();
            await Expect(Page.GetByText("Director:")).ToBeVisibleAsync();
            await Expect(Page.GetByText("Timestamp:")).ToBeVisibleAsync();
            await Expect(Page.GetByText("Line:")).ToBeVisibleAsync();

            var newButton = Page.GetByRole(AriaRole.Button, new() { NameString = "New random whoa" });
            await newButton.ClickAsync();

            // Wait again for the new data
            await Page.WaitForTimeoutAsync(3000);

            // Re-check that details are still present (page didn't break)
            await Expect(Page.GetByText("Character:")).ToBeVisibleAsync();
            await Expect(Page.GetByText("Director:")).ToBeVisibleAsync();
            await Expect(Page.GetByText("Timestamp:")).ToBeVisibleAsync();
            await Expect(Page.GetByText("Line:")).ToBeVisibleAsync();
        }

    }
}
