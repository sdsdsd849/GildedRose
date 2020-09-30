using GildedRose.ConsoleApp.Models;
using static GildedRose.ConsoleApp.Processors.Configuration.ItemUpdateConfiguration;

namespace GildedRose.ConsoleApp.Processors.Rules

{
    internal class ConjuredItemRules : AbstractRules
    {
        public override Item ApplyItemSpecificRule(Item item)
        {
            const int conjuredItemQualityDecrease = ConjuredQualityChangeMultiplicationFactor * RegularQualityDegrease;
            DecreaseQuality(item, conjuredItemQualityDecrease);
            if (item.SellIn <= SellInDeadline)
                DecreaseQuality(item, conjuredItemQualityDecrease);

            item.SellIn--;

            return item;
        }

        private static void DecreaseQuality(Item item, int conjuredItemQualityDecrease)
        { 
            for (int i = default; i < conjuredItemQualityDecrease; i++)
            {
                if (item.Quality > MinimalQuality)
                    item.Quality -= RegularQualityDegrease;
            }
        }
    }
}
