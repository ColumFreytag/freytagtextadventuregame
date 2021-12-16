using System;
using static System.Console;
using System.Collections.Generic;

namespace Lv13thSt
{
    public class Altar
    {

        private List<string> _symbolisms = new List<string>() { "On the left you see a depiction of a lush forest", "In the middle is a depiction of a erupting volcano", "On the right you see three red drops encircled by enscriptions" };


        public Altar()
        {

        }

        public void AltarChoice(List<Item> inventory)
        {


            bool done = false;
            while (!done)
            {
                done = AltarChoiceCore(inventory);
            }
        }

        private bool AltarChoiceCore(List<Item> inventory)
        {

            WriteLine("You stand before an ominous altar. What would you like to do?\n\n1) Interact\n2) Leave");
            string input = ReadLine();

            switch (input)
            {
                default:
                    WriteLine("That's not a choice");
                    ReadKey();
                    Clear();
                    return false;

                case "1":
                    AltarPlace(inventory);
                    return true;

                case "2":
                    return true;

            }


        }



        public void AltarPlace(List<Item> inventory)
        {
            Clear();


            List<string> altarBox = new List<string>();



            //read out each place to put an item and ask which item the player wants to put there
            WriteLine("Looking over the alter you assess you need to place your items atop it.\nThere seems to be three distinct locations...");
            WriteLine("...");
            ReadKey(true);
            Clear();


            foreach (var symbolism in _symbolisms)
            {
                WriteLine($"{symbolism}. Which item would you like to place here?\n");
                foreach (var Item in inventory)
                {
                    WriteLine(Item.ItemName);
                }

                string input = ReadLine().ToUpper();



                while (true)
                {
                    //this is the cheekiest solution because the characters don't overlap
                    if (input.StartsWith("T") || input.StartsWith("B"))
                    {
                        var x = inventory.FindIndex(i => i.ItemName == "Teddy Bear");
                        inventory.RemoveAt(x);
                        altarBox.Add("bear");
                        break;


                    }
                    else if (input.StartsWith("L") || input.StartsWith("C"))
                    {
                        var x = inventory.FindIndex(i => i.ItemName == "Lit Candle");
                        inventory.RemoveAt(x);
                        altarBox.Add("candle");
                        break;


                    }
                    else if (input.StartsWith("O") || input.StartsWith("P"))
                    {
                        var x = inventory.FindIndex(i => i.ItemName == "Ominous Page");
                        inventory.RemoveAt(x);
                        altarBox.Add("page");
                        break;


                    }
                    else if (input.StartsWith("S") || input.StartsWith("N"))
                    {
                        var x = inventory.FindIndex(i => i.ItemName == "Sewing Needle");
                        inventory.RemoveAt(x);
                        altarBox.Add("needle");
                        break;


                    }
                    else
                    {
                        WriteLine("You don't have that item, try typing in an item.");
                    }
                }
            }



            //check if objects are placed correctly
            var bear = altarBox.IndexOf("bear");
            var page = altarBox.IndexOf("page");
            var playername = "player1";
            var game = new Game(playername);

            if (bear == 0 && page == 2)
            {
                Clear();
                WriteLine("The table begins to glow softly... Quick! Shout some nonsense at it to see if it will do anything!");
                string nonsense = ReadLine().ToUpper();
                WriteLine($"With all the energy you can muster you shout {nonsense}!!");
                WriteLine("\n\nPress 'Enter' to continue...");
                ReadKey();
                Clear();
                WriteLine("Out of a puff of smoke arises a very startled black cat with glowing red eyes...\nIt briefly surveys it's surroundings before it hops off the table and dashes up the stairs");
                WriteLine("...");
                ReadKey();
                WriteLine("You stand there in silence wondering what this was all for...\nand if you'll ever see that cat again.");
                ReadKey();
                Clear();
                game.End();
                

                //call end credit sequence

            }
            else
            {
                //WriteLine("Nothing seems to be happening.. Would you like to try a different arrangement?\nY / N");
                //var ans = Console.ReadLine().ToUpper();
                //if (ans == "Y")
                //{
                //    altarBox.Clear();
                //    AltarPlace(inventory);
                //}
                //else
                //{
                //    altarBox.Clear();
                //}
                Clear();
                WriteLine("Despite your best effords nothing seems to have worked");
                WriteLine("Disappointed, you leave the house.");
                
                game.End();
                
            }




        }

    }
}
