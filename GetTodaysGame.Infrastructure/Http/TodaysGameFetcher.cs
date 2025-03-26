using GetTodaysGame.Application.Interfaces;
using GetTodaysGame.Application.Models;
using GetTodaysGame.Entities.ScheduleLeague;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GetTodaysGame.Infrastructure.Http
{
    public class TodaysGameFetcher : ITodaysGameFetcher
    {
        private readonly HttpClient _httpClient;
        private readonly string _scheduleLeagueUrl;
        public TodaysGameFetcher(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _scheduleLeagueUrl = config["scheduleLeaugeJson"];
        }

        public async Task<List<GameDto>> FetchTodaysGamesAsync()
        {
            try
            {
                // read the json from url
                var responseStream = await _httpClient.GetStreamAsync(_scheduleLeagueUrl);
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var schedule = await JsonSerializer.DeserializeAsync<Root>(responseStream, options);

                // only get today's games
                var todaysGames = schedule.LeagueSchedule.GameDates
                    .Where(gd => DateTime.TryParse(gd.Date, out DateTime gameDate) && gameDate.Date == DateTime.Today)
                    .SelectMany(gd => gd.Games.Select(game => new
                    {
                        Date = DateTime.Parse(gd.Date),
                        game.GameId,
                        game.GameCode,
                        game.HomeTeam,
                        game.AwayTeam
                    }))
                    .OrderBy(game => game.Date)
                    .ToList();

                List<GameDto> todaysGamesDTO = new List<GameDto>();

                if (todaysGames.Count > 0)
                {
                    foreach (var game in todaysGames)
                    {

                        todaysGamesDTO.Add(
                        new GameDto
                        {
                            AwayTeamName = game.AwayTeam.teamName,
                            AwayTeamLosses = game.AwayTeam.losses,
                            AwayTeamWins = game.AwayTeam.wins,
                            HomeTeamName = game.HomeTeam.teamName,
                            HomeTeamLosses = game.HomeTeam.losses,
                            HomeTeamWins = game.HomeTeam.wins,
                            DateSubmitted = DateTimeOffset.Now.ToString("yyyyMMdd")
                        });
                    }
                }
                return todaysGamesDTO;
            } catch (Exception ex)
            {
                throw;
            }
        }
    }
}
