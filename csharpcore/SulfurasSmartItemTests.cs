using Xunit;

namespace csharpcore
{
    public class SulfurasSmartItemTests
    {
        private const string SulfurasHandOfRagnaros = "Sulfuras, Hand of Ragnaros";
        [Fact]
        public void GivenSulfurasSmartItem_WhenUpdateQuality_QualityRemainsSame()
        {
            var sulfurasItem = new Item
            {
                Name = SulfurasHandOfRagnaros,
                Quality = 10,
                SellIn = 10

            };
            var smartItem = new SulfurasSmartItem(sulfurasItem);

            smartItem.Update();
            
            Assert.Equal(10, smartItem.Item.Quality);
        }
    }
}