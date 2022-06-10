using MyBlog.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Interfaces
{
    public interface ITagService
    {
        Task<string[]> GetTagsByCheckIdAsync(int checkId);
        Task<Tag[]> AddUnicalTagAsync(string[] tagNames);
    }
}
