using System;
using System.Diagnostics.CodeAnalysis;
using GildedRose.ConsoleApp.Models;
using GildedRose.ConsoleApp.Processors.Rules;
using Xunit;
using static GildedRose.ConsoleApp.Processors.Configuration.ItemUpdateConfiguration;

namespace GildedRose.ConsoleApp.Tests.UnitTests.RulesTests
{
    [ExcludeFromCodeCoverage]
    [Collection("Conjured items rules tests (*Non-negative quality covered by other tests)")]
    public sealed class ConjuredItemRulesTests : IDisposable
    {
        private readonly ConjuredItemRules _rules;
        public ConjuredItemRulesTests()
        {
            _rules = new ConjuredItemRules();
        }

        public void Dispose()
        {
            _rules.Dispose();
        }

        [Theory]
        [InlineData("Conjured cake", 8, 4)]
        [InlineData("Conjured salt", 8, 2)]
        public void GivenConjuredItemWhenSellByDateNotPassedThenItDegradesTwiceAsFastRegularItem(string name, int sellIn, int quality)
        {
            var qualityAfterOneDay = _rules.ApplyItemSpecificRule(new Item { Name = name, SellIn = sellIn, Quality = quality }).Quality;

            if (quality <= RegularQualityDegrease * ConjuredQualityChangeMultiplicationFactor)
            {
                Assert.Equal(default, qualityAfterOneDay);
            }
            else
            {
                var qualityDifference = quality - qualityAfterOneDay;
                Assert.Equal(RegularQualityDegrease * ConjuredQualityChangeMultiplicationFactor, qualityDifference);
            }
        }

        [Theory]
        [InlineData("Conjured cake", 0, 4)]
        [InlineData("Conjured cake", 0, 2)]
        public void GivenConjuredItemWhenSellByDatePassedThenItDegradesTwiceAsFastRegularItem(string name, int sellIn, int quality)
        {
            var qualityAfterOneDay = _rules.ApplyItemSpecificRule(new Item { Name = name, SellIn = sellIn, Quality = quality }).Quality;

            if (quality <= RegularQualityDegrease * ConjuredQualityChangeMultiplicationFactor * 2)
            {
                Assert.Equal(default, qualityAfterOneDay);
            }
            else
            {
                var qualityDifference = quality - qualityAfterOneDay;
                Assert.Equal(RegularQualityDegrease * ConjuredQualityChangeMultiplicationFactor * 2, qualityDifference);
            }
        }

        [Theory]
        [InlineData("Conjured cake", 5, 0)]
        [InlineData("Conjured cake", 0, 0)]
        public void GivenConjuredItemWhenQualityIsZeroThenQualityNeverGetsLower(string name, int sellIn, int quality)
        {
            var qualityAfterOneDay = _rules.ApplyItemSpecificRule(new Item { Name = name, SellIn = sellIn, Quality = quality }).Quality;
            Assert.Equal(default, qualityAfterOneDay);
        }
    }
}
