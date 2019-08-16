namespace csharpcore
{
    public class SmartItemFactory
    {
        private const string AgedBrie = "Aged Brie";

        public ISmartItem Create(Item item)
        {
            if (item.Name == AgedBrie)
                return new AgedBrieSmartItem(item);

            return null;
        }
    }
}