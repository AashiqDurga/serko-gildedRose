namespace csharpcore
{
    public class SmartItemFactory
    {
        private const string AgedBrie = "Aged Brie";
        private const string BackstagePass = "Backstage passes to a TAFKAL80ETC concert";
        private const string SulfurasHandOfRagnaros = "Sulfuras, Hand of Ragnaros";

        public ISmartItem Create(Item item)
        {
            if (item.Name == AgedBrie)
                return new AgedBrieSmartItem(item);
            
            if (item.Name == BackstagePass)
                return new BackstagePassSmartItem(item);
            
            if (item.Name == SulfurasHandOfRagnaros)
                return new SulfurasSmartItem(item);

            return new GenericSmartItem(item);
        }
    }
}