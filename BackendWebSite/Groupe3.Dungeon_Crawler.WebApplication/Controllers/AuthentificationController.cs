using AspNet.Security.OpenIdConnect.Extensions;
using AspNet.Security.OpenIdConnect.Primitives;
using Groupe3.Dungeon_Crawler.Entity;
using Groupe3.Dungeon_Crawler.EntitiesContext;
using Groupe3.Dungeon_Crawler.UnitOfWork.Contract;
using Microsoft.AspNetCore.Mvc;
using OpenIddict.Server;
using System;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Groupe3.Dungeon_Crawler.WebApplication.ViewModels;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using AspNet.Security.OAuth.Validation;
using Groupe3.Dungeon_Crrawler.Services;

namespace Groupe3.Dungeon_Crawler.WebApplication.Controllers
{
    public class AuthentificationController : ControllerBase
    {
        private readonly IUnitOfWork<DungeonCrawlerDbContextSql, GameService> _unitOfWork;
        public AuthentificationController(IUnitOfWork<DungeonCrawlerDbContextSql, GameService> uow) => _unitOfWork = uow;

        [HttpPost("~/Auth/Login"), Produces("application/json")]
        public IActionResult Login(OpenIdConnectRequest connectRequest)
        {
            if (connectRequest.IsPasswordGrantType())
            {
                var repo = _unitOfWork.GetRepository<User>();
                var sha = SHA256.Create();

                var user = repo.GetFirstOrDefault(u => u.Mail == connectRequest.Username);
                if (user == null)
                {
                    return Unauthorized(new { Message = "Login Failure, login is false" });
                }
                var passwordSaltedH = sha.ComputeHash(Encoding.ASCII.GetBytes(connectRequest.Password + Convert.ToBase64String(user.PasswordSalt)));
                if (!user.PasswordHash.SequenceEqual(passwordSaltedH))
                {
                    return Unauthorized(new { Message = "Login Failure, mdp is false" });
                }

                var identity = new ClaimsIdentity(
                    OpenIddictServerDefaults.AuthenticationScheme,
                    OpenIdConnectConstants.Claims.Name,
                    OpenIdConnectConstants.Claims.Role);
                identity.AddClaim(OpenIdConnectConstants.Claims.Subject,
                    "71346D62-9BA5-4B6D-9ECA-755574D628D8",
                    OpenIdConnectConstants.Destinations.AccessToken);
                identity.AddClaim(OpenIdConnectConstants.Claims.ClientId, user.Id.ToString(),
                    OpenIdConnectConstants.Destinations.AccessToken);

                var principal = new ClaimsPrincipal(identity);
                user.IsConnected = true;
                repo.Update(user);
                _unitOfWork.Save();
                // Ask OpenIddict to generate a new token and return an OAuth2 token response.
                return SignIn(principal, OpenIddictServerDefaults.AuthenticationScheme);
            }
            throw new InvalidOperationException("The specified grant type is not supported.");
        }

        [HttpPost("~/Auth/Signup"), Produces("application/json")]
        public IActionResult SignUp(AuthentificationVM userVM)
        {
            if (_unitOfWork.GetRepository<User>().Exists(u => u.Mail == userVM.Mail))
            {
                return Conflict(new { Message = "L'adresse mail existe déja" });
            }

            var sha = SHA256.Create();
            User user = new User
            {
                FirstName = userVM.FirstName,
                LastName = userVM.LastName,
                BirthDate = userVM.BirthDate,
                Mail = userVM.Mail,
                IsConnected = false
            };
            user.PasswordSalt = new byte[10];
            new RNGCryptoServiceProvider().GetNonZeroBytes(user.PasswordSalt);
            var passwordSaltedH = sha.ComputeHash(Encoding.ASCII.GetBytes(userVM.Password + Convert.ToBase64String(user.PasswordSalt)));
            user.PasswordHash = passwordSaltedH;

            try
            {
                _unitOfWork.GetRepository<User>().Add(user);
                _unitOfWork.Save();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Exeption = ex.InnerException.Message });
            }
        }

        [HttpPost("~/Auth/ResetPassword"), Produces("application/json")]
        public IActionResult ResetPassword(AuthentificationVM userVM)
        {
            var sha = SHA256.Create();

            var user = _unitOfWork.GetRepository<User>().GetFirstOrDefault(u => u.Mail == userVM.Mail);
            if (user == null)
            {
                return Unauthorized(new { Message = "Login is false" });
            }
            var passwordSaltedH = sha.ComputeHash(Encoding.ASCII.GetBytes(userVM.Password + Convert.ToBase64String(user.PasswordSalt)));
            if (user.PasswordHash.Equals(passwordSaltedH))
            {
                return Unauthorized(new { Message = "Mdp is false" });
            }
            passwordSaltedH = sha.ComputeHash(Encoding.ASCII.GetBytes(userVM.NewPassword + Convert.ToBase64String(user.PasswordSalt)));
            try
            {
                user.PasswordHash = passwordSaltedH;
                _unitOfWork.GetRepository<User>().Update(user);
                _unitOfWork.Save();
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        [Authorize(AuthenticationSchemes = OAuthValidationDefaults.AuthenticationScheme)]
        [HttpPost("~/Auth/SignOut"), Produces("application/json")]
        public IActionResult Disconnection()
        {
            ClaimsIdentity identity = HttpContext.User.Identity as ClaimsIdentity;
            var idUser = identity.FindFirst(OpenIdConnectConstants.Claims.ClientId).Value;
            var user = _unitOfWork.GetRepository<User>().GetById(long.Parse(idUser));

            if (user == null)
            {
                return NotFound(new { Message = "L'utilisateur n'existe pas" });
            }

            user.IsConnected = false;
            _unitOfWork.GetRepository<User>().Update(user);
            _unitOfWork.Save();
            return Ok();
        }
    }
}