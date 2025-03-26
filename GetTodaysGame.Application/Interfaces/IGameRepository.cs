using GetTodaysGame.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetTodaysGame.Application.Interfaces
{
    public interface IGameRepository
    {
        Task SaveGamesAsync(List<GameDto> games);
    }
}
