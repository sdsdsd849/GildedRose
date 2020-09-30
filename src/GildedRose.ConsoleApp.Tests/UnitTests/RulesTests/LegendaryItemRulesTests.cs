using System;
using System.Diagnostics.CodeAnalysis;
using GildedRose.ConsoleApp.Models;
using GildedRose.ConsoleApp.Processors.Rules;
using Newtonsoft.Json;
using Xunit;

namespace GildedRose.ConsoleApp.Tests.UnitTests.RulesTests
{
    [ExcludeFromCodeCoverage]
    [Collection("Legendary items rules tests")]
    public sealed class LegendaryItemRulesTests : IDisposable
    {
        private readonly LegendaryItemRules _rules;
        public LegendaryItemRulesTests()
        {
            _rules = new LegendaryItemRules();
        }

        public void Dispose()
        {
            _rules.Dispose();
        }

        [Theory]
        [InlineData("Sulfuras cake", 100, 80)]
        [InlineData("Sulfuras salt", 8, 80)]
        [InlineData("Sulfuras health potion", 1, 80)]
        [InlineData("Sulfuras father belt", -1, 80)]
        public void GivenLegendaryItemWhenAnyLegendaryItemThenNoUpdatesAreDoneInAnyWay(string name, int sellIn, int quality)
        {
            var item = new Item { Name = name, SellIn = sellIn, Quality = quality };
            var itemAfterOneDay = _rules.ApplyItemSpecificRule(item);
            Assert.Equal(JsonConvert.SerializeObject(item), JsonConvert.SerializeObject(itemAfterOneDay));
        }
    }
}
