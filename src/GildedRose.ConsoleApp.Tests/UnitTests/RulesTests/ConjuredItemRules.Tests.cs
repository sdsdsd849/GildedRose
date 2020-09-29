using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace GildedRose.ConsoleApp.Tests.UnitTests.RulesTests
{
    [ExcludeFromCodeCoverage]
    [Collection("Conjured items rules tests (*Non-negative quality covered by other tests)")]
    public sealed class ConjuredItemRules
    {
        [Theory]
        [InlineData("Conjured cake", 8, 4)]
        [InlineData("Conjured salt", 8, 2)]
        public void GivenConjuredItemWhenSellByDateNotPassedThenItDegradesTwiceAsFastRegularItem(string name, int sellIn, int quality)
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

        [Theory]
        [InlineData("Conjured cake", 0, 4)]
        [InlineData("Conjured cake", 0, 2)]
        public void GivenConjuredItemWhenSellByDatePassedThenItDegradesTwiceAsFastRegularItem(string name, int sellIn, int quality)
        {
            IList<Item> itemWrappedInAList = new List<Item> { new Item { Name = name, SellIn = sellIn, Quality = quality } };
            var qualityAfterOneDay = RulesTestsHelpers.GetUpdatedParametersAfterOneDay(itemWrappedInAList).Quality;

            if (quality <= 4)
            {
                Assert.Equal(0, qualityAfterOneDay);
            }
            else
            {
                var qualityDifference = quality - qualityAfterOneDay;
                Assert.Equal(4, qualityDifference);
            }
        }

        [Theory]
        [InlineData("Conjured cake", 5, 0)]
        [InlineData("Conjured cake", 0, 0)]
        public void GivenConjuredItemWhenQualityIsZeroThenQualityNeverGetsLower(string name, int sellIn, int quality)
        {
            IList<Item> itemWrappedInAList = new List<Item> { new Item { Name = name, SellIn = sellIn, Quality = quality } };
            var qualityAfterOneDay = RulesTestsHelpers.GetUpdatedParametersAfterOneDay(itemWrappedInAList).Quality;
            Assert.Equal(0, qualityAfterOneDay);
        }
    }
}
