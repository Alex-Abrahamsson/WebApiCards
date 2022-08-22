using Microsoft.AspNetCore.Mvc;

namespace webapicards.Controllers;
[ApiController]
[Route("[controller]")]

public class CardGames : ControllerBase
{

    [HttpGet("{gameName}", Name = "Game")]
    //Get: /Game/{gameName}
    public IEnumerable<Card> Get(string gameName)
    {
        switch (gameName)
        {
            case "Blackjack":
                Deck BjDeck = new Deck();
                BjDeck.Shuffle();
                Card bjCard = BjDeck.Deal();
                Card bjCard2 = BjDeck.Deal();
                int sum = bjCard.value + bjCard2.value;
                return new List<Card>() {bjCard, bjCard2};
            case "Poker":
                return new List<Card>() {new Card("Test",1), new Card("Test", 2), new Card("Test", 3), new Card("Test", 4), new Card("Test", 5)};
            case "HighestCard":
                Deck deck = new Deck();
                deck.Shuffle();
                PlayerCardHand playerHand = new PlayerCardHand();
                PlayerCardHand computerHand = new PlayerCardHand();
                for (int i = 0; i < 5; i++)
                {
                    playerHand.AddCard(deck.Deal());
                    computerHand.AddCard(deck.Deal());
                }
                
                return new List<Card>() {playerHand.cards[0], computerHand.cards[0]};
            default:
                return new List<Card>() {new Card("ERROR", 4)};
        }
    }
    






}
