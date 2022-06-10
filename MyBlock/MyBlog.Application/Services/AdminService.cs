using Myblog.DataAccess.Interfaces;
using MyBlog.Application.Interfaces;
using MyBlog.Application.Params;
using MyBlog.DataAccess.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Application.Services
{
    public class AdminService : IAdminService
    {
        private readonly ITagService _tagService;
        private readonly ICheckService _checkService;

        public AdminService(ITagService tagService, ICheckService checkService)
        {
            _tagService = tagService;
            _checkService = checkService;
        }

        /// <summary>
        /// Метод для добавления новой записи в БД
        /// </summary>
        public async Task<bool> AddCheckAsync(FormAddCheckParams formAddCheckParams)
        {
            var entitiesTag = await _tagService.AddUnicalTagAsync(formAddCheckParams.Tags);

            await _checkService.AddCheckAsync(new Check()
            {
                CheckAuthor = "Администратор",
                CreateDate = DateTime.Now,
                ImageUrl = formAddCheckParams.ImageUrl,
                IsCheckedVideoUrl = formAddCheckParams.IsCheckedVideoUrl == null ? false : true,
                Name = formAddCheckParams.Name,
                Text = formAddCheckParams.Text,
                IsArhival = false,
                Tags = entitiesTag

            });

            return true;
        }

        /// <summary>
        /// Метод для удаления записи в БД
        /// </summary>
        public async Task<bool> RemoveCheckByIdAsync(int checkId)
        {
            if (checkId == 0)
            {
                throw new ArgumentNullException("Не верный ID");
            }

            var entityCheck = await _checkService.RemoveCheckByIdAsync(checkId);

            return entityCheck;
        }
    }
}