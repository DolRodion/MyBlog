using MyBlog.Application.Models;
using MyBlog.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Interfaces
{
    public interface ICheckService
    {
        Task<CheckDataModel[]> GetAllCheckAsync();

        Task<CheckDataShortModel> GetCheckByIdAsync(int checkId);

        Task AddCheckAsync(Check check);

        Task<CheckDataModel[]> GetCheckByTagNameAsync(string tagName);

        Task<bool> RemoveCheckByIdAsync(int checkId);

    }
}
