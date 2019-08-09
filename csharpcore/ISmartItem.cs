namespace csharpcore
{
    public interface ISmartItem
    {
        Item Item { get; set; }
        void Update();
    }
}