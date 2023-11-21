using BLL.Interfaces;
using BLL.Mappers;
using BLL.Models;
using DAL.Entities;
using DAL.Interfaces;
using Hasher = BCrypt.Net.BCrypt;

namespace BLL.Services
{
    public class AuthService : IAuthService
    {

        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepo)
        {
            _userRepository = userRepo;
        }

        public UserViewModel? Login(LoginForm form)
        {
            User? user = _userRepository.GetByEmail(form.Email);

            if (user is null || user.Suspended)
            {
                return null;
            }

            if (Hasher.Verify(form.Password, user.Password))
            {
                user.LoginFailCount = 0;
                _userRepository.Update(user);
                return user.ToViewModel();
            }

            user.LoginFailCount++;

            if (user.LoginFailCount >= 3)
            {
                user.LoginFailCount = 0;
                user.Suspended = true;
            }

            _userRepository.Update(user);
            return null;
            

        }

        public bool Register(RegisterForm form, out string Error)
        {

            Error = "";
            if(_userRepository.GetByEmail(form.Email) is not null)
            {
                Error = "Email déjà utilisé.";
                return false;
            }

            form.Password = Hasher.HashPassword(form.Password);

            User? u = _userRepository.Create(form.ToUser());

            if (u == null)
            {
                Error = "Erreur inconnue lors de la creation.";
            }

            return u != null;
        }
    }
}
