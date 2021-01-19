/*
 * File name:               DeckClass.cs
 * Author:                  Johann Bekker
 * Created:                 20/08/2016
 * Operating System:        Windows 7 
 * Version:                 Home Basic
 * Description:             The following code was written to create a deck of cards. 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackProject
{
    public class DeckClass
    {
        // List contains all the objects of the Card class
        public List<CardClass> cards { set; get; }

        // Creates a deck of cards
        public DeckClass()
        {
            // Assigns new list to cards
            cards = new List<CardClass>(); // Contain objects of the CardClass
            deckRanksandSuits();
        }

        // Uses nested for loops used to create 52 numbers
        public void deckRanksandSuits()
        {
            // Counts through suits
            // Starts at suit 1 ('Spades')
            for (int suit = 1; suit < 5; suit++) // 4 Suits
            {
                // Counts through cards in each suit
                for (int rank = 1; rank < 14; rank++) // 13 Cards (ranks) in each suit (total 52 cards)
                {
                    // Creates a new card
                    CardClass currentcard = new CardClass();
                    // Assigns suit
                    // If suit is equal to 1
                    if (suit == 1)
                        // The current card's suit is 'Spades'
                        currentcard.suit = "Spades";
                    // If suit is equal to 2
                    if (suit == 2)
                        // The current card's suit is 'Clubs'
                        currentcard.suit = "Clubs";
                    // If suit is equal to 3
                    if (suit == 3)
                        // The current card's suit is 'Hearts'
                        currentcard.suit = "Hearts";
                    // If suit is equal to 4
                    if (suit == 4)
                        // The current card's suit is 'Diamonds'
                        currentcard.suit = "Diamonds";
                    // Assigns rank
                    currentcard.rank = rank;
                    // Adding card to deck
                    cards.Add(currentcard);
                }

            }
        }
    }
}


