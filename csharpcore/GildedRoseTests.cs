using System.Collections.Generic;
using Moq;
using Xunit;

namespace csharpcore
{
    public class GildedRoseTests
    {
        private readonly GildedRose _gildedRose;
        private readonly Mock<ISmartItemFactory> _smartItemFactoryMock;

        public GildedRoseTests()
        {
            _smartItemFactoryMock = new Mock<ISmartItemFactory>();
            _gildedRose = new GildedRose(_smartItemFactoryMock.Object);
        }

        private const string AgedBrie = "Aged Brie";
        private const string BackstagePass = "Backstage passes to a TAFKAL80ETC concert";
        private const string SulfurasHandOfRagnaros = "Sulfuras, Hand of Ragnaros";
        
        
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
            
            _gildedRose.UpdateQuality(new List<Item> { item });
            Assert.Equal(duplicateItem.Quality, item.Quality);
            Assert.Equal(duplicateItem.SellIn, item.SellIn);
            Assert.Equal(duplicateItem.Name, item.Name);
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
            
            _gildedRose.UpdateQuality(new List<Item> { item });
            Assert.Equal(duplicateItem.Quality, item.Quality);
            Assert.Equal(duplicateItem.SellIn, item.SellIn);
            Assert.Equal(duplicateItem.Name, item.Name);
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
            
            _gildedRose.UpdateQuality(new List<Item> { item });
            Assert.Equal(duplicateItem.Quality, item.Quality);
            Assert.Equal(duplicateItem.SellIn, item.SellIn);
            Assert.Equal(duplicateItem.Name, item.Name);
        }

        [Fact]
        public void GivenItemList_UpdatesItem()
        {
            var agedBrie = new Item
            {
                Name = AgedBrie,
                Quality = 45
            };

            var items = new List<Item> {agedBrie};

            var smartItemMock = new Mock<ISmartItem>();
            _smartItemFactoryMock.Setup(f => f.Create(agedBrie)).Returns(smartItemMock.Object);
            _gildedRose.UpdateQuality(items);

            _smartItemFactoryMock.Verify(f => f.Create(agedBrie), Times.Once);
            smartItemMock.Verify(i => i.Update(), Times.Once);
        }
    }
}