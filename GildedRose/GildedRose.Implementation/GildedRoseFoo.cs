using System.Collections.Generic;

namespace GildedRose.Implementation
{
    public class GildedRoseFoo
    {
        private readonly ISmartItemFactory _smartItemFactory;
        
        public GildedRoseFoo(ISmartItemFactory smartItemFactory)
        {
            _smartItemFactory = smartItemFactory;
        }

        public void UpdateQuality(IEnumerable<Item> items)
        {
            foreach (var item in items)
            {
                UpdateItem(item);
            }
        }

        private void UpdateItem(Item item)
        {
            var smartItem = _smartItemFactory.Create(item);
            smartItem.Update();
        }
    }
}