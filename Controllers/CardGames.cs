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
                
                return new List<PlayerCardHand>() {playerHand, computerHand};
            default:
                return new List<PlayerCardHand>() {new PlayerCardHand("Apskalle"), new PlayerCardHand("mjaaao")};
        }
    }
    






}
