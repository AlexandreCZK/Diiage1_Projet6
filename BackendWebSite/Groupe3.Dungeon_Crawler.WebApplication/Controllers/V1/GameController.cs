using AspNet.Security.OAuth.Validation;
using AspNet.Security.OpenIdConnect.Primitives;
using Groupe3.Dungeon_Crawler.EntitiesContext;
using Groupe3.Dungeon_Crawler.Entity;
using Groupe3.Dungeon_Crawler.Entity.Game;
using Groupe3.Dungeon_Crawler.UnitOfWork.Contract;
using Groupe3.Dungeon_Crrawler.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net.Mime;
using System.Security.Claims;

namespace Groupe3.Dungeon_Crawler.WebApplication.Controllers.V1
{
    [ApiController]
    [Route("~/Games")]
    [Authorize(AuthenticationSchemes = OAuthValidationDefaults.AuthenticationScheme)]
    public class GameController : ControllerBase
    {
        private readonly IUnitOfWork<DungeonCrawlerDbContextSql, GameService> _unitOfWork;
        public GameController(IUnitOfWork<DungeonCrawlerDbContextSql, GameService> uow) => _unitOfWork = uow;

        [HttpGet("{id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Get([FromRoute] string id)
        {
            try
            {
                ClaimsIdentity identity = HttpContext.User.Identity as ClaimsIdentity;
                var idUser = identity.FindFirst(OpenIdConnectConstants.Claims.ClientId).Value;

                var game = _unitOfWork.GameService.Get(id);
                if (game == null)
                {
                    return NotFound(new { Message = "Game introuvable" });
                }
                if (game.Character.UserId != long.Parse(idUser))
                {
                    return Unauthorized(new { Message = "Cette game ne vous appartient pas" });
                }
                return Ok(game);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("{idGame}/Rooms/{nbrRoom}")]
        public IActionResult GetRoom([FromRoute] string idGame, [FromRoute] int nbrRoom)
        {
            try
            {
                ClaimsIdentity identity = HttpContext.User.Identity as ClaimsIdentity;
                var idUser = identity.FindFirst(OpenIdConnectConstants.Claims.ClientId).Value;

                var game = _unitOfWork.GameService.Get(idGame);
                if (game == null)
                {
                    return NotFound(new { Message = "Game introuvable" });
                }
                if (game.Character.UserId != long.Parse(idUser))
                {
                    return Unauthorized(new { Message = "Cette game ne vous appartient pas" });
                }

                var room = _unitOfWork.GameService.GetRoom(idGame, nbrRoom);
                if (room == null)
                {
                    return NotFound(new { Message = "Room introuvable" });
                }
                return Ok(room);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult Create(Game vM)
        {
            try
            {

                ClaimsIdentity identity = HttpContext.User.Identity as ClaimsIdentity;
                var idUser = identity.FindFirst(OpenIdConnectConstants.Claims.ClientId).Value;
                var user = _unitOfWork.GetRepository<User>().GetById(long.Parse(idUser));

                var character = _unitOfWork.GetRepository<Character>().GetFirstOrDefault(
                    c => c.Id == vM.Character.Id && user.Id == c.UserId,
                    include: c => c.Include(c => c.Skills).Include(c => c.Items)
                    );
                if (character == null)
                {
                    return NotFound(new { Message = "Charactères introuvable" });
                }
                var game = new Game
                {
                    Character = character
                };
                game = _unitOfWork.GameService.Create(game);

                return Ok(new { game.GameId });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);  
                return StatusCode(500);
            }
        }
    }
}