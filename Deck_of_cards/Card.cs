using System;
namespace Deck_of_cards{
    using System.Collections.Generic;
    public class Card{          //this is created to build the attributes/properites of cards
        public string stringVal;
        public string suit;
        public int val;
        public Card(string cardSuit, string cardValue, int j) //this is needed to define the parameters we will later pass
        {
            suit = cardSuit;
            stringVal = cardValue;
            val = j;
        }
    }
    public class Deck //
    {   
        // public object[] cardDeck = new object[52];
        List<Card> cardDeck = new List<Card>(); //crrate list to add new cards created to this list...cannot add to an array
        public Deck()   ///constructor-defines how to start an instance.will be run everytime.!-- this is where checks and functions should be
        {
          makeDeck(); //moved everything that was inside of the constructor to a method and called on that method
        } 
        public void makeDeck()
        {
            string[] suits = { "Spades", "Hearts", "Diamonds", "Clubs" };
            string[] stringVal = { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };
            string cardSuit;
            string cardValue;
            for (int i = 0; i < 4; i++)
            {
                cardSuit = suits[i];
                for (int j = 0; j < 13; j++)
                {
                    cardValue = stringVal[j];
                    Card myCards = new Card(cardSuit, cardValue, j + 1);
                    cardDeck.Add(myCards);
                }
            }
        }  
        public void showDeck()  //method --this is going to do stuff..not changing anything, just showing what's inside
        {
            foreach(Card card in cardDeck)
            {
                Console.WriteLine("Card:" + card.suit + "," + card.stringVal + card.val);
            }
        }
        public Card deal()  //since this is not void, we want to return something, we need to specify what we are returning--in this case we are wanting to return from the Card class
        {
            Card topcard = cardDeck[0];
            cardDeck.Remove(topcard);
            return topcard;
        }
        public void reset()
        {
            cardDeck.Clear();
            makeDeck();
        }
        public void shuffle()
        {
            cardDeck.Sort();
        }
    }
    // public class Player
    // {
    //     public Property()
    //     {

}