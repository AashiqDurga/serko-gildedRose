using Xunit;
using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRoseTest
    {
        [Fact]
        public void foo()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal("foo", Items[0].Name);
        }

        [Fact]
        public void GivenItemWithQualityZero_WhenUpdatingQuality_ThenQualityRemainsZero()
        {
            var item = new Item
            {
                Name = "zeroQualityItem",
                Quality = 0
            };
            
            var glidedRose = new GildedRose(new List<Item> { item });
            glidedRose.UpdateQuality();
            Assert.Equal(0, item.Quality);
        }
        
        [Fact]
        public void GivenAgedBrie_WhenUpdatingQuality_ThenQualityIncreasesBy1()
        {
            var item = new Item
            {
                Name = "Aged Brie",
                Quality = 1,
                SellIn = 55
            };
            
            var glidedRose = new GildedRose(new List<Item> { item });
            glidedRose.UpdateQuality();
            Assert.Equal(2, item.Quality);
        }
        
        [Fact]
        public void GivenAgedBrieWithSellInZero_WhenUpdatingQuality_ThenQualityIncreasesBy2()
        {
            var item = new Item
            {
                Name = "Aged Brie",
                Quality = 1,
                SellIn = 0
            };
            
            var glidedRose = new GildedRose(new List<Item> { item });
            glidedRose.UpdateQuality();
            Assert.Equal(3, item.Quality);
        }
    }
}