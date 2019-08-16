using Xunit;

namespace csharpcore
{
    public class SmartItemFactoryTests
    {
        [Fact]
        public void GivenItemWithNameAgedBrie_ReturnsAgedBrieSmartItem()
        {
            var item = new Item
            {
                Name = "Aged Brie"
            };
            
            var smartItemFactory = new SmartItemFactory();
            var smartItem = smartItemFactory.Create(item);
            Assert.IsType(typeof(AgedBrieSmartItem), smartItem);
        }
    }
}