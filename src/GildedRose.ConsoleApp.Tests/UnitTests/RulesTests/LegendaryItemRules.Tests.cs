using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;
using Xunit;

namespace GildedRose.ConsoleApp.Tests.UnitTests.RulesTests
{
    [ExcludeFromCodeCoverage]
    [Collection("Legendary items rules tests")]
    public sealed class LegendaryItemRules
    {
        [Theory]
        [InlineData("Sulfuras cake", 100, 80)]
        [InlineData("Sulfuras salt", 8, 80)]
        [InlineData("Sulfuras health potion", 1, 80)]
        [InlineData("Sulfuras father belt", -1, 80)]
        public void GivenLegendaryItemWhenAnyLegendaryItemThenNoUpdatesAreDoneInAnyWay(string name, int sellIn, int quality)
        {
            var item = new Item { Name = name, SellIn = sellIn, Quality = quality };
            IList<Item> itemWrappedInAList = new List<Item> { item };
            var itemAfterOneDay = RulesTestsHelpers.GetUpdatedParametersAfterOneDay(itemWrappedInAList);
            Assert.Equal(JsonConvert.SerializeObject(item), JsonConvert.SerializeObject(itemAfterOneDay));
        }
    }
}
