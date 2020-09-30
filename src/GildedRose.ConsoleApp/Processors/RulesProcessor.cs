using System;
using GildedRose.ConsoleApp.Models;
using GildedRose.ConsoleApp.Processors.Configuration;
using GildedRose.ConsoleApp.Processors.Rules;

namespace GildedRose.ConsoleApp.Processors
{
    internal class RulesProcessor : IRulesProcessor
    {
        public Tuple<Item, string> ProcessUpdate(Item item)
        {
            var operation = GetOperation(item.Name);
            return ApplyRule(operation, item);
        }

        private static AbstractRules GetOperation(string name)
        {
            return name switch
            {
                { } x when x.StartsWith(nameof(SpecialItemTypesConfiguration.Aged)) => new AgedItemRules(),
                { } x when x.StartsWith(nameof(SpecialItemTypesConfiguration.Backstage)) => new BackstagePasseItemRules(),
                { } x when x.StartsWith(nameof(SpecialItemTypesConfiguration.Conjured)) => new ConjuredItemRules(),
                { } x when x.StartsWith(nameof(SpecialItemTypesConfiguration.Sulfuras)) => new LegendaryItemRules(),
                _ => new RegularItemRules()
            };
        }
        private static Tuple<Item, string> ApplyRule(AbstractRules rule, Item item)
        {
            return rule.ApplyRule(item);
        }
    }
}
