using System;
using static System.Console;
using System.Collections.Generic;

namespace Lv13thSt
{

    public class Player
    {


        public List<Item>Pocket = new List<Item>();

        public string Playername { get; set; }
        public string Playerhair { get; set; }
        public string Playereyes { get; set; }
        public string Playerheight { get; set; }

        public int score = 0;

        //for inventory system

        //public void ListInventory()
        //{
        //    WriteLine("You are carrying...");
        //    foreach (var item in Pocket)
        //    {
        //        WriteLine(item.ItemName);
        //    }

        //}


        public Player(string playername)
        {
            Playername = playername;
        }

        public void PickUpItem(Item item, bool silent = false)
        {
            Pocket.Add(item);
            if (!silent)
            {
                WriteLine($"You picked up the {item.ItemName}\n");
            }

        }


    }
}
