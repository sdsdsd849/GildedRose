using System.Collections.Generic;
using GildedRose.ConsoleApp.Models;
using GildedRose.ConsoleApp.Processors;

namespace GildedRose.ConsoleApp.Shop
{
    internal class GildedRoseRefactored : IShop
    {
        private readonly IRulesProcessor _rulesProcessor;

        public GildedRoseRefactored(IRulesProcessor rulesProcessor)
        {
            _rulesProcessor = rulesProcessor;
        }
        public void UpdateQuality(IList<Item> items)
        {
            foreach (var item in items)
            {
                _rulesProcessor.ProcessUpdate(item);
            }
        }
    }
}
