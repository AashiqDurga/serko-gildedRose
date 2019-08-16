using Xunit;

namespace GildedRose.Implementation.GildedRose.Tests
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
        
        [Fact]
        public void GivenAgedBrieWithSellInZero_WhenUpdatingQuality_ThenQualityIncreasesBy2()
        {
            var agedBrieItem = new Item
            {
                Name = AgedBrie,
                Quality = 1,
                SellIn = 0
            };
            
            var smartItem = new AgedBrieSmartItem(agedBrieItem);
            
            smartItem.Update();
            
            Assert.Equal(3, smartItem.Item.Quality);
        }
        
        [Fact]
        public void GivenAgedBrieWithQuality50_WhenUpdatingQuality_ThenQualityRemains50()
        {
            var agedBrieItem = new Item
            {
                Name = AgedBrie,
                Quality = 50,
                SellIn = 0
            };
            
            var smartItem = new AgedBrieSmartItem(agedBrieItem);
            
            smartItem.Update();
            
            Assert.Equal(50, smartItem.Item.Quality);
        }
    }
}