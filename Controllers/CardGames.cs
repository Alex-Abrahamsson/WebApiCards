using Microsoft.AspNetCore.Mvc;

namespace webapicards.Controllers;

[ApiController]
[Route("[controller]")]

public class CardGames : ControllerBase
{
    [HttpGet("{gameName}", Name = "Game")]
    //Get: /Game/{gameName}
    public IEnumerable<string> Get(string gameName)
    {
        switch (gameName)
        {
            case "Blackjack":
                Deck BjDeck = new Deck();
                BjDeck.Shuffle();
                Card bjCard = BjDeck.Deal();
                Card bjCard2 = BjDeck.Deal();
                int sum = bjCard.value + bjCard2.value;
                return new List<string>() {$"{bjCard} {bjCard2} {sum}"};
            case "Poker":
                return new List<string>() {"Playing Poker"};
            case "HighestCard":
                Deck deck = new Deck();
                deck.Shuffle();
                Card card = deck.Deal();
                Card card2 = deck.Deal();
                if (card.value > card2.value)
                {
                    return new List<string>() {$"A fresh deck of cards are made","The dealer shuffles the deck","The dealer deals 1 card to the player and 1 card to himself","Player 1 wins with -{card.ToString()}- Over -{card2.ToString()}"};
                }
                else if (card.value < card2.value)
                {
                    return new List<string>() {$"Player 2 wins with *{card2.ToString()}* Over *{card.ToString()}*"};
                }
                else
                {
                    return new List<string>() {$"{card.ToString()} and {card2.ToString()} are equal"};
                }
            default:
                return new List<string>() {"Invalid game name"};
        }
    }





    static void PlayHighestCard()
    { 
        Deck deck = new Deck();
        deck.Shuffle();
        Console.WriteLine($"There are {deck.RemainingCards()} cards left in the deck.");
        Card card = deck.Deal();
        Console.WriteLine($"The top card is {card}.");
        Console.WriteLine($"There are {deck.RemainingCards()} cards left in the deck.");
        Console.ReadLine();
        Card card2 = deck.Deal();
        Console.WriteLine($"The top card is {card2}.");
        Console.WriteLine($"There are {deck.RemainingCards()} cards left in the deck.");
        Console.ReadLine();
        // get sum of card 3 and card 4
        int sum = card.value + card2.value;
        Console.WriteLine($"The sum of the cards is {sum}.");
        Console.ReadLine();
    }
}
