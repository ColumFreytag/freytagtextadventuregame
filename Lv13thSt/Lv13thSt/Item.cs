using System;
namespace Lv13thSt
{
    public class Item
    {
        public string ItemName { get; private set; }
        public string ItemLocation { get; set; }

        public Item(string itemName, string initialLocation)
        {
            
            ItemName = itemName;
            ItemLocation = initialLocation;

        }
    }
}
