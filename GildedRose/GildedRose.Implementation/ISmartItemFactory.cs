namespace GildedRose.Implementation
{
    public interface ISmartItemFactory
    {
        ISmartItem Create(Item item);
    }
}