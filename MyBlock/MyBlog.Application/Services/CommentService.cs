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
    public class CommentService : ICommentService
    {
        private readonly IGenericRepository<Comment> _commentRepository;

        public CommentService(IGenericRepository<Comment> commentRepository)
        {
            _commentRepository = commentRepository;
        }

        /// <summary>
        /// Метод для получения количества комментариев по Id записи
        /// </summary>
        public async Task<int> GetCommentsCountByCheckIdAsync(int checkId)
        {
            return  await _commentRepository.AsQueryable()
                .CountAsync(q => q.Id == checkId);
        }
    }
}
