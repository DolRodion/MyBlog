using Microsoft.EntityFrameworkCore;
using Myblog.DataAccess.Interfaces;
using MyBlog.Application.Interfaces;
using MyBlog.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Services
{
    public class TagService : ITagService
    {
        private readonly IGenericRepository<Tag> _tagRepository;

        public TagService(IGenericRepository<Tag> tagRepository)
        {
            _tagRepository = tagRepository;
        }

        /// <summary>
        /// Метод для получения тегов по Id записи
        /// </summary>
        public async Task<string[]> GetTagsByCheckIdAsync(int checkId)
        {
            return await _tagRepository.AsQueryable()
                .Where(q => q.Checks.Any(r => r.Id == checkId))
                .Select(w => w.Name)
                .ToArrayAsync();
        }

        /// <summary>
        /// Метод для получения уникальных тегов
        /// </summary>
        public async Task<Tag[]> AddUnicalTagAsync(string[] tagNames)
        {
            var entityTags = await _tagRepository.AsQueryable().ToListAsync();

            foreach (var tag in tagNames)
            {
                if (!entityTags.Any(q => q.Name == tag))
                {
                    var newTag = new Tag(tag);

                    await _tagRepository.InsertAsync(newTag);
                    entityTags.Add(newTag);
                }
            }

            await _tagRepository.SaveChangesAsync();

            return entityTags.Where(q => tagNames
                    .Contains(q.Name))
                .ToArray();
        }
    }
}
