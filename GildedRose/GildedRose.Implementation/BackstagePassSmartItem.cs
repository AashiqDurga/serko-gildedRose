namespace GildedRose.Implementation
{
    public class BackstagePassSmartItem : ISmartItem
    {
        public BackstagePassSmartItem(Item item)
        {
            Item = item;
        }

        public Item Item { get; set; }

        public void Update()
        {
            HandleBackstagePass();
        }
        
        private void HandleBackstagePass()
        {
            IncreaseQuality();

            if (Item.SellIn <= 10)
            {
                IncreaseQuality();
            }

            if (Item.SellIn <= 5)
            {
                IncreaseQuality();
            }

            DecreaseSellIn();
            if (Item.SellIn < 0)
            {
                Item.Quality = 0;
            }
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
    }
}