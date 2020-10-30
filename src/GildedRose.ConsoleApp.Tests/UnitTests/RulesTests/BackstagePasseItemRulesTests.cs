using System;
using GildedRose.ConsoleApp.Models;
using GildedRose.ConsoleApp.Processors.Rules;
using Xunit;
using static GildedRose.ConsoleApp.Processors.Configuration.ItemUpdateConfiguration;

namespace GildedRose.ConsoleApp.Tests.UnitTests.RulesTests
{
    [Collection("Backstage passe item rules tests (*Non-negative quality covered by other tests (yes I know that if looks messy)))")]
    public sealed class BackstagePasseItemRulesTests
    {
        private readonly BackstagePasseItemRules _rules;
        public BackstagePasseItemRulesTests()
        {
            _rules = new BackstagePasseItemRules();
        }

        [Fact]
        public void GivenBackstagePassesWhenSellByValueIsGreaterThanTenThenIncreasesInQualityByConstantAmount()
        {
            const int initialQuality = 42;
            var qualityAfterOneDay = _rules.ApplyItemSpecificRule(new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 47, Quality = initialQuality }).Quality;

            Assert.True(qualityAfterOneDay == initialQuality + RegularQualityIncrease);
        }

        [Fact]
        public void GivenBackstagePassesWhenFirstPeriodStartsThenIncreasesInQualityTwiceAsFast()
        {
            const int initialQuality = 30;
            var qualityAfterOneDay = _rules.ApplyItemSpecificRule(new Item { Name = "Backstage passes to a AC/DC concert", SellIn = 9, Quality = initialQuality }).Quality;
            Assert.True(qualityAfterOneDay == initialQuality + BackstagePassesQualityIncreaseWhenFirstPeriodStarts);
        }

        [Fact]
        public void GivenBackstagePassesWhenSecondPeriodStartsThenIncreasesInQualityTwiceAsFast()
        {
            const int initialQuality = 30;
            var qualityAfterOneDay = _rules.ApplyItemSpecificRule(new Item { Name = "Backstage passes to a McLoud concert", SellIn = 2, Quality = initialQuality }).Quality;

            Assert.True(qualityAfterOneDay == initialQuality + BackstagePassesQualityIncreaseWhenSecondPeriodStarts);
        }

        [Fact]
        public void GivenBackstagePassesWhenAfterTheConcertThanImmediatelyQualityDropsToZero()
        {
            var qualityAfterOneDay = _rules.ApplyItemSpecificRule(new Item { Name = "Backstage passes to a Metallica concert", SellIn = 0, Quality = 30 }).Quality;

            Assert.True(qualityAfterOneDay == default);
        }

        [Theory]
        [InlineData("Backstage passes", 8, 4)]
        public void GivenBackstagePassesItemThenSellByDateDecreasesWhenDayPasses(string name, int sellIn, int quality)
        {
            var expected = sellIn - 1;
            var sellInAfterNDays = _rules.ApplyItemSpecificRule(new Item { Name = name, SellIn = sellIn, Quality = quality }).SellIn;
            Assert.Equal(expected, sellInAfterNDays);
        }
    }
}
