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
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

      
        /// <summary>
        /// Добавление записи в БД
        /// </summary>
        /// <param name="formAddCheckParams"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddCheck")]
        public async Task<ActionResult<bool>> AddСheckAsync(FormAddCheckParams formAddCheckParams)
        {
            var result =  await _adminService.AddCheckAsync(formAddCheckParams);

            return Ok(result);
        }

        /// <summary>
        /// Удаление записи
        /// </summary>
        [HttpGet]
        [Route("RemoveCheckById")]
        public async Task<ActionResult<bool>> RemoveCheckByIdAsync(int checkId)
        {
            var result = await _adminService.RemoveCheckByIdAsync(checkId);

            return Ok(result);
        }


    }
}