using GildedRose.ConsoleApp.Models;
using static GildedRose.ConsoleApp.Processors.Configuration.ItemUpdateConfiguration;

namespace GildedRose.ConsoleApp.Processors.Rules
{
    internal class AgedItemRules : AbstractRules
    {
        public override Item ApplyItemSpecificRule(Item item)
        {
            if (item.Quality < MaxQuality)
                IncreaseQuality(item);
            if (item.Quality < MaxQuality && item.SellIn <= SellInDeadline)
                IncreaseQuality(item);

            item.SellIn--;

            return item;
        }

        private static void IncreaseQuality(Item item)
        {
            for (int i = default; i < RegularQualityDegrease; i++)
            {
                if (item.Quality < MaxQuality)
                    item.Quality += RegularQualityIncrease;
            }
        }
    }
}
