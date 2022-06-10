using Microsoft.EntityFrameworkCore;
using Myblog.DataAccess.Interfaces;
using MyBlog.Application.Interfaces;
using MyBlog.Application.Models;
using MyBlog.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Services
{
    public class CheckService : ICheckService
    {
        private readonly IGenericRepository<Check> _checkRepository;
        private readonly ICommentService _commentService;
        private readonly ITagService _tagService;

        public CheckService(
            IGenericRepository<Check> checkRepository,
            ICommentService commentService,
            ITagService tagService
            )
        {
            _checkRepository = checkRepository;
            _commentService = commentService;
            _tagService = tagService;
        }

        /// <summary>
        /// Метод для получения всех записей из БД
        /// </summary>
        public async Task<CheckDataModel[]> GetAllCheckAsync()
        {
            var result = await _checkRepository.AsQueryable()
                .Select(q => new CheckDataModel
                {
                    Id = q.Id,
                    Name = q.Name,
                    CreateDate = q.CreateDate.ToString().Substring(0,16),
                    Text = q.Text,
                    IsCheckedVideoUrl = q.IsCheckedVideoUrl,
                    ImageUrl = q.ImageUrl,
                    CheckAuthor = q.CheckAuthor
                }).OrderByDescending(q => q.CreateDate).ToArrayAsync();

            foreach (var item in result)
            {
                item.CommentCount = await _commentService.GetCommentsCountByCheckIdAsync(item.Id);
                item.Tags = await _tagService.GetTagsByCheckIdAsync(item.Id);
            }

            return result;
        }

        /// <summary>
        /// Метод для получения записи по Id
        /// </summary>
        public async Task<CheckDataShortModel> GetCheckByIdAsync(int checkId)
        {
            if (checkId == 0)
            {
                throw new ArgumentNullException("Неверный идентификатор");
            }

            var result = await _checkRepository.AsQueryable()
                .Where(q => q.Id == checkId)
                .Select(q => new CheckDataShortModel
                {
                    Id = q.Id,
                    CheckAuthor = q.CheckAuthor,
                    ImageUrl = q.ImageUrl,
                    IsCheckedVideoUrl = q.IsCheckedVideoUrl,
                    Name = q.Name,
                    Text = q.Text
                    
                }).FirstOrDefaultAsync();


            result.Tags = await _tagService.GetTagsByCheckIdAsync(checkId);


            if (result == null)
            {
                throw new ArgumentNullException($"Запись с id = {checkId} не найдена");
            }

            return result;
        }

        /// <summary>
        /// Метод для получения всех записей по имени Тэга
        /// </summary>
        public async Task<CheckDataModel[]> GetCheckByTagNameAsync(string tagName)
        {
            if (tagName == String.Empty)
            {
                throw new ArgumentNullException("Неверный идентификатор");
            }

            var result = await _checkRepository.AsQueryable()
                .Where(q => q.Tags.Any(w =>w.Name == tagName))
                .Select(q => new CheckDataModel
                {
                    Id = q.Id,
                    Name = q.Name,
                    CreateDate = q.CreateDate.ToString().Substring(0, 16),
                    Text = q.Text,
                    IsCheckedVideoUrl = q.IsCheckedVideoUrl,
                    ImageUrl = q.ImageUrl,
                    CheckAuthor = q.CheckAuthor
                }).OrderByDescending(q => q.CreateDate).ToArrayAsync();


            foreach (var item in result)
            {
                item.CommentCount = await _commentService.GetCommentsCountByCheckIdAsync(item.Id);
                item.Tags = await _tagService.GetTagsByCheckIdAsync(item.Id);
            }

            return result;
        }

        /// <summary>
        /// Метод для получения добавления записи в БД
        /// </summary>
        public async Task AddCheckAsync(Check check)
        {
            await _checkRepository.InsertAsync(check);
            await _checkRepository.SaveChangesAsync();
        }

        /// <summary>
        /// Метод для получения удаления записи в БД
        /// </summary>
        public async Task<bool> RemoveCheckByIdAsync(int checkId)
        {
            if (checkId == 0)
            {
                throw new ArgumentNullException("Не верный ID");
            }

            await _checkRepository.DeleteAsync(checkId);
            await _checkRepository.SaveChangesAsync();

            return true;
        }

    }
}
