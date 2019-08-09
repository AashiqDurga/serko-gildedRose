using System.Collections.Generic;
using csharpcore;

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
                    var smartAgedBrie = new AgedBrieSmartItem(item);
                    smartAgedBrie.Update();
                }
                else if (item.Name == SulfurasHandOfRagnaros)
                {
                    var sulfurasSmartItem = new SulfurasSmartItem(item);
                    sulfurasSmartItem.Update();
                }
                else if (item.Name == BackstagePass)
                {
                    var backstagePassSmartItem = new BackstagePassSmartItem(item);
                    backstagePassSmartItem.Update();
                }
                else
                {
                    DecreaseQuality(item);
                    DecreaseSellIn(item);
                    HandleItemsWithSellInLessThanZero(item);   
                }
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