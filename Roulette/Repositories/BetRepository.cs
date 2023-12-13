using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Roulette.Data;
using Roulette.Models;

public class BetRepository
{
    private readonly RouletteDbContext _dbContext;

    public BetRepository(RouletteDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<PlaceBet>> GetAllPlaceBetsAsync()
    {
        return await _dbContext.Bets.ToListAsync();
    }

    public async Task InsertBetAsync(PlaceBet placeBet)
    {
        _dbContext.Bets.Add(placeBet);
        await _dbContext.SaveChangesAsync();
    }
}


