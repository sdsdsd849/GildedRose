
using System;
using System.Diagnostics.CodeAnalysis;
using GildedRose.ConsoleApp.Models;
using GildedRose.ConsoleApp.Processors;
using GildedRose.ConsoleApp.Processors.Rules;
using Xunit;

namespace GildedRose.ConsoleApp.Tests.UnitTests.ProcessorTests
{
    [ExcludeFromCodeCoverage]
    [Collection("To validate if processor works as expected")]
    public sealed class RulesProcessorTests
    {
        [Theory]
        [InlineData("Aged cake", 8, 4)]
        public void GivenAgedItemThenProcessorIsAbleToRecognizeIfItsAged(string name, int sellIn, int quality)
        {
            var processor = new RulesProcessor();
            var (_,type) = processor.ProcessUpdate(new Item {Name = name, SellIn = sellIn, Quality = quality});
            Assert.Equal(nameof(AgedItemRules),type);
        }
        [Theory]
        [InlineData("Regular cake", 8, 4)]
        public void GivenRegularItemThenProcessorIsAbleToRecognizeIfItsRegular(string name, int sellIn, int quality)
        {
            var processor = new RulesProcessor();
            var (_, type) = processor.ProcessUpdate(new Item { Name = name, SellIn = sellIn, Quality = quality });
            Assert.Equal(nameof(RegularItemRules), type);
        }

        [Theory]
        [InlineData("Conjured cake", 8, 4)]
        public void GivenConjuredItemThenProcessorIsAbleToRecognizeIfItsConjured(string name, int sellIn, int quality)
        {
            var processor = new RulesProcessor();
            var (_, type) = processor.ProcessUpdate(new Item { Name = name, SellIn = sellIn, Quality = quality });
            Assert.Equal(nameof(ConjuredItemRules), type);
        }
        [Theory]
        [InlineData("Backstage passes to AC/DC concert", 8, 4)]
        public void GivenBackstagePassesItemThenProcessorIsAbleToRecognizeIfItsBackstagePasses(string name, int sellIn, int quality)
        {
            var processor = new RulesProcessor();
            var (_, type) = processor.ProcessUpdate(new Item { Name = name, SellIn = sellIn, Quality = quality });
            Assert.Equal(nameof(BackstagePasseItemRules), type);
        }
        [Theory]
        [InlineData("Sulfuras goblin", 8, 4)]
        public void GivenSulfurasItemThenProcessorIsAbleToRecognizeIfItsSulfuras(string name, int sellIn, int quality)
        {
            var processor = new RulesProcessor();
            var (_, type) = processor.ProcessUpdate(new Item { Name = name, SellIn = sellIn, Quality = quality });
            Assert.Equal(nameof(LegendaryItemRules), type);
        }
    }
}
