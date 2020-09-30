using System.Collections.Generic;
using GildedRose.ConsoleApp.Models;

namespace GildedRose.ConsoleApp.Shop
{
    public interface IShop
    {
        void UpdateQuality(IList<Item> items);
    }
}