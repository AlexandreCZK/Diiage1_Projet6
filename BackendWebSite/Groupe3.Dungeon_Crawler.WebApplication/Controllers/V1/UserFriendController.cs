using AspNet.Security.OAuth.Validation;
using AspNet.Security.OpenIdConnect.Primitives;
using Groupe3.Dungeon_Crawler.EntitiesContext;
using Groupe3.Dungeon_Crawler.Entity;
using Groupe3.Dungeon_Crawler.UnitOfWork.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Mime;
using System.Security.Claims;
using System.Linq;
using System.Collections.Generic;
using Groupe3.Dungeon_Crrawler.Services;

namespace Groupe3.Dungeon_Crawler.WebApplication.Controllers.V1
{
    [ApiController]
    [Route("~/UserFriends")]
    [Authorize(AuthenticationSchemes = OAuthValidationDefaults.AuthenticationScheme)]
    public class UserFriendController : ControllerBase
    {
        private readonly IUnitOfWork<DungeonCrawlerDbContextSql, GameService> _unitOfWork;
        public UserFriendController(IUnitOfWork<DungeonCrawlerDbContextSql, GameService> uow) => _unitOfWork = uow;

        [HttpGet("{id?}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetFriendForUser([FromRoute] int? id = null)
        {
            try
            {
                ClaimsIdentity identity = HttpContext.User.Identity as ClaimsIdentity;
                var idUser = identity.FindFirst(OpenIdConnectConstants.Claims.ClientId).Value;
                var user = _unitOfWork.GetRepository<User>().GetById(long.Parse(idUser));

                if (id == null)
                {
                    var userFriend = _unitOfWork.GetRepository<UserFriend>()
                        .GetMuliple(
                        uf => uf.UserId == user.Id
                        );
                    var friends = new List<User>();

                    userFriend.ToList().ForEach(
                        uf =>
                            friends.Add(_unitOfWork.GetRepository<User>().GetById(uf.FriendId))
                        );

                    return Ok(friends.Select(f => new { f.Id, f.Mail, f.FirstName, f.LastName, f.IsConnected }));
                }
                else
                {
                    var userFriend = _unitOfWork.GetRepository<UserFriend>().GetFirstOrDefault(
                        uf => uf.UserId == user.Id && uf.FriendId == id
                        );
                    if (userFriend == null)
                    {
                        return NotFound(new { Message = "Utilisateur introuvable" });
                    }
                    var friend = _unitOfWork.GetRepository<User>().GetById(userFriend.FriendId);
                    return Ok(new { friend.Id, friend.Mail, friend.FirstName, friend.LastName, friend.IsConnected });
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
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult AddFriendForUser(User vM)
        {
            try
            {
                ClaimsIdentity identity = HttpContext.User.Identity as ClaimsIdentity;
                var idUser = identity.FindFirst(OpenIdConnectConstants.Claims.ClientId).Value;
                var user = _unitOfWork.GetRepository<User>().GetById(long.Parse(idUser));

                var userToAdd = _unitOfWork.GetRepository<User>().GetFirstOrDefault(u => u.Mail == vM.Mail);
                if (userToAdd == null)
                {
                    return NotFound(new { Message = "This user doesn't exist" });
                }
                if (user.Mail == vM.Mail)
                {
                    return Conflict(new { Message = "You can't add yourself" });
                }
                if (_unitOfWork.GetRepository<UserFriend>().Exists(uf => uf.UserId == user.Id && uf.FriendId == userToAdd.Id))
                {
                    return Conflict(new { Message = "You are already friend" });
                }
                var userFriend = new UserFriend { UserId = user.Id, FriendId = userToAdd.Id};
                var userFriend2 = new UserFriend { UserId = userToAdd.Id, FriendId = user.Id };
                _unitOfWork.GetRepository<UserFriend>().Add(userFriend);
                _unitOfWork.GetRepository<UserFriend>().Add(userFriend2);
                _unitOfWork.Save();
                return Ok(new { userToAdd.Id, userToAdd.Mail, userToAdd.FirstName, userToAdd.LastName, userToAdd.IsConnected });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpDelete("{id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteFriendForUser([FromRoute] int id)
        {
            try
            {
                ClaimsIdentity identity = HttpContext.User.Identity as ClaimsIdentity;
                var idUser = identity.FindFirst(OpenIdConnectConstants.Claims.ClientId).Value;
                var user = _unitOfWork.GetRepository<User>().GetById(long.Parse(idUser));

                var userToDelete = _unitOfWork.GetRepository<User>().GetFirstOrDefault(u => u.Id == id);
                var userFriendToDelete = _unitOfWork.GetRepository<UserFriend>().GetFirstOrDefault(uf => uf.UserId == user.Id && uf.FriendId == userToDelete.Id);
                if (userFriendToDelete == null)
                {
                    return Conflict(new { Message = "You are not friend" });
                }
                var userFriendToDelete2 = _unitOfWork.GetRepository<UserFriend>().GetFirstOrDefault(uf => uf.UserId == userToDelete.Id && uf.FriendId == user.Id);
                _unitOfWork.GetRepository<UserFriend>().Delete(userFriendToDelete);
                _unitOfWork.GetRepository<UserFriend>().Delete(userFriendToDelete2);
                _unitOfWork.Save();
                return Ok(new { Message = "Friend deleted" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
