//Credits:

//Insane amounts of help with game design discussions and various coding techniques from Dr. Asmus Freytag
//Help with TryParse from CheesyCode's "Parse TryParse In C# | Convert String To Data Types C#" video
//Refresher on Lists from BinaryBunny's "Learn C# In 5 Minutes | Lists" video
//
//Roughly based on the code/concepts of Coding Adventure Game from http://programmingisfun.com/


using System;

namespace Lv13thSt
{
    class Program
    {
        static void Main()
        {
            var playername = "player1";
            var game = new Game(playername);
            game.Start();

        }
    }
}
