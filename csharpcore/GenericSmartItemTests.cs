using Xunit;
using System.Collections.Generic;

namespace csharpcore
{
    public class GenericSmartItemTests
    {
        [Fact]
        public void GivenGenericItemWithQualityZero_WhenUpdatingQuality_ThenQualityRemainsZero()
        {
            var item = new Item
            {
                Name = "zeroQualityItem",
                Quality = 0
            };

            var smartItemGeneric = new GenericSmartItem(item);
            smartItemGeneric.Update();
            Assert.Equal(0, smartItemGeneric.Item.Quality);
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
            
            var smartItemGeneric = new GenericSmartItem(item);
            smartItemGeneric.Update();
            Assert.Equal(44, smartItemGeneric.Item.Quality);
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
            
            var smartItemGeneric = new GenericSmartItem(item);
            smartItemGeneric.Update();
            Assert.Equal(0, smartItemGeneric.Item.SellIn);
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
            
            var smartItemGeneric = new GenericSmartItem(item);
            smartItemGeneric.Update();
            Assert.Equal(0, smartItemGeneric.Item.Quality);
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
            
            var smartItemGeneric = new GenericSmartItem(item);
            smartItemGeneric.Update();
            Assert.Equal(8, smartItemGeneric.Item.Quality);
        }
    }

    public class GenericSmartItem : ISmartItem
    {
        public GenericSmartItem(Item item)
        {
            Item = item;
        }

        public Item Item { get; set; }
        public void Update()
        {
            DecreaseQuality(Item);
            DecreaseSellIn(Item);
            HandleItemsWithSellInLessThanZero(Item);  
        }
        
        private static void DecreaseQuality(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality = item.Quality - 1;
            }
        }

        private static void HandleItemsWithSellInLessThanZero(Item item)
        {
            if (item.SellIn < 0)
            {
                DecreaseQuality(item);
            }
        }

        private static void DecreaseSellIn(Item item)
        {
            item.SellIn = item.SellIn - 1;
        }
    }
}