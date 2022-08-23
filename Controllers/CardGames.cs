using Microsoft.AspNetCore.Mvc;

namespace webapicards.Controllers;
[ApiController]
[Route("[controller]")]

public class CardGames : ControllerBase
{

    [HttpGet("{gameName}", Name = "Game")]
    //Get: /Game/{gameName}
    public IEnumerable<PlayerCardHand> Get(string gameName)
    {
        switch (gameName)
        {
            case "Blackjack":
                Deck BjDeck = new Deck();
                BjDeck.Shuffle();
                Card bjCard = BjDeck.Deal();
                Card bjCard2 = BjDeck.Deal();
                int sum = bjCard.value + bjCard2.value;
                PlayerCardHand bjPlayer = new PlayerCardHand("Blackjack");
                return new PlayerCardHand[] { bjPlayer };
            case "Poker":
                return new List<PlayerCardHand>() { new PlayerCardHand("Poker"), new PlayerCardHand("Test") };
            case "HighestCard":            
                return PlayHighestCard(5);
            default:
                return new List<PlayerCardHand>() {new PlayerCardHand("None"), new PlayerCardHand("None")};
        }
    }
    

    public static List<PlayerCardHand> PlayHighestCard(int amountOfCards){
        Deck deck = new Deck();
        deck.Shuffle();
        PlayerCardHand playerHand = new PlayerCardHand("Player");
        PlayerCardHand computerHand = new PlayerCardHand("Computer");
        for (int i = 0; i < amountOfCards; i++)
        {
            playerHand.AddCard(deck.Deal());
            computerHand.AddCard(deck.Deal());
        }
        playerHand.SortCards();
        computerHand.SortCards();
        if (playerHand.GetHighestCard().value > computerHand.GetHighestCard().value)
        {
            return new List<PlayerCardHand>() { playerHand, computerHand };
        }
        else
        {
            return new List<PlayerCardHand>() { computerHand, playerHand };
        }
    }




}
