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

        private const string AgedBrie = "Aged Brie";
        private const string BackstagePasses = "Backstage passes to a TAFKAL80ETC concert";
        private const string SulfurasHandOfRagnaros = "Sulfuras, Hand of Ragnaros";
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
        public void GivenAgedBrie_WhenUpdatingQuality_ThenQualityIncreasesBy1()
        {
            var item = new Item
            {
                Name = "Aged Brie",
                Quality = 1,
                SellIn = 55
            };

            var items = new List<Item> { item };
            _gildedRose.UpdateQuality(items);
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
            
            var items = new List<Item> { item };
            _gildedRose.UpdateQuality(items);
            Assert.Equal(3, item.Quality);
        }
        
        [Theory]
        [InlineData(AgedBrie, 50)]

        public void GivenAgedBrieWithQuality50_WhenUpdatingQuality_ThenQualityRemains50(string itemName, int expected)
        {
            var item = new Item
            {
                Name = itemName,
                Quality = 50,
                SellIn = 0
            };
            
            var items = new List<Item> { item };
            _gildedRose.UpdateQuality(items);
            Assert.Equal(expected, item.Quality);
        }
        
        [Theory]
        [InlineData( 1, 50)]
        [InlineData( 5, 50)]
        [InlineData( 10, 50)]
        public void GivenBackstagePassWithQuality50AndSellInGreaterThanZero_WhenUpdatingQuality_ThenQualityRemains50(int sellIn, int expected)
        {
            var item = new Item
            {
                Name = BackstagePasses,
                Quality = 50,
                SellIn = sellIn
            };
            
            var items = new List<Item> { item };
            _gildedRose.UpdateQuality(items);
            Assert.Equal(expected, item.Quality);
        }
        
        [Fact]
        public void GivenBackstagePassWithQuality46AndSellInLessThanSix_WhenUpdatingQuality_ThenQualityShouldIncreaseByThree()
        {
            var item = new Item
            {
                Name = BackstagePasses,
                Quality = 46,
                SellIn = 4
            };
            
            var items = new List<Item> { item };
            _gildedRose.UpdateQuality(items);
            Assert.Equal(49, item.Quality);
        }
        
        [Fact]
        public void GivenBackstagePassWithQuality46AndSellInLessThan11GreaterThan5_WhenUpdatingQuality_ThenQualityShouldIncreaseBy2()
        {
            var item = new Item
            {
                Name = BackstagePasses,
                Quality = 46,
                SellIn = 10
            };
            
            var items = new List<Item> { item };
            _gildedRose.UpdateQuality(items);
            Assert.Equal(48, item.Quality);
        }
        
        [Fact]
        public void GivenBackstagePassWithQuality50AndSellInZero_WhenUpdatingQuality_ThenQualityBecomesZero()
        {
            var item = new Item
            {
                Name = BackstagePasses,
                Quality = 50,
                SellIn = 0
            };
            
            var items = new List<Item> { item };
            _gildedRose.UpdateQuality(items);
            Assert.Equal(0, item.Quality);
        }
        
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void GivenSulfurasWithQuality80_WhenUpdatingQuality_QualityIs80(int sellIn)
        {
            var item = new Item
            {
                Name = SulfurasHandOfRagnaros,
                Quality = 80,
                SellIn = sellIn
            };
            
            var items = new List<Item> { item };
            _gildedRose.UpdateQuality(items);
            Assert.Equal(80, item.Quality);
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

        [Fact]
        public void GivenAgedBrieSmartItem_WhenUpdateQuality_QualityIncreasesBy1()
        {
            var item = new Item
            {
                Name = AgedBrie,
                Quality = 10,
                SellIn = 10

            };
            var smartItem = new SmartItem(item);

            smartItem.Update();
            
            Assert.Equal(11, smartItem.Item.Quality);
        }
    }

    public class SmartItem
    {
        public Item Item { get; set; }
        
        public SmartItem(Item item)
        {
            Item = item;
        }

        public void Update()
        {
            Item.Quality++;
        }
    }
}