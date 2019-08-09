namespace csharpcore
{
    public class AgedBrieSmartItem : ISmartItem
    {
        public Item Item { get; set; }
        
        public AgedBrieSmartItem(Item item)
        {
            Item = item;
        }

        public void Update()
        {
            Item.Quality++;
        }
    }
}