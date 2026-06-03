//The game rules source is https://www.pagat.com/banking/blackjack.html and https://web.archive.org/web/20230213054726/https://thepogg.com/guides/blackjack/
//Standard Blackjack is played between the player and the dealer.
//The goal is to get as close to 21 as possible without going over.
//The player and the dealer are dealth two cards each.
//Stop drawwing once reach or exceed 17.
//If the player goes over 21, the dealer wins.
//Aces are worth 1 or 11, face cards are worth 10, and all other cards are worth their face value.
//When the player hands value is higher than the dealer's, without busting, the player wins.
//If the dealer hands value is higher than the player's, without busting, the dealer wins.
//If the player and the dealer have the same value, it's a tie.

//Create card, deck, player and game classes.



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Blackjack blackjack = new Blackjack();
            blackjack.Play();
        }
    }
}
