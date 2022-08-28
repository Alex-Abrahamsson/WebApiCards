using WebApiCards.Models;

namespace WebApiCards.Services
{
public class HighestCard
    {
        //Create highestcard gamemode for the game
        public static PlayerCardHand HighestCardGame()
        {
            Deck deck = new Deck();
            deck.Shuffle();
            PlayerCardHand playerHand = new PlayerCardHand("Player");
            PlayerCardHand computerHand = new PlayerCardHand("Computer");
            for (int i = 0; i < 5; i++)
            {
                playerHand.AddCard(deck.Deal());
                computerHand.AddCard(deck.Deal());
            }
            playerHand.SortCards();
            computerHand.SortCards();
            if (playerHand.GetHighestCard().value > computerHand.GetHighestCard().value)
            {
                return playerHand;
            }
            else
            {
                return computerHand;
            }
        }
    }
}