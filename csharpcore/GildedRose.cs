using System.Collections.Generic;
using csharpcore;

namespace csharpcore
{
    public class GildedRose
    {
        private readonly ISmartItemFactory _smartItemFactory;
        private const string AgedBrie = "Aged Brie";
        private const string BackstagePass = "Backstage passes to a TAFKAL80ETC concert";
        private const string SulfurasHandOfRagnaros = "Sulfuras, Hand of Ragnaros";
        IList<Item> Items;

        public GildedRose(ISmartItemFactory smartItemFactory)
        {
            _smartItemFactory = smartItemFactory;
        }

        public void UpdateQuality(IList<Item> items)
        {
            Items = items;
            foreach (var item in Items)
            {
                if (item.Name == AgedBrie)
                {
                    var smartAgedBrie = _smartItemFactory.Create(item);
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
                    var genericSmartItem = new GenericSmartItem(item);
                    genericSmartItem.Update();
                }
            }
        }
    }
}