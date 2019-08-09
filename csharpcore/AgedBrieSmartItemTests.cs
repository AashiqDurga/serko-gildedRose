using Xunit;

namespace csharpcore
{
    public class AgedBrieSmartItemTests
    {
        private const string AgedBrie = "Aged Brie";
        [Fact]
        public void GivenAgedBrieSmartItem_WhenUpdateQuality_QualityIncreasesBy1()
        {
            var agedBrieItem = new Item
            {
                Name = AgedBrie,
                Quality = 10,
                SellIn = 10

            };
            var smartItem = new AgedBrieSmartItem(agedBrieItem);

            smartItem.Update();
            
            Assert.Equal(11, smartItem.Item.Quality);
        }
    }
}