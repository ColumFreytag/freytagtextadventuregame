using System;
using System.Collections.Generic;


namespace Lv13thSt
{
    public class Room
    {
        public Dictionary<string, int> Doorways = new Dictionary<string, int>();
        public string Name;
        public string Description;
        public RitualHouse House;

        public Game.ItemList RoomItems = new Game.ItemList();

        //need list inventory with item name & description




        public Room(RitualHouse house, string name, string description, Dictionary<string, int>doorways)
        {
            Name = name;
            Doorways = doorways;
            House = house;
            Description = description;

        }


        public void ListItems()
        {
            foreach(var item in RoomItems)
            {
                Console.WriteLine($"You see a {item.ItemName} {item.ItemLocation}");
                Console.WriteLine($"Do you pick it up?");
                
            }


        }

        public void Compass()
        {
            foreach (var doorway in Doorways)
            {
                Console.WriteLine($"{doorway.Key}: {House.Rooms[doorway.Value].Name}");
            }
        }





    }
}
