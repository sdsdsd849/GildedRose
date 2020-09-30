using System;
using GildedRose.ConsoleApp.Models;

namespace GildedRose.ConsoleApp.Processors.Rules
{
    public abstract class AbstractRules : IDisposable
    {
        public Tuple<Item, string> ApplyRule(Item item)
        {
            var result = ApplyItemSpecificRule(item);
            return new Tuple<Item, string>(result,GetType().Name);
        }

        public abstract Item ApplyItemSpecificRule(Item item);

        ~AbstractRules()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
        }
    }
}
