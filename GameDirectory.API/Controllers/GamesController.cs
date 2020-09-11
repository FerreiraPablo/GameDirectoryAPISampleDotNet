using GameDirectory.API.Models;
using GameDirectory.API.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GameDirectory.API.Controllers
{
    [Route("api/[controller]")]
    public class GamesController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GamesController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_gameService.All());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var game = _gameService.Get(id);
            if(game == null)
            {
                return NotFound();
            }

            return Ok(game);
        }

        [HttpPost]
        public IActionResult Post(Game game)
        {
            _gameService.Create(game);
            return CreatedAtAction(nameof(Get),new { id = game.Id }, game);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var game = _gameService.Get(id);
            if (game == null)
            {
                return NotFound();
            }

            _gameService.Delete(id);
            return NoContent();

        }
    }
}
