using Roulette.Models;

public class BetValidator
{
    public bool ValidateBet(PlaceBet bet)
    {
        return bet.Amount > 0;
    }
}
