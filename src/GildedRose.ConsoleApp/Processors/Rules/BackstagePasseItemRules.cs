using GildedRose.ConsoleApp.Models;
using static GildedRose.ConsoleApp.Processors.Configuration.ItemUpdateConfiguration;

namespace GildedRose.ConsoleApp.Processors.Rules
{
    internal class BackstagePasseItemRules : AbstractRules
    {
        public override Item ApplyItemSpecificRule(Item item)
        {
            if (item.SellIn <= 0)
                item.Quality = default;
            else if (item.Quality < MaxQuality && item.SellIn > BackstagePassesFirstPeriodDaysLeft)
                IncreaseQuality(item, RegularQualityIncrease);
            else if (item.Quality < MaxQuality && item.SellIn <= BackstagePassesFirstPeriodDaysLeft && item.SellIn > BackstagePassesSecondPeriodDaysLeft)
                IncreaseQuality(item, BackstagePassesQualityIncreaseWhenFirstPeriodStarts);
            else if (item.Quality < MaxQuality && item.SellIn <= BackstagePassesSecondPeriodDaysLeft)
                IncreaseQuality(item, BackstagePassesQualityIncreaseWhenSecondPeriodStarts);

            item.SellIn--;

            return item;
        }

        private static void IncreaseQuality(Item item, int increaseAmount)
        {
            for (int i = default; i < increaseAmount; i++)
            {
                if (item.Quality < MaxQuality)
                    item.Quality += RegularQualityIncrease;
            }
        }
    }
}
