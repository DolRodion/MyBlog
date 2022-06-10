using MyBlog.Application.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Interfaces
{
    public interface IAdminService
    {
        Task<bool> AddCheckAsync(FormAddCheckParams formAddCheckParams);

        Task<bool> RemoveCheckByIdAsync(int checkId);
    }
}
