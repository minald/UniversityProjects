using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace RestApiMinald.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ChessGameController : ControllerBase
	{
		private readonly AppContext appContext;

		public ChessGameController(AppContext appContext)
		{
			this.appContext = appContext;
		}

		// GET: api/<ChessGameController>
		[HttpGet]
		public IEnumerable<ChessGame> Get()
		{
			return appContext.ChessGames.ToList();
		}

		// GET api/<ChessGameController>/5
		[HttpGet("{id}")]
		public ActionResult<ChessGame> Get(int id)
		{
            var game = appContext.ChessGames.FirstOrDefault(g => g.Id == id);
            if (game == null)
            {
                return NotFound();
            }
				
			return new ObjectResult(game);
		}

		// POST api/<ChessGameController>
		[HttpPost]
		public ActionResult<ChessGame> Post([FromBody] ChessGame chessGame)
		{
            if (chessGame == null)
			{
				return BadRequest();
			}

            appContext.ChessGames.Add(chessGame);
            appContext.SaveChanges();
			return Ok(chessGame);
		}

        // PUT api/<ChessGameController>/5
        [HttpPut]
		public ActionResult<ChessGame> Put([FromBody] ChessGame chessGame)
		{
            if (chessGame == null)
			{
				return BadRequest();
			}
			if (!appContext.ChessGames.Any(x => x.Id == chessGame.Id))
			{
				return NotFound();
			}

            appContext.Update(chessGame);
            appContext.SaveChanges();
			return Ok(chessGame);
		}

        // DELETE api/<ChessGameController>/5
        [HttpDelete("{id}")]
		public ActionResult<ChessGame> Delete(int id)
		{
            ChessGame chessGame = appContext.ChessGames.FirstOrDefault(x => x.Id == id);
			if (chessGame == null)
			{
				return NotFound();
			}

            appContext.ChessGames.Remove(chessGame);
			appContext.SaveChanges();
			return Ok(chessGame);
		}
    }
}
