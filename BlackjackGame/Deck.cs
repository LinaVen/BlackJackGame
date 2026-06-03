using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackGame
{
    public class Deck
    {
        //Show  the standard deck of 52 cards.
        private List<Card> cards;
        private Random random = new Random();

        public Deck()
        {
            cards = new List<Card>(); //Github Copilot suggested to add 17 to 27 lines of code.

            string[] suits = { Card.Hearts, Card.Diamonds, Card.Clubs, Card.Spades };
            string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };
            int[] values = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 11 };
            
            foreach (var suit in suits)
            {
                for (int i = 0; i < ranks.Length; i++)
                {
                    cards.Add(new Card(suit, ranks[i], values[i]));
                }
            }
        }
        public void Shuffle() //Github Copilot suggested to add 31 to 33 lines of code.
        { 
        cards = cards.OrderBy(c => random.Next()).ToList();
        }
        public Card Deal() //Github Copilot suggested to add 35 to 44 lines of code.
        {
            if (cards.Count == 0)
            {
                throw new InvalidOperationException("No cards in the deck.");
            }

            Card card = cards[0];
            cards.RemoveAt(0);
            return card;
        }
    }
}
