/*
 * File name:               HandClass.cs
 * Author:                  Johann Bekker
 * Created:                 20/08/2016
 * Operating System:        Windows 7 
 * Version:                 Home Basic
 * Description:             The following code creates a list structure to hold cards, adds cards to the hand,
 *                          chooses random card from the deck by using the RandomClass, calculates the current 
 *                          score of the hand.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackProject
{
    public class HandClass
    {
        public List<CardClass> cards { set; get; }
        public int scoreOfHand { set; get; }
        public int InitialAmountOfCards { set; get; }
        
        // Constructor creates list and adds empty/blank cards
        public HandClass(int CardsInHand)
        {
            InitialAmountOfCards = CardsInHand; // Number of cards in a hand
            // List to hold cards
            cards = new List<CardClass>();
            // Blank card
            CardClass blankCard = new CardClass();
            // For every card in hand
            for (int blankcard = 0; blankcard < CardsInHand; blankcard++)
            {
                // There will be a blank card added to the list
                cards.Add(blankCard); // Adding blank card to list
            }
        }

        // Chooses random card from deck and adds it to the hand (blank spot)
        public void addCard(DeckClass deck, int numberOfCardsInHand)
        {

            int chosencard = 0;

            // Chooses random card from deck using random number received from the 'RandomClass'
            chosencard = RandomClass.randomBetween(1, deck.cards.Count); // (minimum, maximum)
            CardClass currentcard = deck.cards.ElementAt(chosencard);
            // Instance of the CardClass created
            CardClass blankCardSpace = new CardClass();

            foreach (CardClass CardDrawn in cards)
            {
                if (CardDrawn.suit == "blank")
                    blankCardSpace = CardDrawn;
            }
            // Removes blank space
            cards.Remove(blankCardSpace);
            // Adds random card chosen 
            cards.Add(currentcard);
            // Removes card added to hand from deck to ensure it is not chosen again
            deck.cards.Remove(currentcard);
        }

        // Limits the amount of cards used
        public void dealCards(DeckClass currentdeck, int cardsInDeck)
        {
            cardsInDeck = cards.Count;
            for (int dealtCards = 0; dealtCards < cardsInDeck; dealtCards++)
            {
                addCard(currentdeck, cardsInDeck);
            }
        }

        // Calculates the current score of a hand
        public void calculateHand()
        {
            // Score of hand is first initialised to 0
            scoreOfHand = 0;
            // Assigning king, queen, 10 and jack a value of 10
            foreach (CardClass recievedCard in cards)
            {
                // If the card's rank is less than 10
                if (recievedCard.rank < 10)
                    // Each card's value is determined by its rank
                    // The received card's value is added to the score
                    scoreOfHand = scoreOfHand + recievedCard.rank;
                else
                    // Other cards recieve a value of 10
                    // The received card's value is added to the score
                    scoreOfHand = scoreOfHand + 10;
            }
            // Adjusts for aces
            foreach (CardClass recievedCard in cards)
            {
                // Ace is given a value of 11 or 1, depending on score
                if (recievedCard.rank == 1 && scoreOfHand + 10 <= 21)
                    scoreOfHand = scoreOfHand + 10;
            }
        }
    } 
}




