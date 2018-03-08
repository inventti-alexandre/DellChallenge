using DellChallenge.Domain.Enitities;
using DellChallenge.Domain.Interfaces;
using DellChallange.Repository.Context;
using System.Collections.Generic;
using System.Linq;
using DellChallenge.Repository.Context;
using DellChallenge.Domain.Enum;

namespace DellChallange.Repository.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(DellContext kondominiumContext) : base(kondominiumContext)
        {
        }

        public UserRepository()
        {
        }

        public List<User> ListSeller()
        {
            return FakeContextSingleton.DbUser().Where(x => x.Role.Id == (int)RoleEnum.Seller).ToList();
        }

        public User Find(User user)
        {
            return FakeContextSingleton.DbUser().FirstOrDefault(x => x.Email.Equals(user.Email) && x.Password.Equals(user.Password));
        }
    }
}
