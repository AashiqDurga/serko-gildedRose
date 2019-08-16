namespace GildedRose.Implementation
{
    public class SulfurasSmartItem : ISmartItem
    {
        public SulfurasSmartItem(Item sulfurasItem)
        {
            Item = sulfurasItem;
        }

        public Item Item { get; set; }
        public void Update()
        {
        }
    }
}