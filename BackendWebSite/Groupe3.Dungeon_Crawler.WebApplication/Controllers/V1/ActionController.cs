using AspNet.Security.OAuth.Validation;
using Groupe3.Dungeon_Crawler.EntitiesContext;
using Groupe3.Dungeon_Crawler.WebApplication.ViewModels;
using Groupe3.Dungeon_Crawler.Entity;
using Groupe3.Dungeon_Crawler.Entity.Game;
using Groupe3.Dungeon_Crawler.UnitOfWork.Contract;
using Groupe3.Dungeon_Crrawler.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Groupe3.Dungeon_Crawler.WebApplication.Controllers.V1
{
    [ApiController]
    [Route("~/Action")]
    [Authorize(AuthenticationSchemes = OAuthValidationDefaults.AuthenticationScheme)]
    public class ActionController : ControllerBase
    {
        private readonly IUnitOfWork<DungeonCrawlerDbContextSql, GameService> _unitOfWork;
        public ActionController(IUnitOfWork<DungeonCrawlerDbContextSql, GameService> uow) => _unitOfWork = uow;

        [HttpPost("Skill")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UseSkillCharacter(UseSkillsVM vM){
            _unitOfWork.GameService.UseSkill(vM.GameId, vM.NbRoom, vM.LauncherId, vM.TargetId, vM.NbSkill);
            var game = _unitOfWork.GameService.Get(vM.GameId);
            return Ok(game.Rooms[vM.NbRoom]);
        }
    }
}