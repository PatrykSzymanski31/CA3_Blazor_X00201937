using Microsoft.Playwright;

namespace WhoaWebApp.E2ETests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class Tests : PageTest
    {
        [Test]
        public async Task RandomWhoaTestFindExtraWhoa()
        {
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
            });
            var context = await browser.NewContextAsync();
            var page = await context.NewPageAsync();
            await page.GotoAsync("https://patrykszymanski31.github.io/CA3_Blazor_X00201937/");
            await page.GetByRole(AriaRole.Heading, new() { Name = "Whoa! Hey there!" }).ClickAsync();
            await page.GetByRole(AriaRole.Link, new() { Name = " Random Whoa" }).ClickAsync();
            await page.WaitForURLAsync("https://patrykszymanski31.github.io/CA3_Blazor_X00201937/random-whoa");
            await page.GetByRole(AriaRole.Heading, new() { Name = "Random Keanu \"Whoa\"" }).ClickAsync();
            await page.GetByText("Character:").ClickAsync();
            await page.GetByRole(AriaRole.Heading, new() { Name = "Movie Details with OMDb" }).ClickAsync();
            await page.GetByText("IMDb rating:").ClickAsync();
            await page.GetByRole(AriaRole.Button, new() { Name = "Get another whoa" }).ClickAsync();
            await page.GetByText("Character:").ClickAsync();
            await page.GetByRole(AriaRole.Heading, new() { Name = "Movie Details with OMDb" }).ClickAsync();

        }  

     [Test]
        public static async Task WhoaSearchTestBillTedAdventure()
        {
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
            });
            var context = await browser.NewContextAsync();
            var page = await context.NewPageAsync();
            await page.GotoAsync("https://patrykszymanski31.github.io/CA3_Blazor_X00201937/");
            await page.GetByRole(AriaRole.Heading, new() { Name = "Whoa! Hey there!" }).ClickAsync();
            await page.GetByRole(AriaRole.Link, new() { Name = " Search Whoas" }).ClickAsync();
            await page.WaitForURLAsync("https://patrykszymanski31.github.io/CA3_Blazor_X00201937/whoa-search");
            await page.GetByText("Search Whoas by Movie Number of results Between 1 and 30 results. Movie Babes in").ClickAsync();
            await page.GetByLabel("Number of results").ClickAsync();
            await page.GetByLabel("Number of results").FillAsync("10");
            await page.GetByRole(AriaRole.Combobox, new() { Name = "Movie" }).SelectOptionAsync(new[] { "Bill & Ted's Excellent Adventure" });
            await page.GetByRole(AriaRole.Button, new() { Name = "Search" }).ClickAsync();
            await page.Locator("strong").First.ClickAsync();
            await page.GetByRole(AriaRole.Heading, new() { Name = "Movie details with OMDb" }).ClickAsync();
            await page.GetByText("Title: Bill & Ted's Excellent Adventure (1989)").ClickAsync();
        }
    }

}