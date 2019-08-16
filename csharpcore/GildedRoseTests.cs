using System.Collections.Generic;
using Xunit;

namespace csharpcore
{
    public class GildedRoseTests
    {
        private const string AgedBrie = "Aged Brie";
        private const string BackstagePass = "Backstage passes to a TAFKAL80ETC concert";
        private const string SulfurasHandOfRagnaros = "Sulfuras, Hand of Ragnaros";
        
        [Fact]
        public void GivenAgedBrieItem_UpdatesAccordingToAgedBrieSmartItem()
        {
            var item = new Item
            {
                Name = AgedBrie,
                Quality = 45
            };

            var duplicateItem = new Item
            {
                Name = AgedBrie,
                Quality = 45
            };

            var smartItem = new AgedBrieSmartItem(duplicateItem);
            smartItem.Update();
            
            var gildedRose = new GildedRose();
            gildedRose.UpdateQuality(new List<Item> { item });
            Assert.Equal(duplicateItem.Quality, item.Quality);
            Assert.Equal(duplicateItem.SellIn, item.SellIn);
        }
        
        [Fact]
        public void GivenSulfurasItem_UpdatesAccordingToSulfurasSmartItem()
        {
            var item = new Item
            {
                Name = SulfurasHandOfRagnaros,
                Quality = 45
            };

            var duplicateItem = new Item
            {
                Name = SulfurasHandOfRagnaros,
                Quality = 45
            };

            var smartItem = new SulfurasSmartItem(duplicateItem);
            smartItem.Update();
            
            var gildedRose = new GildedRose();
            gildedRose.UpdateQuality(new List<Item> { item });
            Assert.Equal(duplicateItem.Quality, item.Quality);
            Assert.Equal(duplicateItem.SellIn, item.SellIn);
        }
        
        [Fact]
        public void GivenBackStagePassItem_UpdatesAccordingToBackStagePassSmartItem()
        {
            var item = new Item
            {
                Name = BackstagePass,
                Quality = 45
            };

            var duplicateItem = new Item
            {
                Name = BackstagePass,
                Quality = 45
            };

            var smartItem = new BackstagePassSmartItem(duplicateItem);
            smartItem.Update();
            
            var gildedRose = new GildedRose();
            gildedRose.UpdateQuality(new List<Item> { item });
            Assert.Equal(duplicateItem.Quality, item.Quality);
            Assert.Equal(duplicateItem.SellIn, item.SellIn);
        }
        
        [Fact]
        public void GivenGenericItem_UpdatesAccordingToGenericSmartItem()
        {
            var item = new Item
            {
                Name = "Generic",
                Quality = 45
            };

            var duplicateItem = new Item
            {
                Name = "Generic",
                Quality = 45
            };

            var smartItem = new GenericSmartItem(duplicateItem);
            smartItem.Update();
            
            var gildedRose = new GildedRose();
            gildedRose.UpdateQuality(new List<Item> { item });
            Assert.Equal(duplicateItem.Quality, item.Quality);
            Assert.Equal(duplicateItem.SellIn, item.SellIn);
            Assert.Equal(duplicateItem.Name, item.Name);
        }
    }
}