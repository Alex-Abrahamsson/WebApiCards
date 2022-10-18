using Microsoft.AspNetCore.Mvc;
using WebApiCards.Services;
using WebApiCards.Models;

namespace webapicards.Controllers;
[ApiController]
[Route("Alex/[controller]/[action]")]

public class CardGames : ControllerBase
{
    private static HighestCard highestCardGame = new HighestCard();
    static GameStatus gameStatus = new GameStatus();

    //GET: Alex/startgame?gametype={gameType}
    [HttpGet]
    [ProducesResponseType(200, Type = typeof(GameStatus))]
    [ProducesResponseType(400)]
    public async Task<IActionResult> StartGame(string gameType)
    {
        if (gameStatus.StartGame(gameType.ToLower().Trim()))
        {
            return Ok(gameStatus);
        }

        return BadRequest($"Game of type {gameStatus.GameType} is already running");
    }

    //GET: Alex/endgame
    [HttpGet]
    [ProducesResponseType(200, Type = typeof(GameStatus))]
    [ProducesResponseType(400)]
    public async Task<IActionResult> EndGame()
    {
        if (gameStatus.EndGame())
        {
            return Ok(gameStatus);
        }

        return BadRequest($"No game is running");
    }

    //Play HighestCardGame
    public static List<PlayerCardHand> HighestCardGame()
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
        var playerHighest = playerHand.cards[playerHand.cards.Count - 1].value;
        var computerHighest = computerHand.cards[computerHand.cards.Count - 1].value;
        if (playerHighest > computerHighest)
        {
            playerHand.isWinner = true;
            computerHand.isWinner = false;
            return new List<PlayerCardHand> { playerHand, computerHand };
        }
        else if (computerHighest > playerHighest)
        {
            playerHand.isWinner = false;
            computerHand.isWinner = true;
            return new List<PlayerCardHand> { playerHand, computerHand };
        }
        else
        {
            playerHand.isWinner = false;
            computerHand.isWinner = false;
            return new List<PlayerCardHand> { playerHand, computerHand };
        }
    }

    //GET: Alex/playgame
    [HttpGet]
    [ProducesResponseType(200, Type = typeof(List<PlayerCardHand>))]
    [ProducesResponseType(400)]
    public async Task<IActionResult> PlayGame()
    {
        if (gameStatus.IsRunning)
        {
            return Ok(HighestCardGame());
        }

        return BadRequest($"No game is running");
    }
}
