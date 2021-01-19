/*
 * File name:               Form1.cs
 * Author:                  Johann Bekker
 * Created:                 20/08/2016
 * Operating System:        Windows 7 
 * Version:                 Home Basic
 * Description:             The following code determines which card images, messages, buttons and 
 *                          scores will be displayed to the user.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace BlackjackProject
{
    public partial class ProgramDisplay : Form
    {
        public DeckClass currentdeck { get; set; }
        public HandClass dealerhand { get; set; }
        public HandClass playerhand { get; set; }
        public int initialCards { get; set; }

        public ProgramDisplay()
        {
            InitializeComponent();

            // Action buttons
            // Shows 'DEAL' button
            btnDEAL.Visible = false;
            // Hides 'HIT' button
            btnHIT.Visible = false;
            // Hides 'STAY' button
            btnSTAY.Visible = false;
            
            // Hides all cards
            hideCards();
            // Sets the scoreboard values to '0'
            scoreboard();
            // Message that will appear when application is first launched
            promptMessage.Text = "Press 'New Game' to begin.";
            // Customises the message
            MessageCustomisation();
        }

        // Scoreboard totals are declared as int and public so they can be used in calculations
        public int winCounter = 0;
        public int lossCounter = 0;
        public int tieCounter = 0;
        public int gameCounter = 0;

        // Displays all of the player's cards
        public void showPlayerCards(HandClass playerhand)
        {
            // Initialises the amount of cards in player's hand to '0'
            int cardCountInHand = 0;
            // Clears image information
            string imageOfCurrentCard = "";
            // If player has cards in hand
            if (playerhand != null)
                // The for each loop is used to determine which stored image will be displayed for the card in player's hand
                foreach (CardClass currentcard in playerhand.cards)
                {
                    if (currentcard != null)
                    {
                        // Determines card's rank and suit using card's specific image name information stored 
                        // If the card's rank is less than 10
                        if (currentcard.rank < 10)
                            imageOfCurrentCard = "_0" + currentcard.rank.ToString() + currentcard.suit;
                        // If the card's rank is equal to 10
                        if (currentcard.rank == 10)
                            imageOfCurrentCard = "_" + currentcard.rank.ToString() + currentcard.suit; // 10
                        // If the card's rank is equal to 11
                        if (currentcard.rank == 11)
                            imageOfCurrentCard = "J" + "_" + currentcard.suit; // Jack
                        // If the card's rank is equal to 12
                        if (currentcard.rank == 12)
                            imageOfCurrentCard = "Q" + "_" + currentcard.suit; // Queen
                        // If the card's rank is equal 13
                        if (currentcard.rank == 13)
                            imageOfCurrentCard = "K" + "_" + currentcard.suit; // King
                    }
                   
                    // The most cards which can be displayed for player is 11 cards (four 1’s + four 2’s + three 3’s = 21)
                    
                    // If player has no cards in hand
                    if (cardCountInHand == 0)
                    {
                        // The first card can be displayed
                        PlayerCard1.Visible = true; // Shows first card
                        // Locates card image stored
                        // Creates instance of the ResourceManager class to obtain the stored image
                        System.Resources.ResourceManager resource = BlackjackProject.Properties.Resources.ResourceManager;
                        Bitmap CardImage = (Bitmap)resource.GetObject(imageOfCurrentCard);
                        // Sets picture box to display stored image 
                        PlayerCard1.Image = CardImage;
                        // Adjusts card image to fit the picture box
                        PlayerCard1.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    // If player has 1 card in hand
                    if (cardCountInHand == 1)
                    {
                        // The second card can be displayed
                        PlayerCard2.Visible = true;
                        System.Resources.ResourceManager resource = BlackjackProject.Properties.Resources.ResourceManager;
                        Bitmap CardImage = (Bitmap)resource.GetObject(imageOfCurrentCard);
                        PlayerCard2.Image = CardImage;
                        PlayerCard2.SizeMode = PictureBoxSizeMode.StretchImage;
                    }

                    // If player has 2 cards in hand
                    if (cardCountInHand == 2)
                    {
                        // The third card can be displayed
                        PlayerCard3.Visible = true; 
                        System.Resources.ResourceManager resource = BlackjackProject.Properties.Resources.ResourceManager;
                        Bitmap CardImage = (Bitmap)resource.GetObject(imageOfCurrentCard);
                        PlayerCard3.Image = CardImage;
                        PlayerCard3.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    // If player has 3 cards in hand
                    if (cardCountInHand == 3)
                    {
                        // Fourth card can be displayed
                        PlayerCard4.Visible = true;
                        System.Resources.ResourceManager resource = BlackjackProject.Properties.Resources.ResourceManager;
                        Bitmap CardImage = (Bitmap)resource.GetObject(imageOfCurrentCard);
                        PlayerCard4.Image = CardImage;
                        PlayerCard4.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    // If player has 4 cards in hand
                    if (cardCountInHand == 4)
                    {
                        // Fifth card can be displayed
                        PlayerCard5.Visible = true;
                        System.Resources.ResourceManager resource = BlackjackProject.Properties.Resources.ResourceManager;
                        Bitmap CardImage = (Bitmap)resource.GetObject(imageOfCurrentCard);
                        PlayerCard5.Image = CardImage;
                        PlayerCard5.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    // If player has 5 cards in hand
                    if (cardCountInHand == 5)
                    {
                        // Sixth card can be displayed
                        PlayerCard6.Visible = true;
                        System.Resources.ResourceManager resource = BlackjackProject.Properties.Resources.ResourceManager;
                        Bitmap CardImage = (Bitmap)resource.GetObject(imageOfCurrentCard);
                        PlayerCard6.Image = CardImage;
                        PlayerCard6.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    // If player has 6 cards in hand
                    if (cardCountInHand == 6)
                    {
                        // Seventh card can be displayed
                        PlayerCard7.Visible = true; 
                        System.Resources.ResourceManager resource = BlackjackProject.Properties.Resources.ResourceManager;
                        Bitmap CardImage = (Bitmap)resource.GetObject(imageOfCurrentCard);
                        PlayerCard7.Image = CardImage;
                        PlayerCard7.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    // If player has 7 cards in hand
                    if (cardCountInHand == 7)
                    {
                        // Eighth card can be displayed
                        PlayerCard8.Visible = true;
                        System.Resources.ResourceManager resource = BlackjackProject.Properties.Resources.ResourceManager;
                        Bitmap CardImage = (Bitmap)resource.GetObject(imageOfCurrentCard);
                        PlayerCard8.Image = CardImage;
                        PlayerCard8.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    // If player has 8 cards in hand
                    if (cardCountInHand == 8)
                    {
                        // Ninth card can be displayed
                        PlayerCard9.Visible = true; 
                        System.Resources.ResourceManager resource = BlackjackProject.Properties.Resources.ResourceManager;
                        Bitmap CardImage = (Bitmap)resource.GetObject(imageOfCurrentCard);
                        PlayerCard9.Image = CardImage;
                        PlayerCard9.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    // If player has 9 cards in hand
                    if (cardCountInHand == 9)
                    {
                        // Tenth card can be displayed
                        PlayerCard10.Visible = true;
                        System.Resources.ResourceManager resource = BlackjackProject.Properties.Resources.ResourceManager;
                        Bitmap CardImage = (Bitmap)resource.GetObject(imageOfCurrentCard);
                        PlayerCard10.Image = CardImage;
                        PlayerCard10.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    // If player has 10 cards in hand
                    if (cardCountInHand == 10)
                    {
                        // Eleventh and player's final card can be displayed
                        PlayerCard11.Visible = true;
                        System.Resources.ResourceManager resource = BlackjackProject.Properties.Resources.ResourceManager;
                        Bitmap CardImage = (Bitmap)resource.GetObject(imageOfCurrentCard);
                        PlayerCard11.Image = CardImage;
                        PlayerCard11.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    // Jumps to player's next card
                    cardCountInHand++;
                }
        }

        // Displays all the dealer's cards
        // Works same way as when showing player's cards - this is just for the dealer
        public void showDealerCards(HandClass dealerhand)
        {
            int cardCountInHand = 0;
            string imageOfCurrentCard = "";
            if (dealerhand != null)
                foreach (CardClass currentcard in dealerhand.cards)
                {
                    if (currentcard != null)
                    {
                        // Determines card's rank and suit using card's specific image name information stored 
                        // If the card's rank is less than 10
                        if (currentcard.rank < 10)
                            // Starts at rank 1 (Ace)
                            imageOfCurrentCard = "_0" + currentcard.rank.ToString() + currentcard.suit;
                        // If the card's rank is equal to 10
                        if (currentcard.rank == 10)
                            imageOfCurrentCard = "_" + currentcard.rank.ToString() + currentcard.suit; // 10
                        // If the card's rank is equal to 11
                        if (currentcard.rank == 11)
                            imageOfCurrentCard = "J" + "_" + currentcard.suit; // Jack
                        // If the card's rank is equal to 12
                        if (currentcard.rank == 12)
                            imageOfCurrentCard = "Q" + "_" + currentcard.suit; // Queen
                        // If the card's rank is equal to 13
                        if (currentcard.rank == 13)
                            imageOfCurrentCard = "K" + "_" + currentcard.suit; // King
                    }

                    // According to given specifications the dealer must stand at 17
                    // So the most cards which can be displayed for dealer is 10 cards (four 1’s + four 2’s + two 3’s = 18)
                   
                    // If the dealer has no cards in hand
                    if (cardCountInHand == 0)
                    {
                        // The first card can be displayed
                        DealerCard2.Visible = true;
                        System.Resources.ResourceManager resource = BlackjackProject.Properties.Resources.ResourceManager;
                        Bitmap CardImage = (Bitmap)resource.GetObject(imageOfCurrentCard);
                        DealerCard2.Image = CardImage;
                        DealerCard2.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    // If the dealer has 1 card in hand
                    if (cardCountInHand == 1)
                    {
                        // The second card can be displayed
                        DealerCard1.Visible = true;
                        System.Resources.ResourceManager resource = BlackjackProject.Properties.Resources.ResourceManager;
                        Bitmap CardImage = (Bitmap)resource.GetObject(imageOfCurrentCard);
                        DealerCard1.Image = CardImage;
                        DealerCard1.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    // If the dealer has 2 cards in hand
                    if (cardCountInHand == 2)
                    {
                        // The third card can be displayed
                        DealerCard3.Visible = true;
                        System.Resources.ResourceManager resource = BlackjackProject.Properties.Resources.ResourceManager;
                        Bitmap CardImage = (Bitmap)resource.GetObject(imageOfCurrentCard);
                        DealerCard3.Image = CardImage;
                        DealerCard3.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    // If the dealer has 3 cards in hand
                    if (cardCountInHand == 3)
                    {
                        // The fourth card can be displayed
                        DealerCard4.Visible = true;
                        System.Resources.ResourceManager resource = BlackjackProject.Properties.Resources.ResourceManager;
                        Bitmap CardImage = (Bitmap)resource.GetObject(imageOfCurrentCard);
                        DealerCard4.Image = CardImage;
                        DealerCard4.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    // If the dealer has 4 cards in hand
                    if (cardCountInHand == 4)
                    {
                        // The fifth card can be displayed
                        DealerCard5.Visible = true;
                        System.Resources.ResourceManager resource = BlackjackProject.Properties.Resources.ResourceManager;
                        Bitmap CardImage = (Bitmap)resource.GetObject(imageOfCurrentCard);
                        DealerCard5.Image = CardImage;
                        DealerCard5.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    // If the dealer has 5 cards in hand
                    if (cardCountInHand == 5)
                    {
                        // The sixth card can be displayed
                        DealerCard6.Visible = true;
                        System.Resources.ResourceManager resource = BlackjackProject.Properties.Resources.ResourceManager;
                        Bitmap CardImage = (Bitmap)resource.GetObject(imageOfCurrentCard);
                        DealerCard6.Image = CardImage;
                        DealerCard6.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    // If the dealer has 6 cards in hand
                    if (cardCountInHand == 6)
                    {
                        // The seventh card can be displayed
                        DealerCard7.Visible = true;
                        System.Resources.ResourceManager resource = BlackjackProject.Properties.Resources.ResourceManager;
                        Bitmap CardImage = (Bitmap)resource.GetObject(imageOfCurrentCard);
                        DealerCard7.Image = CardImage;
                        DealerCard7.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    // If the dealer has 7 cards in hand
                    if (cardCountInHand == 7)
                    {
                        // The eigth card can be displayed
                        DealerCard8.Visible = true;
                        System.Resources.ResourceManager resource = BlackjackProject.Properties.Resources.ResourceManager;
                        Bitmap CardImage = (Bitmap)resource.GetObject(imageOfCurrentCard);
                        DealerCard8.Image = CardImage;
                        DealerCard8.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    // If the dealer has 8 cards in hand
                    if (cardCountInHand == 8)
                    {
                        // The ninth card can be displayed
                        DealerCard9.Visible = true;
                        System.Resources.ResourceManager resource = BlackjackProject.Properties.Resources.ResourceManager;
                        Bitmap CardImage = (Bitmap)resource.GetObject(imageOfCurrentCard);
                        DealerCard9.Image = CardImage;
                        DealerCard9.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    // If the dealer has 9 cards in hand
                    if (cardCountInHand == 9)
                    {
                        // The tenth card can be displayed
                        DealerCard10.Visible = true;
                        System.Resources.ResourceManager resource = BlackjackProject.Properties.Resources.ResourceManager;
                        Bitmap CardImage = (Bitmap)resource.GetObject(imageOfCurrentCard);
                        DealerCard10.Image = CardImage;
                        DealerCard10.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    // Jumps to dealer's next card
                    cardCountInHand++;
                }
        }

        // Compare scores and determines who won
        public void endProgram(HandClass playerhand, HandClass dealerhand)
        {
            btnDEAL.Visible = true; // Deal button is visible
            btnHIT.Visible = false; // Hit button hidden
            btnSTAY.Visible = false; // Stick button hidden
            
            // Shows dealer's cards
            showDealerCards(dealerhand);
            // Dealer hits when hand/score is less than 17
            // Dealer receives one random card until his score is equal or greater than 17
            while (dealerhand.scoreOfHand < 17)
            {
                // One card given to dealer
                dealerhand.addCard(currentdeck, 1);
                // Dealer's score is calculated
                dealerhand.calculateHand();
            }
            // If the dealer's score is greater than 21 and the player's score is equal to the dealer's score
            if ((dealerhand.scoreOfHand > 21) & (playerhand.scoreOfHand == dealerhand.scoreOfHand))
            {
                // Player loses
                lost();
            }
            // If the player's score is greater than 21
            if (playerhand.scoreOfHand > 21)
            {
                // Player loses
                lost();
            }
            else
            {
                // If player's score is greater than or equal to dealer's score and player's score is less than or equal to 21
                if ((playerhand.scoreOfHand >= dealerhand.scoreOfHand) && (playerhand.scoreOfHand <= 21))
                {
                   // Player wins
                    won();
                }

                // If player's score is less than or equal to 21 and score is equal to dealer's score
                if ((playerhand.scoreOfHand <= 21) & (dealerhand.scoreOfHand == playerhand.scoreOfHand))
                {
                    // It's a tie
                    gameResultMessage.Text = "TIE!"; // Message displayed
                    // Dealer's score converted to string
                    dealerScoreIndicator.Text = dealerhand.scoreOfHand.ToString();
                    // Dealer's cards are displayed
                    showDealerCards(dealerhand);
                }

                // If dealer's score is greater than 21 and the player's score is less than or equal to 21
                if ((dealerhand.scoreOfHand > 21) && (playerhand.scoreOfHand <= 21))
                {
                    // Player wins
                    won();
                }

                // If dealer's score is less than or equal to 21 and player's score is less than dealer's score
                if ((dealerhand.scoreOfHand <= 21) && (playerhand.scoreOfHand < dealerhand.scoreOfHand))
                {
                    // Player loses
                    lost();
                }
            }

            // If the game has a result message which is equal to 8 characters in length
            if (gameResultMessage.Text.Length == 8) // ('YOU WIN!')
            {
                // 'WINS' on the scoreboard is increased by one
                winCounter = winCounter + 1;
                // The int value is converted to string to be displayed
                winsAmount.Text = winCounter.ToString();
                gameCounter = gameCounter + 1;
            }
            // If the game has a result message which is equal to 9 characters in length
            if (gameResultMessage.Text.Length == 9) // ('YOU LOSE!')
            {
                // 'LOSSES' on the scoreboard is increased by one
                lossCounter = lossCounter + 1;
                // The int value is converted to string to be displayed
                lossesAmount.Text = lossCounter.ToString();
                gameCounter = gameCounter + 1;
            }
            // If the game has a result message which is equal to 4 characters in length
            if (gameResultMessage.Text.Length == 4) // ('TIE!')
            {
                // 'TIES' on the scoreboard is increased by one
                tieCounter = tieCounter + 1;
                // The int value is converted to string to be displayed
                tiesAmount.Text = tieCounter.ToString();
                gameCounter = gameCounter + 1;
            }
        }

        // Buttons
        // 'DEAL' button
        private void btnDEAL_Click(object sender, EventArgs e) // When pressed
        {
            // Everthing is reset except the scoreboard

            btnDEAL.Visible = false;
            btnHIT.Visible = true;
            btnSTAY.Visible = true;

            // Initial amount of cards to be dealt
            initialCards = 2; // Two cards each
            // Creates new deck of cards
            currentdeck = new DeckClass();
            // Creates new hand for player
            playerhand = new HandClass(initialCards);
            // Creates new hand for dealer
            dealerhand = new HandClass(initialCards);
            // Clears result message
            gameResultMessage.Text = "";
           
            // 'Game Result' text box customisation
            // Font is set to yellow
            gameResultMessage.ForeColor = System.Drawing.Color.Yellow;
            // Background of text box is set to dark green
            gameResultMessage.BackColor = System.Drawing.Color.DarkGreen;
            // Creates new font
            Font font = new Font("Calibri", 16.0f);
            // Assigns new font to the text box
            gameResultMessage.Font = font;

            // Hides all the cards
            hideCards();

            // Player
            // Deals the amount of cards (2) specified at beginning of this method to the player from the deck
            playerhand.dealCards(currentdeck, initialCards);
            // Displays the player's two dealt cards
            showPlayerCards(playerhand);
            // Calculates the player's score of the two dealt cards
            playerhand.calculateHand();
            // The player's score is converted to string to be displayed
            playerScoreIndicator.Text = playerhand.scoreOfHand.ToString();

            // Dealer
            // Deals the amount of cards (2) specified at beginning of this method to the dealer from the deck
            dealerhand.dealCards(currentdeck, initialCards); 
            // Displays the dealer's two dealt cards
            showDealerCards(dealerhand);
            
            // Displays the dealer's second dealt card as face down 
            System.Resources.ResourceManager resource = BlackjackProject.Properties.Resources.ResourceManager;
            Bitmap CardImage = (Bitmap)resource.GetObject("CardBack");
            DealerCard1.Image = CardImage;
            DealerCard1.SizeMode = PictureBoxSizeMode.StretchImage;
            
            // Dealer's current hand score is displayed as a question mark
            dealerScoreIndicator.Text = "?";
            
            // When player is dealt 21 (Blackjack)
            if (playerhand.scoreOfHand == 21)
            {
                // 'HIT' button hidden
                btnHIT.Visible = false;
                // 'STAY' button is shown
                btnSTAY.Visible = true;
                // The following message will appear
                promptMessage.Text = "Press 'STAY' to see Dealer's hand!";
            }
           
            // If player's score is less than 21
            if (playerhand.scoreOfHand < 21)
            {
                // The following message will appear
                promptMessage.Text = "Would you like to 'HIT' or 'STAY'?";
            }
        }

        // 'HIT' button
        private void btnHIT_Click(object sender, EventArgs e) // When pressed
        {
            // 'DEAL' button hidden
            btnDEAL.Visible = false;
            // 'HIT' button shown
            btnHIT.Visible = true;
            // 'STAY' button hidden
            btnSTAY.Visible = true;
            
            // Player is dealt a random card from the deck
            playerhand.addCard(currentdeck, 1);
            // The card is displayed
            showPlayerCards(playerhand);
            // The player's current score is recalculated
            playerhand.calculateHand();
            // Player's score is converted to string to be displayed
            playerScoreIndicator.Text = playerhand.scoreOfHand.ToString();

            // If player's score is greater than or equal to 21
            if (playerhand.scoreOfHand >= 21)
            {
                // Scores are compared and there is determined who won
                endProgram(playerhand, dealerhand);
            }
        }

        // 'STAY' button
        private void btnSTAY_Click(object sender, EventArgs e) // When pressed
        {
            // Scores are compared and there is determined who won
            endProgram(playerhand, dealerhand);
        }

        // 'Quit' button
        private void btnQuit_Click(object sender, EventArgs e) // When pressed
        {
            // Dialog box will appear when 'Quit' is pressed
            DialogResult choice = MessageBox.Show(
                "Are you sure you would you like to quit the game?",
                "Quit JB's Blackjack?", MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            // If the user clicks the 'Yes' option on the dialog box
            if (choice == DialogResult.Yes)
            {
                // Application will terminate
                Application.Exit();
            }
        }

        // 'New Game' button
        private void btnNewGame_Click(object sender, EventArgs e) // When pressed
        {
            // If games have been played
            if (gameCounter != 0)
            {
                // Dialog box will appear
                DialogResult choice = MessageBox.Show(
                 // Asks user the following
                "All current game progress will be lost, continue?",
                   "Start New Game?", MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question);

                // When the user clicks the 'Yes' option on the dialog box
                if (choice == DialogResult.Yes)
                {
                    btnDEAL.Visible = true;
                    btnHIT.Visible = false;
                    btnSTAY.Visible = false;

                    // Sets the scoreboard values to '0'
                    scoreboard();
                    gameCounter = 0;
                    // Clears the 'Game Result' text box
                    gameResultMessage.Text = "";
                    // Sets dealer's current hand score to '0'
                    dealerScoreIndicator.Text = "0";
                    // Sets player's current hand score to '0'
                    playerScoreIndicator.Text = "0";
                    // Hides all the cards
                    hideCards();

                    // Message prompts user to press 'DEAL'
                    // Message that will appear when 'New Game' is pressed
                    promptMessage.Text = "Press 'DEAL' to start the game.";
                }
            }
            // If games have not been played
            else{
                    btnDEAL.Visible = true;
                    btnHIT.Visible = false;
                    btnSTAY.Visible = false;
                
                    // Sets the scoreboard values to '0'
                    scoreboard();
                    // Clears the 'Game Result' text box
                    gameResultMessage.Text = "";
                    // Sets dealer's current hand score to '0'
                    dealerScoreIndicator.Text = "0";
                    // Sets player's current hand score to '0'
                    playerScoreIndicator.Text = "0";
                    // Hides all the cards
                    hideCards();

                    // Message prompts user to press 'DEAL'
                    // Message that will appear when 'New Game' is pressed
                    promptMessage.Text = "Press 'DEAL' to start the game.";

                }
        }

        // Sets the scoreboard values to '0'
        public void scoreboard()
        {
            // 'WINS'
            // Int value used for calculations
            winCounter = 0;
            // String is used to display score
            winsAmount.Text = "0";
            
            // 'LOSSES'
            lossCounter = 0;
            lossesAmount.Text = "0";
            
            // 'TIES'
            tieCounter = 0;
            tiesAmount.Text = "0";
        }
       
        // Customises message displayed to user (asking user to press buttons)
        public void MessageCustomisation()
        {
            // Sets the font colour to yellow
            promptMessage.ForeColor = System.Drawing.Color.Yellow;
            // Sets the text box background to dark green
            promptMessage.BackColor = System.Drawing.Color.DarkGreen;
            // Creates new font
            Font font = new Font("Calibri", 10.0f);
            // Sets text box font to new font
            promptMessage.Font = font;
        }

        // When the user loses
        public void lost() 
        {
            // Message that will be displayed 
            gameResultMessage.Text = "YOU LOSE!";
            // Dealer's score converted to string to be displayed
            dealerScoreIndicator.Text = dealerhand.scoreOfHand.ToString();
            // Displays the dealer's cards
            showDealerCards(dealerhand);
            // Message that will be displayed
            promptMessage.Text = "Press 'DEAL' to start the next round!";
        }

        // When the user wins
        public void won()
        {
            // Message that will be displayed 
            gameResultMessage.Text = "YOU WIN!";
            // Dealer's score converted to string to be displayed
            dealerScoreIndicator.Text = dealerhand.scoreOfHand.ToString();
            // Displays the dealer's cards
            showDealerCards(dealerhand);
            // Message that will be displayed
            promptMessage.Text = "Press 'DEAL' to start the next round!";
        }

        // Hides all cards
        public void hideCards()
        {
            // Player's cards
            PlayerCard1.Visible = false;
            PlayerCard2.Visible = false;
            PlayerCard3.Visible = false;
            PlayerCard4.Visible = false;
            PlayerCard5.Visible = false;
            PlayerCard6.Visible = false;
            PlayerCard7.Visible = false;
            PlayerCard8.Visible = false;
            PlayerCard9.Visible = false;
            PlayerCard10.Visible = false;
            PlayerCard11.Visible = false;
            // Dealer's cards
            DealerCard2.Visible = false;
            DealerCard1.Visible = false;
            DealerCard3.Visible = false;
            DealerCard4.Visible = false;
            DealerCard5.Visible = false;
            DealerCard6.Visible = false;
            DealerCard7.Visible = false;
            DealerCard8.Visible = false;
            DealerCard9.Visible = false;
            DealerCard10.Visible = false;
        }
     }
} 


