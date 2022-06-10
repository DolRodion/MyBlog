using Microsoft.AspNetCore.Mvc;
using MyBlog.Application.Interfaces;
using MyBlog.Application.Params;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using IdentityServer4;

namespace MyBlog.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

      
        /// <summary>
        /// Авторизация пользователя
        /// </summary>
        [HttpPost]
        [Route("Authorization")]
        public ActionResult<bool> Authorization(FormAuthorizationParams formAuthorizationParams)
        {
            bool result = _accountService.Autorization(formAuthorizationParams);

            return Ok(result);
        }

    }
}