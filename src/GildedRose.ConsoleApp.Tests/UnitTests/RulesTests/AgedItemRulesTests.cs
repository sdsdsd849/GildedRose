using System;
using System.Diagnostics.CodeAnalysis;
using GildedRose.ConsoleApp.Models;
using GildedRose.ConsoleApp.Processors.Rules;
using Xunit;
using static GildedRose.ConsoleApp.Processors.Configuration.ItemUpdateConfiguration;

namespace GildedRose.ConsoleApp.Tests.UnitTests.RulesTests
{
    [ExcludeFromCodeCoverage]
    [Collection("Aged item rules tests (*Non-negative quality covered by other tests)")]
    public sealed class AgedItemRulesTests : IDisposable
    {
        private readonly AgedItemRules _rules;
        public AgedItemRulesTests()
        {
            _rules = new AgedItemRules();
        }

        public void Dispose()
        {
            _rules.Dispose();
        }


        [Theory]
        [InlineData("Aged cake", 8, 4)]
        [InlineData("Aged salt", 8, 2)]
        [InlineData("Aged health potion", 1, 0)]
        [InlineData("Aged socks", 1, 1)]
        public void GivenAgedItemWhenSellByDateNotPassedThenQualityIncreasesByConstAmountEachDay(string name, int sellIn, int quality)
        {
            var qualityAfterOneDay = _rules.ApplyItemSpecificRule(new Item {Name = name, SellIn = sellIn, Quality = quality}).Quality;

            if (quality <= -RegularQualityIncrease)
            {
                Assert.Equal(default, qualityAfterOneDay);
            }
            else
            {
                var qualityDifference = quality - qualityAfterOneDay;
                Assert.Equal(-RegularQualityIncrease, qualityDifference);
            }
        }

        [Theory]
        [InlineData("Aged cake", 0, 4)]
        [InlineData("Aged salt", 0, 2)]
        [InlineData("Aged health potion", 0, 0)]
        [InlineData("Aged socks", 0, 1)]
        public void GivenAgedItemWhenSellByDatePassedThenQualityIncreasesTwiceAsFastEachDay(string name, int sellIn, int quality)
        {
            var qualityAfterOneDay = _rules.ApplyItemSpecificRule(new Item { Name = name, SellIn = sellIn, Quality = quality }).Quality;

            if (quality <= -RegularQualityIncrease * 2)
            {
                Assert.Equal(default, qualityAfterOneDay);
            }
            else
            {
                var qualityDifference = quality - qualityAfterOneDay;
                Assert.Equal(-RegularQualityIncrease * 2, qualityDifference);
            }
        }

        [Fact]
        public void GivenAgedItemWhenQualityIsFiftyThenQualityNeverGetsBigger()
        {
            var qualityAfterOneDay = _rules.ApplyItemSpecificRule(new Item { Name = "Aged Brie", SellIn = 50, Quality = 50 }).Quality;
            Assert.True(qualityAfterOneDay==50);
        }

        [Theory]
        [InlineData("Aged cake", 8, 4)]
        public void GivenAgedItemThenSellByDateDecreasesWhenDayPasses(string name, int sellIn, int quality)
        {
            var expected = sellIn - 1;
            var sellInAfterNDays = _rules.ApplyItemSpecificRule(new Item { Name = name, SellIn = sellIn, Quality = quality }).SellIn;
            Assert.Equal(expected, sellInAfterNDays);
        }
    }
}
