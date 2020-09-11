using System.Linq;
using GameDirectory.API.Models;

namespace GameDirectory.API.Services
{
    public interface IGameService
    {
        IQueryable<Game> All();
        Game Create(Game game);
        Game Delete(Game game);
        Game Delete(int id);
        Game Get(int id);
    }
}