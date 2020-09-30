using GildedRose.ConsoleApp.Models;

namespace GildedRose.ConsoleApp.Processors.Rules
{
    internal class LegendaryItemRules : AbstractRules
    {
        public override Item ApplyItemSpecificRule(Item item)
        {
            return item;
        }
    }
}
