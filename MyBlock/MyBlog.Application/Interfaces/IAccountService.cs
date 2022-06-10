using MyBlog.Application.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Application.Interfaces
{
    public interface IAccountService
    {
        bool Autorization(FormAuthorizationParams formAuthorizationParams);
    }
}
