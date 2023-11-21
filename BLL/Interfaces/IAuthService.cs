using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IAuthService
    {
        bool Register(RegisterForm form, out string Error);

        UserViewModel? Login(LoginForm form);
    }
}
