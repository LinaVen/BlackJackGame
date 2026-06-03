using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackGame
{
    public class Player
    {
        public string Name { get; set; }
        public List<Card> Hand { get; set; }

        public bool IsBusted => GetHandValue() > 21;

        public Player(string name) //Github Copilot suggested to add 17 to 25 lines of code.
        {
            Name = name;
            Hand = new List<Card>();
        }

        public void AddCard(Card card)
        {
            Hand.Add(card);
        }

        public int GetHandValue() //Github Copilot suggested to add 28 to 38 lines of code.
        {
            int value = Hand.Sum(card => card.Value);
            int aceCount = Hand.Count(card => card.Rank == "Ace");

            while (value > 21 && aceCount > 0)
            {
                value -= 10;
                aceCount--;
            }
            return value;
        }
        public void ShowHand()
        {
            Console.WriteLine($"{Name}'s Hand: {string.Join(", ", Hand)} (Total:  {GetHandValue()})");
        }
    }
}
