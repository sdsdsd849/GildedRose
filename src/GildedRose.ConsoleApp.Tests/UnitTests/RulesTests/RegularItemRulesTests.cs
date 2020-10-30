using System;
using System.Diagnostics.CodeAnalysis;
using GildedRose.ConsoleApp.Models;
using GildedRose.ConsoleApp.Processors.Rules;
using Xunit;
using static GildedRose.ConsoleApp.Processors.Configuration.ItemUpdateConfiguration;

namespace GildedRose.ConsoleApp.Tests.UnitTests.RulesTests
{
    [ExcludeFromCodeCoverage]
    [Collection("Regular items rules tests (*Non-negative quality covered by other tests (yes I know that if looks messy)))")]
    public sealed class RegularItemRulesTests
    {
        private readonly RegularItemRules _rules;
        public RegularItemRulesTests()
        {
            _rules = new RegularItemRules();
        }

        [Theory]
        [InlineData("Regular cake", 8, 4)]
        [InlineData("Regular salt", 8, 2)]
        [InlineData("Regular health potion", 1, 0)]
        [InlineData("Regular father belt", 1, 1)]
        public void GivenItemWhenSellByDateNotPassedThenItQualityDegradesByConstAmountEachDay(string name, int sellIn, int quality)
        {
            var qualityAfterOneDay = _rules.ApplyItemSpecificRule(new Item { Name = name, SellIn = sellIn, Quality = quality }).Quality;

            if (quality <= RegularQualityDegrease)
            {
                Assert.Equal(default, qualityAfterOneDay);
            }
            else
            {
                var qualityDifference = quality - qualityAfterOneDay;
                Assert.Equal(RegularQualityDegrease, qualityDifference);
            }
        }

        [Theory]
        [InlineData("Regular cake", 0, 4)]
        [InlineData("Regular cake", 0, 2)]
        public void GivenItemWhenSellByDatePassedThenItQualityDegradesTwiceAsFastEachDay(string name, int sellIn, int quality)
        {
            var qualityAfterOneDay = _rules.ApplyItemSpecificRule(new Item { Name = name, SellIn = sellIn, Quality = quality }).Quality;
            
            if (quality <= RegularQualityDegrease * 2)
            {
                Assert.Equal(default, qualityAfterOneDay);
            }
            else
            {
                var qualityDifference = quality - qualityAfterOneDay;
                Assert.Equal(RegularQualityDegrease * 2, qualityDifference);
            }
        }
    }
}
