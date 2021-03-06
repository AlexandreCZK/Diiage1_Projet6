using AspNet.Security.OAuth.Validation;
using AspNet.Security.OpenIdConnect.Primitives;
using Groupe3.Dungeon_Crawler.EntitiesContext;
using Groupe3.Dungeon_Crawler.Entity;
using Groupe3.Dungeon_Crawler.Entity.Helper;
using Groupe3.Dungeon_Crawler.UnitOfWork.Contract;
using Groupe3.Dungeon_Crrawler.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net.Mime;
using System.Security.Claims;

namespace Groupe3.Dungeon_Crawler.WebApplication.Controllers
{
    [ApiController]
    [Route("~/Characters")]
    [Authorize(AuthenticationSchemes = OAuthValidationDefaults.AuthenticationScheme)]
    public class CharacterController : ControllerBase
    {
        private readonly IUnitOfWork<DungeonCrawlerDbContextSql, GameService> _unitOfWork;
        public CharacterController(IUnitOfWork<DungeonCrawlerDbContextSql, GameService> uow) => _unitOfWork = uow;

        [HttpGet("{id?}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetCharacterForUser([FromRoute] int? id = null)
        {
            try
            {
                ClaimsIdentity identity = HttpContext.User.Identity as ClaimsIdentity;
                var idUser = identity.FindFirst(OpenIdConnectConstants.Claims.ClientId).Value;
                var user = _unitOfWork.GetRepository<User>().GetById(long.Parse(idUser));
                if (id == null)
                {
                    var characters = _unitOfWork.GetRepository<Character>().GetMuliple(c => c.UserId == user.Id);
                    return Ok(characters);
                }
                else
                {
                    var character = _unitOfWork.GetRepository<Character>().GetFirstOrDefault(
                        predicate: c => c.Id == id && c.UserId == long.Parse(idUser),
                        include: c => c.Include(c => c.Skills)
                        );

                    if (character == null)
                    {
                        return NotFound(new { Message = "Character introuvable" });
                    }

                    return Ok(character);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreateACharacter(Character vM)
        {
            try
            {
                ClaimsIdentity identity = HttpContext.User.Identity as ClaimsIdentity;
                var id = identity.FindFirst(OpenIdConnectConstants.Claims.ClientId).Value;
                var user = _unitOfWork.GetRepository<User>().GetFirstOrDefault
                    (u => u.Id == long.Parse(id), include: (u => u.Include(u => u.Characters)));
                var repo = _unitOfWork.GetRepository<Character>();

                if (user.Characters != null && user.Characters.Count >= 10)
                {
                    return Conflict(new { Message = "You already have 10 character" });
                }
                if (repo.Exists(c => c.Name == vM.Name))
                {
                    return Conflict(new { Message = $"The name {vM.Name} is already use" });
                }
                Character character = null;
                user = _unitOfWork.GetRepository<User>().GetById(long.Parse(id));
                switch (vM.ClassName)
                {
                    case "Warrior":
                        character = HelperCharacter.CreateWarrior(vM.Name, user);
                        break;
                    case "Shaman":
                        character = HelperCharacter.CreateShaman(vM.Name, user);
                        break;
                    case "Wizard":
                        character = HelperCharacter.CreateWizard(vM.Name, user);
                        break;
                    default:
                        return NotFound(new { Message = $"The class {vM.ClassName} don't exsit" });
                }
                repo.Add(character);
                _unitOfWork.Save();
                return Ok(character);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPatch]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult EditACharacter(Character vM)
        {
            try
            {
                var repo = _unitOfWork.GetRepository<Character>();

                if (repo.Exists(c => c.Name == vM.Name))
                {
                    return Conflict(new { Message = $"The name {vM.Name} is already use" });
                }

                var character = repo.GetById(vM.Id);
                if (character == null)
                {
                    return NotFound(new { Message = $"The character {vM.Name} doesn't exsit" });
                }
                character.Name = vM.Name;
                _unitOfWork.Save();
                return Ok(character);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpDelete("{id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteCharacter([FromRoute] int id)
        {
            try
            {
                var character = _unitOfWork.GetRepository<Character>().GetFirstOrDefault(
                    predicate: (c => c.Id == id),
                    include: (c => c.Include(c => c.Skills))
                    );
                if (character == null)
                {
                    return NotFound(new { Message = $"The character doesn't exsit" });
                }

                _unitOfWork.GetRepository<Skill>().Delete(character.Skills);
                _unitOfWork.Save();
                _unitOfWork.GetRepository<Character>().Delete(character.Id);
                _unitOfWork.Save();
                return Ok(new { Message = $"The character {character.Name} is deleted" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpPut]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateLocationSkill(Character character)
        {
            try
            {
                ///récupère l'id du token pour retrouver a quelle user il correspond
                ClaimsIdentity identity = HttpContext.User.Identity as ClaimsIdentity;
                var id = identity.FindFirst(OpenIdConnectConstants.Claims.ClientId).Value;
                var user = _unitOfWork.GetRepository<User>().GetById(long.Parse(id));

                ///récupère UN character et sa List de skills
                var characterBdd = _unitOfWork.GetRepository<Character>().GetFirstOrDefault(
                    predicate: (c => c.Id == character.Id),
                    include: (c => c.Include(c => c.Skills))
                    );

                ///applique pour chaque skills de la bdd le nouvelle IsEnabled envoyé par notre site
                for (int i = 0; i < characterBdd.Skills.Count; i++)
                {
                    if (characterBdd.Skills[i].LevelToUnlock <= character.Level)
                    {
                        characterBdd.Skills[i].IsEnable = character.Skills[i].IsEnable;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }

                ///prépare l'état de lobjet characterBdd --> dans ce cas "Update" pour le mettre a jour
                ///sauvegarde son état pour l'appliquer
                ///return Ok==status code 200. Return le character vers le site
                _unitOfWork.GetRepository<Character>().Update(characterBdd);
                _unitOfWork.Save();
                return Ok(character);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}