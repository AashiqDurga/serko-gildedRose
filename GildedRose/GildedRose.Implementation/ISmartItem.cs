namespace GildedRose.Implementation
{
    public interface ISmartItem
    {
        Item Item { get; set; }
        void Update();
    }
}