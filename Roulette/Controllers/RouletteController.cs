using System;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Roulette.Models;

[ApiController]
[Route("api/roulette")]
public class RouletteController : ControllerBase
{
    private readonly GameService _gameService;

    public RouletteController(GameService gameService)
    {
        _gameService = gameService;
    }

    [HttpPost("placebet")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> PlaceBet([FromBody] PlaceBet bet)
    {
        try
        {

            await _gameService.PlaceBetAsync(bet);

            return Ok("Bet placed successfully");
        }
        catch (Exception ex)
        {


            return StatusCode(500, "An unexpected error occurred. Please try again later.");
        }




        //var success = await _gameService.PlaceBetAsync(bet);

        //if (success)
        //{
        //    return Ok(new { success = true, message = "Bet placed successfully" });
        //}

        //return BadRequest(new { success = false, message = "Invalid bet" });

    }

    [HttpPost("spin")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Spin()
    {
        try
        {

            return Ok("Spin not implemented");
        }
        catch (Exception ex)
        {


            return StatusCode(500, "An unexpected error occurred. Please try again later.");
        }
    }

    [HttpPost("payout")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Payout()
    {
        try
        {

            return Ok("Payout not implemeted");
        }
        catch (Exception ex)
        {

            return StatusCode(500, "An unexpected error occurred. Please try again later.");
        }
    }

    [HttpGet("showpreviousspins")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult ShowPreviousSpins()
    {
        try
        {
            return Ok("Previous Spin not implemented");
        }
        catch (Exception ex)
        {

            return StatusCode(500, "An unexpected error occurred. Please try again later.");
        }
    }

    public class Bet
    {
        public int Number { get; set; }
        public string Color { get; set; }
        public decimal Amount { get; set; }
    }

    public class BetRequest
    {
        public int Number { get; set; }
        public string Color { get; set; }
        public decimal Amount { get; set; }
    }
}
