using System;
using static System.Console;
using System.Collections.Generic;


namespace Lv13thSt
{
    public class RitualHouse
    {

        public Room currentRoom;
        public List<Room> Rooms;


        public RitualHouse()
        {
             Rooms = new List<Room>
                {
                    new Room(this, "Living Room", "It's a ramshackle mess. Torn wallpapers, stuffing flying out of couches.\n", new Dictionary<string, int>{{"N", 2 },{"S", 6 },{ "E", 1 } }),
                    new Room(this, "Bathroom", "Despite the destitute state of the broken floor tiles and the grime covered toilet,\nthere is no strong odor. Surprising.\n", new Dictionary<string, int>{{"W", 2 },{"N", 3 } }),
                    new Room(this, "Kitchen", "No cabinet door is affixed properly and you're sure if you tried the sink it wouldn't work.\n", new Dictionary<string, int>{{"S", 0 },{"E", 3 },{"N", 4 } }),
                    new Room(this, "Bedroom", "If only the bed had a mattress this room might look fairly decent... comparatively.\n", new Dictionary<string, int>{{"S", 1 },{ "W", 2 } }),
                    new Room(this, "Basement", "Though you're doubtful anyone's been murdered here, it certainly would be the place.\n", new Dictionary<string, int>{{"W", 5 },{ "S", 2 } }),
                    new Room(this, "Altar", "Very eerie. A picture of a giant black creature with huge red eyes is painted behind it.\n", new Dictionary<string, int>{{"E", 4 } }),
                    new Room(this, "Front Door", "Description of living room", new Dictionary<string, int>{ { "N", 0 } ,{"S", 7} }),
                    new Room(this, "Outside", null, new Dictionary<string, int>{})

                };

        currentRoom = Rooms[6];

        }



        //If type 'North' Room has to check if has a "north" door if yes goes north
        public Room GoNext(string direction)
        {
            Clear();
            //Console.WriteLine($"Leaving {currentRoom.Name}");

            currentRoom = Rooms[currentRoom.Doorways[direction]];
            Console.WriteLine($"You walk to the {currentRoom.Name}...\n");
            Console.WriteLine(currentRoom.Description);
            return currentRoom;

        }





    }
}
