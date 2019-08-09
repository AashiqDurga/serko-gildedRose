namespace csharpcore
{
    public class AgedBrieSmartItem : ISmartItem
    {
        public Item Item { get; set; }
        
        public AgedBrieSmartItem(Item item)
        {
            Item = item;
        }

        private void IncreaseQuality()
        {
            if (Item.Quality < 50)
            {
                Item.Quality++;
            }
        }
        
        private void DecreaseSellIn()
        {
            Item.SellIn--;
        }
        
        public void Update()
        {
            IncreaseQuality();
            DecreaseSellIn();
            if (Item.SellIn < 0)
            {
                IncreaseQuality();
            }
        }
    }
}