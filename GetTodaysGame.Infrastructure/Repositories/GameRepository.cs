using GetTodaysGame.Application.Interfaces;
using GetTodaysGame.Application.Models;
using GetTodaysGame.Entities.SqlLite;
using GetTodaysGame.Infrastructure.Data;

namespace GetTodaysGame.Infrastructure.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly AppDbContext _context;
        public GameRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task SaveGamesAsync(List<GameDto> games)
        {
            foreach (var dto in games)
            {
                _context.Games.Add(new Game
                {
                    AwayTeamName = dto.AwayTeamName,
                    AwayTeamLosses = dto.AwayTeamLosses,
                    AwayTeamWins = dto.AwayTeamWins,
                    HomeTeamName = dto.HomeTeamName,
                    HomeTeamLosses = dto.HomeTeamLosses,
                    HomeTeamWins = dto.HomeTeamWins,
                    DateSubmitted = DateTimeOffset.Now.ToString("yyyyMMdd")
                });
            }
            await _context.SaveChangesAsync();
        }
    }
}
