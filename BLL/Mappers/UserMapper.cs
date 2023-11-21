using BLL.Models;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappers
{
    public static class UserMapper
    {
        public static User ToUser(this RegisterForm form)
        {
            return new User
            {
                Id = 0,
                Email = form.Email,
                Password = form.Password,
                Firstname = form.Firstname,
                Lastname = form.Lastname,
                LoginFailCount = 0,
                Suspended = false
            };
        }

        public static UserViewModel ToViewModel(this User user)
        {
            return new UserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                Firstname = user.Firstname,
                Lastname = user.Lastname
            };
        }
    }
}
