using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace GildedRose.ConsoleApp.Tests.UnitTests.RulesTests
{
    [ExcludeFromCodeCoverage]
    [Collection("Common rules, applies for every kind of item except legendary items")]
    public sealed class CommonRulesForNonLegendaryItems
    {
        [Theory]
        [InlineData("Aged cake", 8, 4, 10)]
        [InlineData("Regular salt", 8, 2, 10)]
        [InlineData("Conjured health potion", 1, 0, 10)]
        [InlineData("Aged socks", 1, 1, 10)]
        [InlineData("Backstage passes socks", 1, 1, 10)]
        public void GivenItemWhenIsAnyItemExceptLegendaryThenSellByDateDecreasesEverySingleEachDay(string name, int sellIn, int quality, int n)
        {
            IList<Item> itemWrappedInAList = new List<Item> { new Item { Name = name, SellIn = sellIn, Quality = quality } };
            var sellInAfterNDays = RulesTestsHelpers.UpdateParametersAfterNDays(itemWrappedInAList, n).SellIn;
            Assert.Equal(sellInAfterNDays, sellIn - n);
        }

    }
}
