using System;
using GildedRose.ConsoleApp.Models;

namespace GildedRose.ConsoleApp.Processors
{
    internal interface IRulesProcessor
    {
        Tuple<Item, string> ProcessUpdate(Item item);
    }
}