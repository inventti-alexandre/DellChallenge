using DellChallenge.Domain.Enitities;
using DellChallenge.Domain.EnititiesViewModel;
using DellChallenge.Domain.Interfaces;

namespace DellChallenge.Domain2.Services
{
    public class AuthenticationService
    {
        private readonly IUserRepository _repository;

        public AuthenticationService(IUserRepository repository)
        {
            _repository = repository;
        }

        public UserResultViewModel Login(UserLoginViewModel user)
        {
            var userToLogin = new User(user.Email, user.Password);

            var userFound = _repository.Find(userToLogin);

            if(userFound != null)
            {
                return new UserResultViewModel() { Email = userFound.Email, Id = userFound.Id, RoleId = userFound.Role.Id, RoleDescription = userFound.Role.Description };
            }

            return null;
        }
    }
}
