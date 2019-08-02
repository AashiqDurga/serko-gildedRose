using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRose
    {
        private const string AgedBrie = "Aged Brie";
        private const string BackstagePass = "Backstage passes to a TAFKAL80ETC concert";
        private const string SulfurasHandOfRagnaros = "Sulfuras, Hand of Ragnaros";
        IList<Item> Items;

        public void UpdateQuality(IList<Item> items)
        {
            Items = items;
            foreach (var item in Items)
            {
                if (item.Name == AgedBrie)
                {
                    HandleAgedBrie(item);
                }
                else if (item.Name == BackstagePass)
                {
                    HandleBackstagePass(item);
                }
                else if (item.Name != SulfurasHandOfRagnaros)
                {
                    DecreaseQuality(item);
                    DecreaseSellIn(item);
                    HandleItemsWithSellInLessThanZero(item);   
                }
            }
        }
        
        private static void HandleBackstagePass(Item item)
        {
            IncreaseQuality(item);

            if (item.SellIn < 11)
            {
                IncreaseQuality(item);
            }

            if (item.SellIn < 6)
            {
                IncreaseQuality(item);
            }

            DecreaseSellIn(item);
            if (item.SellIn < 0)
            {
                item.Quality = item.Quality - item.Quality;
            }
        }

        private static void HandleAgedBrie(Item item)
        {
            IncreaseQuality(item);
            DecreaseSellIn(item);
            if (item.SellIn < 0)
            {
                IncreaseQuality(item);
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
                item.Quality = item.Quality - 1;
            }
        }

        private static void HandleItemsWithSellInLessThanZero(Item item)
        {
            if (item.SellIn < 0)
            {
               DecreaseQuality(item);
            }
        }

        private static void DecreaseSellIn(Item item)
        {
            item.SellIn = item.SellIn - 1;
        }
    }
}