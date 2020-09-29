using System.Collections.Generic;
using Xunit;

namespace GildedRose.ConsoleApp.Tests.UnitTests.RulesTests
{
    [Collection("Backstage passe item rules tests (*Non-negative quality covered by other tests)")]
    public sealed class BackstagePasseItemRules
    {
        [Fact]
        public void GivenBackstagePassesWhenSellByValueIsGreaterThanTenThenIncreasesInQualityByConstantAmount()
        {
            const int initialQuality = 42;
            IList<Item> itemWrappedInAList = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 47, Quality = initialQuality } };
            var qualityAfterOneDay = RulesTestsHelpers.GetUpdatedParametersAfterOneDay(itemWrappedInAList).Quality;

            Assert.True(qualityAfterOneDay == initialQuality + 1);
        }

        [Fact]
        public void GivenBackstagePassesWhenSellByValueIsLessThanTenAndBiggerThanFiveThenIncreasesInQualityTwiceAsFast()
        {
            const int initialQuality = 30;
            IList<Item> itemWrappedInAList = new List<Item> { new Item { Name = "Backstage passes to a AC/DC concert", SellIn = 9, Quality = initialQuality } };
            var qualityAfterOneDay = RulesTestsHelpers.GetUpdatedParametersAfterOneDay(itemWrappedInAList).Quality;

            Assert.True(qualityAfterOneDay == initialQuality + 2);
        }

        [Fact]
        public void GivenBackstagePassesWhenSellByValueIsLessThanFiveAndBiggerThanZeroThenIncreasesInQualityTwiceAsFast()
        {
            const int initialQuality = 30;
            IList<Item> itemWrappedInAList = new List<Item> { new Item { Name = "Backstage passes to a McLoud concert", SellIn = 2, Quality = initialQuality } };
            var qualityAfterOneDay = RulesTestsHelpers.GetUpdatedParametersAfterOneDay(itemWrappedInAList).Quality;

            Assert.True(qualityAfterOneDay == initialQuality + 3);
        }

        [Fact]
        public void GivenBackstagePassesWhenAfterTheConcertThanImmediatelyQualityDropsToZero()
        {
            IList<Item> itemWrappedInAList = new List<Item> { new Item { Name = "Backstage passes to a Metallica concert", SellIn = 0, Quality = 30 } };
            var qualityAfterOneDay = RulesTestsHelpers.GetUpdatedParametersAfterOneDay(itemWrappedInAList).Quality;

            Assert.True(qualityAfterOneDay ==  0);
        }


    }
}
