using DellChallenge.Domain.Enitities;
using DellChallenge.Domain.Interfaces;
using DellChallange.Repository.Context;
using System.Collections.Generic;
using System.Linq;

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
            return DbUser().Where(x => x.Role.Id == 2).ToList();
        }

        public User Find(User user)
        {
            return DbUser().FirstOrDefault(x => x.Email.Equals(user.Email) && x.Password.Equals(user.Password));
        }

        public static List<User> DbUser()
        {
            var users = new List<User>()
            {
                new User(1, "admin@sellseverything.com", new Role(1, "Administrator"), "admin123"),
                new User(1, "seller1@sellseverything.com", new Role(2, "Seller"), "seller1123"),
                new User(1, "seller2@sellseverything.com", new Role(2, "Seller"), "seller2123"),
            };

            return users;
        }
    }
}
