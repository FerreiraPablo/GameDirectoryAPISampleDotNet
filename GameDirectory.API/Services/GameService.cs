using System;
using System.Collections.Generic;
using System.Linq;
using GameDirectory.API.Contexts;
using GameDirectory.API.Models;

namespace GameDirectory.API.Services
{
    public class GameService : IGameService
    {
        private readonly GamesDatabase _gamesDatabase;

        public GameService(GamesDatabase gamesDatabase)
        {
            _gamesDatabase = gamesDatabase;
        }

        public IQueryable<Game> All()
        {
            return _gamesDatabase.Games;
        }

        public Game Get(int id)
        {
            return _gamesDatabase.Games.Find(id);
        }

        public Game Create(Game game)
        {
            _gamesDatabase.Add(game);
            _gamesDatabase.SaveChanges();
            return game;
        }

        public Game Delete(Game game)
        {
            _gamesDatabase.Remove(game);
            _gamesDatabase.SaveChanges();
            return game;
        }

        public Game Delete(int id)
        {
            return Delete(Get(id));
        }
    }
}
