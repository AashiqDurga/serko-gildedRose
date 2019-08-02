using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRose
    {
        private const string AgedBrie = "Aged Brie";
        private const string BackstagePasses = "Backstage passes to a TAFKAL80ETC concert";
        private const string SulfurasHandOfRagnaros = "Sulfuras, Hand of Ragnaros";
        IList<Item> Items;

        public void UpdateQuality(IList<Item> items)
        {
            Items = items;
            foreach (var item in Items)
            {
                if (item.Name != AgedBrie && item.Name != BackstagePasses)
                {
                    DecreaseQuality(item);
                }
                else
                {
                    if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;

                        if (item.Name == BackstagePasses)
                        {
                            if (item.SellIn < 11)
                            {
                                IncreaseQuality(item);
                            }

                            if (item.SellIn < 6)
                            {
                                IncreaseQuality(item);
                            }
                        }
                    }
                }

                DecreaseSellIn(item);
                HandleItemsWithSellInLessThanZero(item);
            }
        }

        private static void IncreaseQuality(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality = item.Quality + 1;
            }
        }

        private static void DecreaseQuality(Item item)
        {
            if (item.Quality > 0)
            {
                if (item.Name != SulfurasHandOfRagnaros)
                {
                    item.Quality = item.Quality - 1;
                }
            }
        }

        private static void HandleItemsWithSellInLessThanZero(Item item)
        {
            if (item.SellIn < 0)
            {
                if (item.Name != AgedBrie)
                {
                    if (item.Name != BackstagePasses)
                    {
                        if (item.Quality > 0)
                        {
                            if (item.Name != SulfurasHandOfRagnaros)
                            {
                                item.Quality = item.Quality - 1;
                            }
                        }
                    }
                    else
                    {
                        item.Quality = item.Quality - item.Quality;
                    }
                }
                else
                {
                    if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;
                    }
                }
            }
        }

        private static void DecreaseSellIn(Item item)
        {
            if (item.Name != SulfurasHandOfRagnaros)
            {
                item.SellIn = item.SellIn - 1;
            }
        }
    }
}
