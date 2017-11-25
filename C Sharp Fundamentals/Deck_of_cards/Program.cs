using System;

namespace Deck_of_cards
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck cardDeck = new Deck(); ///this is looking at the deck class for the deck function(the constructor function)
            // cardDeck.showDeck(); //this is the deck method function on a specific instance
            Card pullCard = cardDeck.deal(); //working in the deal class, but we are returning something from the card class, which explains why CArd needs to be on the left side
            Console.WriteLine(pullCard.stringVal);
            Console.WriteLine(pullCard.suit);
            Console.WriteLine(pullCard.val);
            cardDeck.showDeck();
            cardDeck.reset();
            cardDeck.showDeck();
            cardDeck.shuffle();
        }
    }
}
