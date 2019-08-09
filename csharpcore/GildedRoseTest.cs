using Xunit;
using System.Collections.Generic;

namespace csharpcore
{
    public class GildedRoseTest
    {
        private readonly GildedRose _gildedRose;

        public GildedRoseTest()
        {
            _gildedRose = new GildedRose();
        }
        
        [Fact]
        public void foo()
        {
            var Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            _gildedRose.UpdateQuality(Items);
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

            var items = new List<Item> { item };
            _gildedRose.UpdateQuality(items);
            Assert.Equal(0, item.Quality);
        }

        [Fact]
        public void GivenGenericItem_WhenUpdateQuality_QualityDecreasesBy1()
        {
            var item = new Item
            {
                Name = "Generic",
                Quality = 45,
                SellIn = 1
            };
            
            var items = new List<Item> { item };
            _gildedRose.UpdateQuality(items);
            Assert.Equal(44, item.Quality);
        }
        
        [Fact]
        public void GivenGenericItem_WhenUpdateQuality_SellInDecreasesBy1()
        {
            var item = new Item
            {
                Name = "Generic",
                Quality = 45,
                SellIn = 1
            };
            
            var items = new List<Item> { item };
            _gildedRose.UpdateQuality(items);
            Assert.Equal(0, item.SellIn);
        }
        
        [Fact]
        public void GivenGenericItemWithQuality0_WhenUpdateQuality_QualityRemainsZero()
        {
            var item = new Item
            {
                Name = "Generic",
                Quality = 0,
                SellIn = 1
            };
            
            var items = new List<Item> { item };
            _gildedRose.UpdateQuality(items);
            Assert.Equal(0, item.Quality);
        }
        
        [Fact]
        public void GivenGenericItemWithSellInLessThan1_WhenUpdateQuality_QualityDecrementsBy2()
        {
            var item = new Item
            {
                Name = "Generic",
                Quality = 10,
                SellIn = 0
            };
            
            var items = new List<Item> { item };
            _gildedRose.UpdateQuality(items);
            Assert.Equal(8, item.Quality);
        }
    }
}