using Microsoft.Playwright;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WhoaWebApp.E2ETests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class Tests 
    {
        [Test]
        public async Task RandomWhoaFindExtraWhoaTest()
        {
            using var playwright = await Microsoft.Playwright.Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = true,
            });
            var context = await browser.NewContextAsync();
            var page = await context.NewPageAsync();
            await page.GotoAsync("https://patrykszymanski31.github.io/CA3_Blazor_X00201937/");
            await page.GetByRole(AriaRole.Heading, new() { NameString = "Whoa! Hey there!" }).ClickAsync();
            await page.GetByRole(AriaRole.Link, new() { NameString = " Random Whoa" }).ClickAsync();
            await page.WaitForURLAsync("https://patrykszymanski31.github.io/CA3_Blazor_X00201937/random-whoa");
            await page.GetByRole(AriaRole.Heading, new() { NameString = "Random Keanu \"Whoa\"" }).ClickAsync();
            await page.GetByText("Character:").ClickAsync();
            await page.GetByRole(AriaRole.Heading, new() { NameString = "Movie Details with OMDb" }).ClickAsync();
            await page.GetByText("IMDb rating:").ClickAsync();
            await page.GetByRole(AriaRole.Button, new() { NameString = "Get another whoa" }).ClickAsync();
            await page.GetByText("Character:").ClickAsync();
            await page.GetByRole(AriaRole.Heading, new() { NameString = "Movie Details with OMDb" }).ClickAsync();

        }  

     [Test]
        public static async Task WhoaSearchBillTedAdventureTest()
        {
            using var playwright = await Microsoft.Playwright.Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = true,
            });
            var context = await browser.NewContextAsync();
            var page = await context.NewPageAsync();
            await page.GotoAsync("https://patrykszymanski31.github.io/CA3_Blazor_X00201937/");
            await page.GetByRole(AriaRole.Heading, new() { NameString = "Whoa! Hey there!" }).ClickAsync();
            await page.GetByRole(AriaRole.Link, new() { NameString = " Search Whoas" }).ClickAsync();
            await page.WaitForURLAsync("https://patrykszymanski31.github.io/CA3_Blazor_X00201937/whoa-search");
            await page.GetByText("Search Whoas by Movie Number of results Between 1 and 30 results. Movie Babes in").ClickAsync();
            await page.GetByLabel("Number of results").ClickAsync();
            await page.GetByLabel("Number of results").FillAsync("10");
            await page.GetByRole(AriaRole.Combobox, new() { NameString = "Movie" }).SelectOptionAsync(new[] { "Bill & Ted's Excellent Adventure" });
            await page.GetByRole(AriaRole.Button, new() { NameString = "Search" }).ClickAsync();
            await page.Locator("strong").First.ClickAsync();
            await page.GetByRole(AriaRole.Heading, new() { NameString = "Movie details with OMDb" }).ClickAsync();
            await page.GetByText("Title: Bill & Ted's Excellent Adventure (1989)").ClickAsync();
        }
    }

}