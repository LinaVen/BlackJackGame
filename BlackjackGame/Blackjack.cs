using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackGame
{
    public class Blackjack
    {
        //Link deck, player and dealer.
        private Deck deck;
        private Player player;
        private Player dealer;

        //Create  the deck.
        public Blackjack()
        {
            deck = new Deck();
            deck.Shuffle();
            player = new Player("Player");
            dealer = new Player("Dealer");
        }

        //Set up the player and dealer.
        public void Play()
        {
            Console.WriteLine("Welcome to Blackjack!");

            DealInitialCards();

            // Automatically stand if the player starts with 21.
            if (player.GetHandValue() == 21)
            {
                Console.WriteLine("Blackjack! You have 21. Automatically standing.");
            }
            else
            {
                PlayerTurn();
            }
            if (!player.IsBusted)
            {
                DealerTurn();
            }
            DetermineWinner();
        }

        //Deal the initial cards.
        public void DealInitialCards() //Github Copilot suggested to add 40 to 45 lines of code.
        {
            player.AddCard(deck.Deal());
            dealer.AddCard(deck.Deal());
            player.AddCard(deck.Deal());
            dealer.AddCard(deck.Deal());

            Console.WriteLine("Dealer's Hand: [Hidden], " + dealer.Hand[0]);
            player.ShowHand();
        }

        //Run the player's turn.
        private void PlayerTurn()
        {
            while (true)
            {

                Console.WriteLine("\nDo you want to Hit(H) or Stand(S)?");
                string choice = Console.ReadLine().ToUpper();
                if (choice == "H") //Github Copilot suggested to add 59 to 75 lines of code.
                {
                    player.AddCard(deck.Deal());
                    player.ShowHand();
                    // Automatically stand when the player reaches 21.
                    if (player.GetHandValue() == 21)
                    {
                        Console.WriteLine("You reached 21! Automatically standing.");
                        break;
                    }
                    if (player.IsBusted)
                    {
                        Console.WriteLine("You busted! Dealer wins!");
                        break;
                    }
                }
                else if (choice == "S")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please enter 'H' or 'S'.");
                }
            }
        }

        //Run the dealer's turn.
        private void DealerTurn()
        {
            Console.WriteLine("\nDealer's turn: ");
            dealer.ShowHand();

            while (dealer.GetHandValue() < 17)
            {
                dealer.AddCard(deck.Deal());
                dealer.ShowHand();
            }
            
        }


        //Compare the player's and dealer's hands and show the result.
        private void DetermineWinner()
        {
            Console.WriteLine("\nFinal results: ");
            player.ShowHand();
            dealer.ShowHand();
            // Check whether either hand is a natural Blackjack.
            bool playerBlackjack = player.Hand.Count == 2 &&
                                   player.GetHandValue() == 21;

            bool dealerBlackjack = dealer.Hand.Count == 2 &&
                                   dealer.GetHandValue() == 21;

            // A natural Blackjack beats an ordinary 21.
            if (playerBlackjack && !dealerBlackjack)
            {
                Console.WriteLine("Blackjack! You win!");
            }
            else if (dealerBlackjack && !playerBlackjack)
            {
                Console.WriteLine("Dealer has Blackjack! Dealer wins!");
            }
            else if (player.IsBusted)
            {
                Console.WriteLine("Dealer wins!");
            }
            else if (dealer.IsBusted)
            {
                Console.WriteLine("You win! Dealer busted!");
            }
        
            else if (player.GetHandValue() > dealer.GetHandValue())
            {
                Console.WriteLine("You win!");
            }
            else if (player.GetHandValue() < dealer.GetHandValue())
            {
                Console.WriteLine("Dealer wins!");
            }
            else
            {
                Console.WriteLine("It's a tie!"); //Github Copilot suggested to add 105 to 119 lines of code

            }
        }
    }
}