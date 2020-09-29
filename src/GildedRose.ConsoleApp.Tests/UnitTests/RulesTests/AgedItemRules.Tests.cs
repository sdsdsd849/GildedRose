using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace GildedRose.ConsoleApp.Tests.UnitTests.RulesTests
{
    [ExcludeFromCodeCoverage]
    [Collection("Aged item rules tests (*Non-negative quality covered by other tests)")]
    public sealed class AgedItemRules
    {
        [Theory]
        [InlineData("Aged cake", 8, 4)]
        [InlineData("Aged salt", 8, 2)]
        [InlineData("Aged health potion", 1, 0)]
        [InlineData("Aged socks", 1, 1)]
        public void GivenAgedItemWhenSellByDateNotPassedThenQualityIncreasesByConstAmountEachDay(string name, int sellIn, int quality)
        {
            IList<Item> itemWrappedInAList = new List<Item> { new Item { Name = name, SellIn = sellIn, Quality = quality } };
            var qualityAfterOneDay = RulesTestsHelpers.GetUpdatedParametersAfterOneDay(itemWrappedInAList).Quality;

            if (quality <= -1)
            {
                Assert.Equal(0, qualityAfterOneDay);
            }
            else
            {
                var qualityDifference = quality - qualityAfterOneDay;
                Assert.Equal(-1, qualityDifference);
            }
        }

        [Theory]
        [InlineData("Aged cake", 0, 4)]
        [InlineData("Aged salt", 0, 2)]
        [InlineData("Aged health potion", 0, 0)]
        [InlineData("Aged socks", 0, 1)]
        public void GivenAgedItemWhenSellByDatePassedThenQualityIncreasesTwiceAsFastEachDay(string name, int sellIn, int quality)
        {
            IList<Item> itemWrappedInAList = new List<Item> { new Item { Name = name, SellIn = sellIn, Quality = quality } };
            var qualityAfterOneDay = RulesTestsHelpers.GetUpdatedParametersAfterOneDay(itemWrappedInAList).Quality;

            if (quality <= -2)
            {
                Assert.Equal(0, qualityAfterOneDay);
            }
            else
            {
                var qualityDifference = quality - qualityAfterOneDay;
                Assert.Equal(-2, qualityDifference);
            }
        }

        [Fact]
        public void GivenAgedItemWhenQualityIsFiftyThenQualityNeverGetsBigger()
        {
            IList<Item> itemWrappedInAList = new List<Item> { new Item { Name = "Aged Brie", SellIn = 50, Quality = 50 } };
            var qualityAfterOneDay = RulesTestsHelpers.GetUpdatedParametersAfterOneDay(itemWrappedInAList).Quality;
            Assert.True(qualityAfterOneDay==50);
        }
    }
}
