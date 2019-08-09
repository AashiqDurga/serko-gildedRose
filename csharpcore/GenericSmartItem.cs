namespace csharpcore
{
    public class GenericSmartItem : ISmartItem
    {
        public GenericSmartItem(Item item)
        {
            Item = item;
        }

        public Item Item { get; set; }
        public void Update()
        {
            DecreaseQuality();
            DecreaseSellIn();
            HandleItemsWithSellInLessThanZero();  
        }
        
        private void DecreaseQuality()
        {
            if (Item.Quality > 0)
            {
                Item.Quality--;
            }
        }

        private void HandleItemsWithSellInLessThanZero()
        {
            if (Item.SellIn < 0)
            {
                DecreaseQuality();
            }
        }

        private void DecreaseSellIn()
        {
            Item.SellIn--;
        }
    }
}