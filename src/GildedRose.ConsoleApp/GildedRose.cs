using System.Collections.Generic;

namespace GildedRose.ConsoleApp
{
    public class GildedRose
    {
        private readonly IList<Item> _items;
        public GildedRose(IList<Item> items)
        {
            _items = items;
        }

        public void UpdateQuality()
        {
            foreach (var item in _items)
            {
                if (!item.Name.StartsWith("Aged") && !item.Name.StartsWith("Backstage passes"))
                {
                    if (item.Quality > 0)
                    {
                        if (!item.Name.StartsWith("Sulfuras") && !item.Name.StartsWith("Conjured"))
                        {
                            item.Quality -= 1;
                        }
                        else if (item.Name.StartsWith("Conjured"))
                        {
                            if (item.Quality > 1)
                                item.Quality -= 2;
                            else item.Quality -= 1;
                        }
                    }
                }
                else
                {
                    if (item.Quality < 50)
                    {
                        item.Quality += 1;

                        if (item.Name.StartsWith("Backstage passes"))
                        {
                            if (item.SellIn < 11)
                            {
                                if (item.Quality < 50)
                                {
                                    item.Quality += 1;
                                }
                            }

                            if (item.SellIn < 6)
                            {
                                if (item.Quality < 50)
                                {
                                    item.Quality += 1;
                                }
                            }
                        }
                    }
                }

                if (!item.Name.StartsWith("Sulfuras"))
                {
                    item.SellIn -= 1;
                }

                if (item.SellIn >= 0) continue;
                if (!item.Name.StartsWith("Aged"))
                {
                    if (!item.Name.StartsWith("Backstage passes"))
                    {
                        if (item.Quality <= 0) continue;
                        if (!item.Name.StartsWith("Sulfuras") && !item.Name.StartsWith("Conjured"))
                        {
                            item.Quality -= 1;
                        }
                        else if (item.Name.StartsWith("Conjured"))
                        {
                            if (item.Quality > 1)
                                item.Quality -= 2;
                            else item.Quality -= 1;
                        }
                    }
                    else
                    {
                        item.Quality -= item.Quality;
                    }
                }
                else
                {
                    if (item.Quality < 50)
                    {
                        item.Quality += 1;
                    }
                }
            }
        }
    }
}
