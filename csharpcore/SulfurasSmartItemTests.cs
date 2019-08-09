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



        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void GivenSulfurasSmartItemWithQuality80_WhenUpdatingQuality_QualityIs80(int sellIn)
        {
            var sulfuras = new Item
            {
                Name = SulfurasHandOfRagnaros,
                Quality = 80,
                SellIn = sellIn
            };
            
            var smartItem = new SulfurasSmartItem(sulfuras);

            smartItem.Update();
            Assert.Equal(80, smartItem.Item.Quality);
        }



        
    }
}