using Microsoft.AspNetCore.Mvc;
using MyBlog.Application.Interfaces;
using MyBlog.Application.Models;
using System.Threading.Tasks;

namespace MyBlog.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ICheckService _checkService;

        public HomeController(ICheckService checkService)
        {
            _checkService = checkService;
        }
        /// <summary>
        /// Получить все записи
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllCheck")]
        public async Task<ActionResult<CheckDataModel[]>> GetAllCheckAsync()
        {
            var result = await _checkService.GetAllCheckAsync();

            return Ok(result);
        }

        /// <summary>
        /// Получение записи по Id
        /// </summary>
        [HttpGet]
        [Route("GetCheckById")]
        public async Task<ActionResult<CheckDataShortModel>> GetCheckByIdAsync(int id)
        {
            var result = await _checkService.GetCheckByIdAsync(id);

            return Ok(result);
        }

        /// <summary>
        /// Получение всех записей по имени Тэга
        /// </summary>
        [HttpGet]
        [Route("GetCheckByTagName")]
        public async Task<ActionResult<CheckDataModel[]>> GetCheckByTagNameAsync(string tagName)
        {
            var result = await _checkService.GetCheckByTagNameAsync(tagName);

            return Ok(result);
        }

    }
}