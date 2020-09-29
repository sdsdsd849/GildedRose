using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace GildedRose.ConsoleApp.Tests.UnitTests.RulesTests
{
    [ExcludeFromCodeCoverage]
    [Collection("Regular items rules tests (*Non-negative quality covered by other tests)")]
    public sealed class RegularItemRules
    {
        [Theory]
        [InlineData("Regular cake", 8, 4)]
        [InlineData("Regular salt", 8, 2)]
        [InlineData("Regular health potion", 1, 0)]
        [InlineData("Regular father belt", 1, 1)]
        public void GivenItemWhenSellByDateNotPassedThenItQualityDegradesByConstAmountEachDay(string name, int sellIn, int quality)
        {
            IList<Item> itemWrappedInAList = new List<Item> { new Item { Name = name, SellIn = sellIn, Quality = quality } };
            var qualityAfterOneDay = RulesTestsHelpers.GetUpdatedParametersAfterOneDay(itemWrappedInAList).Quality;

            if (quality <= 1)
            {
                Assert.Equal(0, qualityAfterOneDay);
            }
            else
            {
                var qualityDifference = quality - qualityAfterOneDay;
                Assert.Equal(1, qualityDifference);
            }
        }

        [Theory]
        [InlineData("Regular cake", 0, 4)]
        [InlineData("Regular cake", 0, 2)]
        public void GivenItemWhenSellByDatePassedThenItQualityDegradesTwiceAsFastEachDay(string name, int sellIn, int quality)
        {
            IList<Item> itemWrappedInAList = new List<Item> { new Item { Name = name, SellIn = sellIn, Quality = quality } };
            var qualityAfterOneDay = RulesTestsHelpers.GetUpdatedParametersAfterOneDay(itemWrappedInAList).Quality;

            if (quality <= 2)
            {
                Assert.Equal(0, qualityAfterOneDay);
            }
            else
            {
                var qualityDifference = quality - qualityAfterOneDay;
                Assert.Equal(2, qualityDifference);
            }
        }
    }
}
