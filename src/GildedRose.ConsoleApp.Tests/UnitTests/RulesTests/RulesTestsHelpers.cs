using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace GildedRose.ConsoleApp.Tests.UnitTests.RulesTests
{
    [ExcludeFromCodeCoverage]
    public static class RulesTestsHelpers
    {
        public static Item GetUpdatedParametersAfterOneDay(IList<Item> itemWrappedInAList)
        {
            var gildedRose = new GildedRose(itemWrappedInAList);
            gildedRose.UpdateQuality();

            var parametersAfterOneDay = itemWrappedInAList.First();
            return parametersAfterOneDay;
        }

        public static Item UpdateParametersAfterNDays(IList<Item> itemWrappedInAList, int n)
        {
            var gildedRose = new GildedRose(itemWrappedInAList);

            for (var i = 0; i < n; i++)
                gildedRose.UpdateQuality();

            var qualityAfterNDays = itemWrappedInAList.First();
            return qualityAfterNDays;
        }
    }
}
