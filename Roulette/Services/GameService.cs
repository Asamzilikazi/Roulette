using Roulette.Data;
using Roulette.Models;
using System;
using System.Threading.Tasks;

public class GameService
{
    private readonly BetRepository _betRepository;
    private readonly BetValidator _betValidator;

    public GameService(BetRepository betRepository, BetValidator betValidator)
    {
        _betRepository = betRepository;
        _betValidator = betValidator;
    }

    public async Task<bool> PlaceBetAsync(PlaceBet bet)
    {
        if (!_betValidator.ValidateBet(bet))
        {
            // Handle invalid bet
            return false;
        }

        await _betRepository.InsertBetAsync(bet);
        return true;
    }
}
   