using GildedRose.ConsoleApp.Models;
using static GildedRose.ConsoleApp.Processors.Configuration.ItemUpdateConfiguration;

namespace GildedRose.ConsoleApp.Processors.Rules

{
    internal class RegularItemRules : AbstractRules
    {
        public override Item ApplyItemSpecificRule(Item item)
        {
            if (item.Quality > MinimalQuality)
                DecreaseQuality(item);
            if (item.SellIn <= SellInDeadline && item.Quality > MinimalQuality)
                DecreaseQuality(item);

            item.SellIn--;

            return item;
        }

        private static void DecreaseQuality(Item item)
        {
            for (int i = default; i < RegularQualityDegrease; i++)
            {
                if (item.Quality > MinimalQuality)
                    item.Quality -= RegularQualityDegrease;
            }
        }
    }
}
