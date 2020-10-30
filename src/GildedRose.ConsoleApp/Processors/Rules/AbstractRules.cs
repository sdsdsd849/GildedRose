using System;
using GildedRose.ConsoleApp.Models;

namespace GildedRose.ConsoleApp.Processors.Rules
{
    //Can be changed to interface since there is no default functionality, designing his I though that it there will be
    public abstract class AbstractRules 
    {
        public Tuple<Item, string> ApplyRule(Item item)
        {
            var result = ApplyItemSpecificRule(item);
            return new Tuple<Item, string>(result,GetType().Name);
        }

        public abstract Item ApplyItemSpecificRule(Item item);

    }
}
