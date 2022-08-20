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
                Card card = deck.Deal();
                Card card2 = deck.Deal();
                if (card.value > card2.value)
                {
                    return new List<Card>() {card, card2};
                }
                else if (card.value < card2.value)
                {
                    return new List<Card>() {card2, card};
                }
                else
                {
                    return new List<Card>() {card, card2};
                }
            default:
                return new List<Card>() {new Card("Test", 4)};
        }
    }
    






}
