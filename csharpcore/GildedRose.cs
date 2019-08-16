using System.Collections.Generic;
using csharpcore;

namespace csharpcore
{
    public class GildedRose
    {
        private readonly ISmartItemFactory _smartItemFactory;
        
        public GildedRose(ISmartItemFactory smartItemFactory)
        {
            _smartItemFactory = smartItemFactory;
        }

        public void UpdateQuality(IList<Item> items)
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