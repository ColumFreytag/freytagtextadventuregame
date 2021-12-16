using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace Lv13thSt
{

    public class Game
    {
        private Player _player;
        public ItemList Items;
        private RitualHouse ritualHouse = new RitualHouse();

        
        //good place for item compass
        public class ItemList : List<Item>
        {
            public void Add(string ItemName, string ItemLocation)
            {
                Add(new Item(ItemName, ItemLocation));
            }
        }

        


        public Game(string playername)
        {
            _player = new Player(playername);
            Items = new ItemList
            {
                { "Teddy Bear", "on the bedroom floor" },
                {"Sewing Needle", "in the bathroom cabinet" },
                {"Match", "on the kitchen counter" },
                {"Red Candle", "on the TV stand" },
                {"Ominous Page", "on the nightstand" },

                //for later
                //{"Index Finger", null }

            };

            PlaceItem("Red Candle", "Living Room");
            PlaceItem("Teddy Bear", "Bedroom");
            PlaceItem("Sewing Needle", "Bathroom");
            PlaceItem("Match", "Kitchen");
            PlaceItem("Ominous Page", "Bedroom");

            //for later extension of the game
            //_player.PickUpItem(Items.Find(i => i.ItemName == "Index Finger"), silent:true);

        }

        
        private void PlaceItem(string ItemName, string RoomName)
        {
            ritualHouse.Rooms.Find(r => r.Name == RoomName).RoomItems.Add(Items.Find(i => i.ItemName == ItemName));
        }


        public void Start()
        {
            WriteLine("Welcome to the Ritual House! Before we start I just need to get some information about you.");
            WriteLine("If you see '...' it just means to press any button to continue! Try it now\n\n...");
            ReadKey(true);
            Play();
        }

        public void Play()
        {
            Clear();

            //getting player info
            string ans;

            while (true)
            {
                WriteLine("Please enter your name: ");
                _player.Playername = ReadLine();
                Clear();
                WriteLine($"Hello: {_player.Playername}, what is your hair color?");
                _player.Playerhair = ReadLine();
                Clear();
                WriteLine("...and what is your eye color?");
                _player.Playereyes = ReadLine();
                Clear();
                WriteLine("...mmk, and how tall are you?");
                _player.Playerheight = ReadLine();
                Clear();

                WriteLine($"So what I've gathered is your name is {_player.Playername} you have {_player.Playereyes} eyes, {_player.Playerhair} hair and are {_player.Playerheight}.\nIs this correct? Y / N");
                ans = ReadLine().ToLower();

                if (ans.StartsWith("y"))
                {
                    break;
                }


            }
            


            Clear();


            WriteLine("Are you ready to explore the Ritual House?");
            ans = Console.ReadLine().ToLower();
            if (ans.StartsWith("y"))
            {
                Clear();
                ExploreHouse();
            }



            //_player.PickupItem(Items.Find(i => i.ItemName == "Apple"));


        }

        public void ExploreHouse()
        {

            //referencing house class
            var house = ritualHouse;
            
            Console.WriteLine("Welcome to the Ritual House");
            Console.WriteLine($"You step through the {house.currentRoom.Name}\n");

            while (true)
            {
                Navigate(house);
                if (house.currentRoom.Name == "Altar" && _player.Pocket.Any(i => i.ItemName == "Lit Candle") && _player.Pocket.Any(i => i.ItemName == "Teddy Bear") && _player.Pocket.Any(i => i.ItemName == "Ominous Page"))
                {
                    InteractWithAltar();
                }
                else
                {
                    WriteLine("You can't make heads or tails of this right now. Try picking up more items...\n");
                    InteractWithRoom(house.currentRoom);
                }

                if(house.currentRoom.Name == "Basement")
                {
                    if(_player.Pocket.Any(i => i.ItemName == "Match") && _player.Pocket.Any(i => i.ItemName == "Red Candle"))
                    {
                        WriteLine("It's quite dark, would you like to try lighting your candle? Y / N");
                        var ans = ReadLine().ToUpper();
                        if(ans == "Y")
                        {
                            _player.Pocket.Add(new Item("Lit Candle", "This candle burns intensely"));
                            _player.Pocket.Remove(_player.Pocket.Find(i => i.ItemName == "Match"));
                            _player.Pocket.Remove(_player.Pocket.Find(i => i.ItemName == "Red Candle"));
                        }
                    }
                }

                if (house.currentRoom.Name == "Outside")
                {
                    WriteLine("You stepped outside, leaving the Ritual House behind you...");
                    End();
                    break;
                }
            }

        }

        private void InteractWithAltar()
        {
            var altar = new Altar();
            altar.AltarChoice(_player.Pocket);
        }


        public void Navigate(RitualHouse house)
        {

            Console.WriteLine($"Which direction?");
            house.currentRoom.Compass();

            var direction = Console.ReadLine().ToUpper();
            house.GoNext(direction);
        }

        
        public void InteractWithRoom(Room currentRoom)
        {

            foreach (var item in currentRoom.RoomItems.ToArray())
            {
                WriteLine($"You see a {item.ItemName} {item.ItemLocation}");
                WriteLine($"Do you pick it up? Y / N");
                
                var command = ReadLine().ToUpper();

                switch (command)
                {

                    default:
                        WriteLine("Incorrect key input");
                        break;

                    case "Y":
                        _player.PickUpItem(item);
                        currentRoom.RoomItems.Remove(item);
                        break;

                    case "N":
                        break;

                }

            }

            

        }




        public void End()
        {
            WriteLine("\n\nThank you for playing the game!");
            WriteLine("...");
            ReadKey(true);
        }

    }
}
