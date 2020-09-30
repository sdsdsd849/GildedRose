using System;
using System.Collections.Generic;
using GildedRose.ConsoleApp.Models;
using GildedRose.ConsoleApp.Processors;
using GildedRose.ConsoleApp.Shop;
using Microsoft.Extensions.DependencyInjection;

namespace GildedRose.ConsoleApp
{
    public static class Program
    {
        public static void Main()
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IRulesProcessor, RulesProcessor>()
                .AddSingleton<IShop, GildedRoseRefactored>()
                .BuildServiceProvider();
            var app = serviceProvider.GetService<IShop>();

            Console.WriteLine("OMGHAI!");

            IList<Item> items = new List<Item>{
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 49
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 49
                },
                new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };


            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                foreach (var t in items)
                {
                    Console.WriteLine(t.Name + ", " + t.SellIn + ", " + t.Quality);
                }
                Console.WriteLine("");
                app.UpdateQuality(items);
            }
        }
    }
}
